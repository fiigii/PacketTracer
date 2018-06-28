using System.Runtime.Intrinsics.X86;
using static System.Runtime.Intrinsics.X86.Avx;
using static System.Runtime.Intrinsics.X86.Avx2;
using static System.Runtime.Intrinsics.X86.Sse2;
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
                Vector256<float> xs = SetVector256(fx, fx+1, fx+2, fx+3, fx+4, fx+5, fx+6, fx+7);
                var dirs = GetVectorPacket256(xs, SetAllVector256((float)y), camera);
                var rayPacket256 = new RayPacket256(camera.PosPacket256, dirs);
                var SoAcolors = TraceRay(rayPacket256, scene, 0);

                // Writ into memory via xmm registers
                var AoS = SoAcolors.FastTranspose();
                var intSoA = AoS.ConvertToIntRGB();
                var m0 = GetLowerHalf<int>(intSoA.Rs);
                var m1 = GetLowerHalf<int>(intSoA.Gs);
                var m2 = GetLowerHalf<int>(intSoA.Bs);
                var m3 = ExtractVector128(intSoA.Rs, 1);
                var m4 = ExtractVector128(intSoA.Gs, 1);
                var m5 = ExtractVector128(intSoA.Bs, 1);
                
                fixed (int* output = &rgb[x + stride])
                {
                    Store(output, m0);
                    Store(output + 4, m1);
                    Store(output + 8, m2);
                    Store(output + 12, m3);
                    Store(output + 16, m4);
                    Store(output + 20, m5);
                }

                /* Writ into memory via ymm registers
                var SoA = colors.Transpose();
                var intSoA = SoA.ConvertToIntRGB();
                fixed (int* output = &rgb[x + stride])
                {
                    Store(output, intSoA.xs);
                    Store(output + 8, intSoA.ys);
                    Store(output + 16, intSoA.zs);
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

    private Vector256<float> TestRay(RayPacket256 rayPacket256, Scene scene)
    {
        var isect = MinIntersections(rayPacket256, scene);
        if(isect.AllNullIntersections())
        {
            return SetZeroVector256<float>();
        }
        return isect.Distances;
    }

    private Intersections MinIntersections(RayPacket256 rayPacket256, Scene scene)
    {
        Intersections mins = Intersections.Null;
        foreach (SceneObject obj in scene.Things)
        {
            var objPacket256 = obj.ToPacket256();
            var orgIsect = objPacket256.Intersect(rayPacket256);
            if (!orgIsect.AllNullIntersections())
            {
                var nullMinMask = Compare(mins.Distances, Intersections.Null.Distances, FloatComparisonMode.EqualOrderedNonSignaling);
                var lessMinMask = Compare(mins.Distances, orgIsect.Distances, FloatComparisonMode.GreaterThanOrderedNonSignaling);
                var minDis = BlendVariable(mins.Distances, orgIsect.Distances, Or(nullMinMask, lessMinMask));
                mins.Distances = minDis;
                mins.Thing = obj;
            }
        }
        return mins;
    }

    private ColorPacket256 Shade(Intersections isect, RayPacket256 rayPacket256, Scene scene, int depth)
    {
        
        var ds = rayPacket256.Dirs;
        var pos = isect.Distances * ds + rayPacket256.Starts;
        var normals = isect.Thing.ToPacket256().Normal(pos);
        var reflectDirs = ds - VectorPacket256.DotProduct(normals, ds) * normals;
        var colors = ColorPacket256Helper.DefaultColor + GetNaturalColor(isect.Thing, pos, normals, reflectDirs, scene);

        if (depth >= MaxDepth)
        {
            return colors + (new Color(.5f, .5f, .5f)).ToColorPacket256();
        }

        return colors + GetReflectionColor(isect.Thing, pos + (SetAllVector256<float>(0.001f) * reflectDirs), normals, reflectDirs, scene, depth); 
    }

    private ColorPacket256 GetNaturalColor(SceneObject thing,VectorPacket256 pos, VectorPacket256 norms, VectorPacket256 rds, Scene scene)
    {
        var colors = ColorPacket256Helper.DefaultColor;
        foreach (Light light in scene.Lights)
        {
            var lights = light.ToPacket256();
            var ldis = lights.Positions - pos;
            var livec = ldis.Normalize();
            var neatIsectDis = TestRay(new RayPacket256(pos, livec), scene);
            
            // is in shadow?
            var mask1 = Compare(neatIsectDis, ldis.Lengths, FloatComparisonMode.LessThanOrEqualOrderedNonSignaling);
            var mask2 = Compare(neatIsectDis, SetZeroVector256<float>(), FloatComparisonMode.NotEqualOrderedNonSignaling);
            var isInShadow = And(mask1, mask2);

            Vector256<float> illum = VectorPacket256.DotProduct(livec, norms);
            Vector256<float> illumGraterThanZero = Compare(illum, SetZeroVector256<float>(), FloatComparisonMode.GreaterThanOrderedNonSignaling);
            var tmpColor1 = illum * light.Color.ToColorPacket256();
            var defaultRGB = SetZeroVector256<float>();
            Vector256<float> lcolorR = BlendVariable(tmpColor1.xs, defaultRGB, illumGraterThanZero);
            Vector256<float> lcolorG = BlendVariable(tmpColor1.ys, defaultRGB, illumGraterThanZero);
            Vector256<float> lcolorB = BlendVariable(tmpColor1.zs, defaultRGB, illumGraterThanZero);
            ColorPacket256 lcolor = new ColorPacket256(lcolorR, lcolorG, lcolorB);
            Vector256<float> specular = VectorPacket256.DotProduct(livec, rds.Normalize());
            Vector256<float> specularGraterThanZero = Compare(specular, SetZeroVector256<float>(), FloatComparisonMode.GreaterThanOrderedNonSignaling);
            var tmpColor2 = VectorUtilities.Pow(specular, SetAllVector256<float>(thing.Surface.Roughness)) * light.Color.ToColorPacket256();
            Vector256<float> scolorR = BlendVariable(tmpColor2.xs, defaultRGB, specularGraterThanZero);
            Vector256<float> scolorG = BlendVariable(tmpColor2.ys, defaultRGB, specularGraterThanZero);
            Vector256<float> scolorB = BlendVariable(tmpColor2.zs, defaultRGB, specularGraterThanZero);
            ColorPacket256 scolor = new ColorPacket256(scolorR, scolorG, scolorB);

            colors = colors + ColorPacket256Helper.Times(thing.Surface.Diffuse(pos), lcolor) + ColorPacket256Helper.Times(thing.Surface.Specular(pos), scolor);

            colors = new ColorPacket256(BlendVariable(colors.xs, defaultRGB, isInShadow), BlendVariable(colors.ys, defaultRGB, isInShadow), BlendVariable(colors.zs, defaultRGB, isInShadow));
            
        }
        return colors;
    }

    private ColorPacket256 GetReflectionColor(SceneObject thing,VectorPacket256 pos, VectorPacket256 norms, VectorPacket256 rds, Scene scene, int depth)
    {
        return thing.Surface.Reflect(pos) * TraceRay(new RayPacket256(pos, rds), scene, depth + 1);
    }

    private VectorPacket256 GetVectorPacket256(Vector256<float> x, Vector256<float> y, Camera camera)
    {
        float widthRate1 = Width / 2.0f;
        float widthRate2 = Width * 2.0f;

        float hightRate1 = Hight / 2.0f;
        float hightRate2 = Hight * 2.0f;

        var recenteredX = Divide(Subtract(x, SetAllVector256(widthRate1)), SetAllVector256(widthRate2));
        var recenteredY = Subtract(SetZeroVector256<float>(), Divide(Subtract(y, SetAllVector256(hightRate1)), SetAllVector256(hightRate2)));

        var result = camera.ForwardPacket256 + 
                    (recenteredX * camera.RightPacket256) +
                    (recenteredY * camera.UpPacket256);

        return result.Normalize();
    }
}