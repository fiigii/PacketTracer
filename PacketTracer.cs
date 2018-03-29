using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;
using System.Collections.Generic;

using ColorPacket256 = VectorPacket256;

internal class Packet256Tracer
{
    public int Width {get; private set;}
    public int Hight {get; private set;}
    private static readonly int MaxDepth = 5;

    public Packet256Tracer(int _width, int _hight)
    {
        if(_width % VectorPacket256.Packet256Size != 0)
        {
            _width += VectorPacket256.Packet256Size - _width % VectorPacket256.Packet256Size;
        }
        Width = _width;
        Hight = _hight;
    }

    internal unsafe void RenderVectorized(Scene scene, int[] rgb)
    {
        Camera camera = scene.Camera;
        for (int y = 0; y < Hight; y++)
        {
            int stride = y * Hight;
            for (int x = 0; x  < Width; x += VectorPacket256.Packet256Size)
            {
                float fx = (float)x;
                Vector256<float> xs = Avx.SetVector256(fx, fx+1, fx+2, fx+3, fx+4, fx+5, fx+6, fx+7);
                var dirs = GetVectorPacket256(xs, Avx.SetAllVector256((float)y), camera);
                var rayPacket256 = new RayPacket256(camera.PosPacket256, dirs);
                var colors = TraceRay(rayPacket256, scene, 0);

                // Writ into memory via xmm registers
                var SoA = colors.FastTranspose();
                var intSoA = SoA.ConvertToIntRGB();
                var m0 = Avx.GetLowerHalf<int>(intSoA.Rs);
                var m1 = Avx.GetLowerHalf<int>(intSoA.Gs);
                var m2 = Avx.GetLowerHalf<int>(intSoA.Bs);
                var m3 = Avx2.ExtractVector128(intSoA.Rs, 1);
                var m4 = Avx2.ExtractVector128(intSoA.Gs, 1);
                var m5 = Avx2.ExtractVector128(intSoA.Bs, 1);
                
                fixed (int* output = &rgb[x + stride])
                {
                    Sse2.Store(output, m0);
                    Sse2.Store(output + 4, m1);
                    Sse2.Store(output + 8, m2);
                    Sse2.Store(output + 12, m3);
                    Sse2.Store(output + 16, m4);
                    Sse2.Store(output + 20, m5);
                }

                /* Writ into memory via ymm registers
                var SoA = colors.Transpose();
                var intSoA = SoA.ConvertToIntRGB();
                fixed (int* output = &rgb[x + stride])
                {
                    Avx.Store(output, intSoA.xs);
                    Avx.Store(output + 8, intSoA.ys);
                    Avx.Store(output + 16, intSoA.zs);
                }
                */
                
            }
        }

    }

    private ColorPacket256 TraceRay(RayPacket256 rayPacket256, Scene scene, int depth)
    {
        var isect = MinIntersections(rayPacket256, scene);
        if(isect.AllNullIntersections())
        {
            return ColorPacket256Helper.BackgroundColor;
        }
        return Shade(isect, rayPacket256, scene,depth);
    }

    private Vector256<float> TestRay(RayPacket256 rayPacket256, Scene scene, int depth)
    {
        var isect = MinIntersections(rayPacket256, scene);
        if(isect.AllNullIntersections())
        {
            return Avx.SetZeroVector256<float>();
        }
        return isect.Distances;
    }

    private Intersections MinIntersections(RayPacket256 rayPacket256, Scene scene)
    {
        Intersections mins = Intersections.Null;
        int index = 0;
        foreach (SceneObject obj in scene.Things)
        {
            var objPacket256 = obj.ToPacket256();
            var orgIsect = objPacket256.Intersect(rayPacket256, index);
            if (!orgIsect.AllNullIntersections())
            {
                var nullMinMask = Avx.Compare(mins.Distances, Intersections.Null.Distances, FloatComparisonMode.EqualOrderedNonSignaling);
                var lessMinMask = Avx.Compare(mins.Distances, orgIsect.Distances, FloatComparisonMode.GreaterThanOrderedNonSignaling);
                var minDis = Avx.BlendVariable(mins.Distances, orgIsect.Distances, Avx.Or(nullMinMask, lessMinMask));
                mins.Distances = minDis;
                var minIndex = Avx.BlendVariable(Avx.StaticCast<int, float>(mins.ThingIndex), 
                                                 Avx.StaticCast<int, float>(Avx.SetAllVector256(index)), 
                                                 Avx.Or(nullMinMask, lessMinMask)); //CSE
                mins.ThingIndex = Avx.StaticCast<float, int>(minIndex);
            }
            index++;
        }
        return mins;
    }

    private ColorPacket256 Shade(Intersections isect, RayPacket256 rayPacket256, Scene scene, int depth)
    {
        var colors = ColorPacket256Helper.DefaultColor;
        var ds = rayPacket256.Dirs;
        var pos = isect.Distances * ds + rayPacket256.Starts;
        var intersectedThings = isect.WithThings();
        var normals = new Dictionary<int, VectorPacket256>();
        foreach (var objIndex in intersectedThings)
        {
            if (!normals.ContainsKey(objIndex))
            {
                normals[objIndex] = scene.Things[objIndex].ToPacket256().Normal(pos);
            }
        }
        /* 
        var intersectedNormals = Avx.SetZeroVector256<float>();
        foreach (var pair in normals)
        {
            var index = pair.Key;
            var normal = pair.value;
            var posMask = Avx2.CompareEqual(isect.ThingIndex, Avx.SetAllVector256(index));
            intersectedNormals = Avx.BlendVariable(intersectedNormals, normal, posMask);
        }

        var reflectDirs = ds - Avx.Multiply(Avx.SetAllVector256(2f), VectorPacket256.DotProduct(intersectedNormals, ds)) * intersectedNormals;
        */
        //colors += GetNaturalColor();

        if (depth >= MaxDepth)
        {
            return colors + (new Color(.5f, .5f, .5f)).ToColorPacket256();
        }

        return colors; 
    }

    /* 
    private ColorPacket256 GetNaturalColor(Scene scene, VectorPacket256 pos, Vector norms, Vector rds, int depth)
    {
        var colors = ColorPacket256Helper.DefaultColor;
        foreach (Light light in scene.Lights)
        {
            var lights = light.ToPacket256();
            var ldis = lights.Positions - pos;
            var livec = ldis.Normalize();
            var neatIsect = TestRay(new RayPacket256(pos, livec), scene);
            
        }
    }
    */    

    private VectorPacket256 GetVectorPacket256(Vector256<float> x, Vector256<float> y, Camera camera)
    {
        float widthRate1 = Width / 2.0f;
        float widthRate2 = Width * 2.0f;

        float hightRate1 = Hight / 2.0f;
        float hightRate2 = Hight * 2.0f;

        var recenteredX = Avx.Divide(Avx.Subtract(x, Avx.SetAllVector256(widthRate1)), Avx.SetAllVector256(widthRate2));
        var recenteredY = Avx.Subtract(Avx.SetZeroVector256<float>(), Avx.Divide(Avx.Subtract(y, Avx.SetAllVector256(hightRate1)), Avx.SetAllVector256(hightRate2)));

        var result = camera.ForwardPacket256 + 
                    (recenteredX * camera.RightPacket256) +
                    (recenteredY * camera.UpPacket256);

        return result.Normalize();
    }
}