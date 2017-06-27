using System.Runtime.CompilerServices.Intrinsics.Intel;
using System.Runtime.CompilerServices.Intrinsics;
using System.Collections.Generic;

using ColorPacket = VectorPacket;

internal class PacketTracer
{
    public int Width {get; private set;}
    public int Hight {get; private set;}
    private static readonly int MaxDepth = 5;

    public PacketTracer(int _width, int _hight)
    {
        if(_width % VectorPacket.PacketSize != 0)
        {
            _width += VectorPacket.PacketSize - _width % VectorPacket.PacketSize;
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
            for (int x = 0; x  < Width; x += VectorPacket.PacketSize)
            {
                float fx = (float)x;
                Vector256<float> xs = AVX.Set(fx, fx+1, fx+2, fx+3, fx+4, fx+5, fx+6, fx+7);
                var dirs = GetVectorPacket(xs, AVX.Set1((float)y), camera);
                var rayPacket = new RayPacket(camera.PosPacket, dirs);
                var colors = TraceRay(rayPacket, scene, 0);

                // Writ into memory via xmm registers
                var SoA = colors.FastTranspose();
                var intSoA = SoA.ConvertToIntRGB();
                var m0 = AVX.GetLowerHalf<int>(intSoA.Rs);
                var m1 = AVX.GetLowerHalf<int>(intSoA.Gs);
                var m2 = AVX.GetLowerHalf<int>(intSoA.Bs);
                var m3 = AVX2.ExtractVector128(intSoA.Rs, 1);
                var m4 = AVX2.ExtractVector128(intSoA.Gs, 1);
                var m5 = AVX2.ExtractVector128(intSoA.Bs, 1);
                
                fixed (int* output = &rgb[x + stride])
                {
                    SSE2.Store(output, m0);
                    SSE2.Store(output + 4, m1);
                    SSE2.Store(output + 8, m2);
                    SSE2.Store(output + 12, m3);
                    SSE2.Store(output + 16, m4);
                    SSE2.Store(output + 20, m5);
                }

                /* Writ into memory via ymm registers
                var SoA = colors.Transpose();
                var intSoA = SoA.ConvertToIntRGB();
                fixed (int* output = &rgb[x + stride])
                {
                    AVX.Store(output, intSoA.xs);
                    AVX.Store(output + 8, intSoA.ys);
                    AVX.Store(output + 16, intSoA.zs);
                }
                */
                
            }
        }

    }

    private ColorPacket TraceRay(RayPacket rayPacket, Scene scene, int depth)
    {
        var isect = MinIntersections(rayPacket, scene);
        if(isect.AllNullIntersections())
        {
            return ColorPacketHelper.BackgroundColor;
        }
        return Shade(isect, rayPacket, scene,depth);
    }

    private Vector256<float> TestRay(RayPacket rayPacket, Scene scene, int depth)
    {
        var isect = MinIntersections(rayPacket, scene);
        if(isect.AllNullIntersections())
        {
            return AVX.SetZero<float>();
        }
        return isect.Distances;
    }

    private Intersections MinIntersections(RayPacket rayPacket, Scene scene)
    {
        Intersections mins = Intersections.Null;
        int index = 0;
        foreach (SceneObject obj in scene.Things)
        {
            var objPacket = obj.ToPacket();
            var orgIsect = objPacket.Intersect(rayPacket, index);
            if (!orgIsect.AllNullIntersections())
            {
                var nullMinMask = AVX.CompareVector256Float(mins.Distances, Intersections.Null.Distances, FloatComparisonMode.CompareEqualOrderedNonSignaling);
                var lessMinMask = AVX.CompareVector256Float(mins.Distances, orgIsect.Distances, FloatComparisonMode.CompareGreaterThanOrderedNonSignaling);
                var minDis = AVX.BlendVariable(mins.Distances, orgIsect.Distances, AVX.Or(nullMinMask, lessMinMask));
                mins.Distances = minDis;
                var minIndex = AVX.BlendVariable(AVX.StaticCast<int, float>(mins.ThingIndex), 
                                                 AVX.StaticCast<int, float>(AVX.Set1(index)), 
                                                 AVX.Or(nullMinMask, lessMinMask)); //CSE
                mins.ThingIndex = AVX.StaticCast<float, int>(minIndex);
            }
            index++;
        }
        return mins;
    }

    private ColorPacket Shade(Intersections isect, RayPacket rayPacket, Scene scene, int depth)
    {
        var colors = ColorPacketHelper.DefaultColor;
        var ds = rayPacket.Dirs;
        var pos = isect.Distances * ds + rayPacket.Starts;
        var intersectedThings = isect.WithThings();
        var normals = new Dictionary<int, VectorPacket>();
        foreach (var objIndex in intersectedThings)
        {
            if (!normals.ContainsKey(objIndex))
            {
                normals[objIndex] = scene.Things[objIndex].ToPacket().Normal(pos);
            }
        }
        /* 
        var intersectedNormals = AVX.SetZero<float>();
        foreach (var pair in normals)
        {
            var index = pair.Key;
            var normal = pair.value;
            var posMask = AVX2.CompareEqual(isect.ThingIndex, AVX.Set1(index));
            intersectedNormals = AVX.BlendVariable(intersectedNormals, normal, posMask);
        }

        var reflectDirs = ds - AVX.Multiply(AVX.Set1(2f), VectorPacket.DotProduct(intersectedNormals, ds)) * intersectedNormals;
        */
        //colors += GetNaturalColor();

        if (depth >= MaxDepth)
        {
            return colors + (new Color(.5f, .5f, .5f)).ToColorPacket();
        }

        return colors; 
    }

    /* 
    private ColorPacket GetNaturalColor(Scene scene, VectorPacket pos, Vector norms, Vector rds, int depth)
    {
        var colors = ColorPacketHelper.DefaultColor;
        foreach (Light light in scene.Lights)
        {
            var lights = light.ToPacket();
            var ldis = lights.Positions - pos;
            var livec = ldis.Normalize();
            var neatIsect = TestRay(new RayPacket(pos, livec), scene);
            
        }
    }
    */    

    private VectorPacket GetVectorPacket(Vector256<float> x, Vector256<float> y, Camera camera)
    {
        float widthRate1 = Width / 2.0f;
        float widthRate2 = Width * 2.0f;

        float hightRate1 = Hight / 2.0f;
        float hightRate2 = Hight * 2.0f;

        var recenteredX = AVX.Divide(AVX.Subtract(x, AVX.Set1(widthRate1)), AVX.Set1(widthRate2));
        var recenteredY = AVX.Subtract(AVX.SetZero<float>(), AVX.Divide(AVX.Subtract(y, AVX.Set1(hightRate1)), AVX.Set1(hightRate2)));

        var result = camera.ForwardPacket + 
                    (recenteredX * camera.RightPacket) +
                    (recenteredY * camera.UpPacket);

        return result.Normalize();
    }
}