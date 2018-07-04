using System.Runtime.Intrinsics.X86;
using static System.Runtime.Intrinsics.X86.Avx;
using static System.Runtime.Intrinsics.X86.Avx2;
using static System.Runtime.Intrinsics.X86.Sse2;
using System.Runtime.Intrinsics;
using System;

using ColorPacket256 = VectorPacket256;

internal class Packet256Tracer
{
    public int Width { get; private set; }
    public int Hight { get; private set; }
    private static readonly int MaxDepth = 1;

    public Packet256Tracer(int _width, int _hight)
    {
        /* 
        if(_width % VectorPacket256.Packet256Size != 0)
        {
            _width += VectorPacket256.Packet256Size - _width % VectorPacket256.Packet256Size;
        }
        */
        Width = _width;
        Hight = _hight;
    }

    internal unsafe void RenderVectorized(Scene scene, int* rgb)
    {
        Camera camera = scene.Camera;
        for (int y = 0; y < Hight; y++)
        {
            int stride = y * Hight;
            for (int x = 0; x < Width; x += VectorPacket256.Packet256Size)
            {
                float fx = (float)x;
                Vector256<float> Xs = SetVector256(fx, fx + 1, fx + 2, fx + 3, fx + 4, fx + 5, fx + 6, fx + 7);
                var dirs = GetVectorPacket256(Xs, SetAllVector256((float)y), camera);
                var rayPacket256 = new RayPacket256(camera.Pos, dirs);
                var SoAcolors = TraceRay(rayPacket256, scene, 0);

                // Write into memory via xmm registers
                var AoS = SoAcolors.FastTranspose();
                var intAoS = AoS.ConvertToIntRGB();
                var m0 = GetLowerHalf<int>(intAoS.Rs);
                var m1 = GetLowerHalf<int>(intAoS.Gs);
                var m2 = GetLowerHalf<int>(intAoS.Bs);
                var m3 = ExtractVector128(intAoS.Rs, 1);
                var m4 = ExtractVector128(intAoS.Gs, 1);
                var m5 = ExtractVector128(intAoS.Bs, 1);

                int* output = &rgb[x + stride];
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
                    Store(output, intSoA.Xs);
                    Store(output + 8, intSoA.Ys);
                    Store(output + 16, intSoA.Zs);
                }
                */

            }
        }

    }

    private ColorPacket256 TraceRay(RayPacket256 rayPacket256, Scene scene, int depth)
    {
        var isect = MinIntersections(rayPacket256, scene);
        if (isect.AllNullIntersections())
        {
            return ColorPacket256Helper.BackgroundColor;
        }
        return Shade(isect, rayPacket256, scene, depth);
    }

    private Vector256<float> TestRay(RayPacket256 rayPacket256, Scene scene)
    {
        var isect = MinIntersections(rayPacket256, scene);
        if (isect.AllNullIntersections())
        {
            return SetZeroVector256<float>();
        }
        return isect.Distances;
    }

    private Intersections MinIntersections(RayPacket256 rayPacket256, Scene scene)
    {
        Intersections mins = Intersections.Null;
        for (int i = 0; i < scene.Things.Length; i++)
        {
            var obj = scene.Things[i];
            var thisIndex = StaticCast<int, float>(SetAllVector256<int>(i));
            var nullIndex = StaticCast<int, float>(Intersections.Null.ThingIndeces);

            Vector256<float> distance = Intersections.Null.Distances;

            if (obj is Plane)
            {
                var planPacket = new PlanePacket256((Plane)obj);

                var denom = VectorPacket256.DotProduct(planPacket.Norms, rayPacket256.Dirs);
                var dist = Divide(Add(VectorPacket256.DotProduct(planPacket.Norms, rayPacket256.Starts), planPacket.Offsets), Subtract(SetZeroVector256<float>(), denom));

                var gtMask = Compare(denom, SetZeroVector256<float>(), FloatComparisonMode.GreaterThanOrderedSignaling);
                distance = BlendVariable(Intersections.Null.Distances, dist, gtMask);
            }
            else if (obj is Sphere)
            {
                var spherePacket = new SpherePacket256((Sphere)obj);
                var eo = spherePacket.Centers - rayPacket256.Starts;
                var v = VectorPacket256.DotProduct(eo, rayPacket256.Dirs);

                var zeroVMask = Compare(v, SetZeroVector256<float>(), FloatComparisonMode.LessThanOrderedSignaling);
                var zero = SetZeroVector256<int>();
                var allOneMask = Avx2.CompareEqual(zero, zero);
                if (TestC(zeroVMask, StaticCast<int, float>(allOneMask)))
                {
                    continue; // Null Intersections
                }

                var discs = Subtract(Multiply(spherePacket.Radiuses, spherePacket.Radiuses), Subtract(VectorPacket256.DotProduct(eo, eo), Multiply(v, v)));
                var zeroDiscMask = Compare(discs, SetZeroVector256<float>(), FloatComparisonMode.LessThanOrderedSignaling);
                var dists = BlendVariable(SetZeroVector256<float>(), Subtract(v,  Sqrt(discs)), Or(zeroVMask, zeroDiscMask));

                distance = BlendVariable(SetZeroVector256<float>(), dists, zeroVMask);

            }
            else
            {
                throw new ArgumentException("Unknown type of SceneObject");
            }

            if (!Intersections.AllNullIntersections(distance))
            {
                var notNullMask = Compare(distance, Intersections.Null.Distances, FloatComparisonMode.NotEqualOrderedSignaling);
                var nullMinMask = Compare(mins.Distances, Intersections.Null.Distances, FloatComparisonMode.EqualOrderedSignaling);
                var lessMinMask = Compare(mins.Distances, distance, FloatComparisonMode.GreaterThanOrderedSignaling);
                var minMask = And(notNullMask, (Or(nullMinMask, lessMinMask)));
                var minDis = BlendVariable(mins.Distances, distance, minMask);
                var minIndeces = StaticCast<float, int>(BlendVariable(StaticCast<int, float>(mins.ThingIndeces),
                                                                      StaticCast<int, float>(SetAllVector256<int>(i)),
                                                                      minMask));
                mins.Distances = minDis;
                mins.ThingIndeces = minIndeces;
            }
        }
        return mins;
    }

    private ColorPacket256 Shade(Intersections isect, RayPacket256 rays, Scene scene, int depth)
    {

        var ds = rays.Dirs;
        var pos = isect.Distances * ds + rays.Starts;
        var normals = scene.Normals(isect.ThingIndeces, pos);
        var reflectDirs = ds - VectorPacket256.DotProduct(normals, ds) * normals;
        var colors = ColorPacket256Helper.DefaultColor + GetNaturalColor(isect.ThingIndeces, pos, normals, reflectDirs, scene);

        if (depth >= MaxDepth)
        {
            return colors + (new Color(.5f, .5f, .5f)).ToColorPacket256();
        }

        return colors + GetReflectionColor(isect.ThingIndeces, pos + (SetAllVector256<float>(0.001f) * reflectDirs), normals, reflectDirs, scene, depth);
    }

    private ColorPacket256 GetNaturalColor(Vector256<int> things, VectorPacket256 pos, VectorPacket256 norms, VectorPacket256 rds, Scene scene)
    {
        var colors = ColorPacket256Helper.DefaultColor;
        foreach (Light light in scene.Lights)
        {
            var lights = light.ToPacket256();
            var ldis = lights.Positions - pos;
            var livec = ldis.Normalize();
            var neatIsectDis = TestRay(new RayPacket256(pos, livec), scene);

            // is in shadow?
            var mask1 = Compare(neatIsectDis, ldis.Lengths, FloatComparisonMode.LessThanOrEqualOrderedSignaling);
            var mask2 = Compare(neatIsectDis, SetZeroVector256<float>(), FloatComparisonMode.NotEqualOrderedSignaling);
            var isInShadow = And(mask1, mask2);

            Vector256<float> illum = VectorPacket256.DotProduct(livec, norms);
            Vector256<float> illumGraterThanZero = Compare(illum, SetZeroVector256<float>(), FloatComparisonMode.GreaterThanOrderedSignaling);
            var tmpColor1 = illum * light.Color.ToColorPacket256();
            var defaultRGB = SetZeroVector256<float>();
            Vector256<float> lcolorR = BlendVariable(tmpColor1.Xs, defaultRGB, illumGraterThanZero);
            Vector256<float> lcolorG = BlendVariable(tmpColor1.Ys, defaultRGB, illumGraterThanZero);
            Vector256<float> lcolorB = BlendVariable(tmpColor1.Zs, defaultRGB, illumGraterThanZero);
            ColorPacket256 lcolor = new ColorPacket256(lcolorR, lcolorG, lcolorB);
            Vector256<float> specular = VectorPacket256.DotProduct(livec, rds.Normalize());
            Vector256<float> specularGraterThanZero = Compare(specular, SetZeroVector256<float>(), FloatComparisonMode.GreaterThanOrderedSignaling);
            var tmpColor2 = VectorUtilities.Pow(specular, scene.Roughness(things)) * light.Color.ToColorPacket256();
            Vector256<float> scolorR = BlendVariable(tmpColor2.Xs, defaultRGB, specularGraterThanZero);
            Vector256<float> scolorG = BlendVariable(tmpColor2.Ys, defaultRGB, specularGraterThanZero);
            Vector256<float> scolorB = BlendVariable(tmpColor2.Zs, defaultRGB, specularGraterThanZero);
            ColorPacket256 scolor = new ColorPacket256(scolorR, scolorG, scolorB);

            colors = colors + ColorPacket256Helper.Times(scene.Diffuse(things, pos), lcolor) + ColorPacket256Helper.Times(scene.Specular(things, pos), scolor);

            colors = new ColorPacket256(BlendVariable(colors.Xs, defaultRGB, isInShadow), BlendVariable(colors.Ys, defaultRGB, isInShadow), BlendVariable(colors.Zs, defaultRGB, isInShadow));

        }
        return colors;
    }

    private ColorPacket256 GetReflectionColor(Vector256<int> things, VectorPacket256 pos, VectorPacket256 norms, VectorPacket256 rds, Scene scene, int depth)
    {
        //return thing.Surface.Reflect(pos) * TraceRay(new RayPacket256(pos, rds), scene, depth + 1);
        return TraceRay(new RayPacket256(pos, rds), scene, depth + 1);
    }

    private VectorPacket256 GetVectorPacket256(Vector256<float> x, Vector256<float> y, Camera camera)
    {
        float widthRate1 = Width / 2.0f;
        float widthRate2 = Width * 2.0f;

        float hightRate1 = Hight / 2.0f;
        float hightRate2 = Hight * 2.0f;

        var recenteredX = Divide(Subtract(x, SetAllVector256(widthRate1)), SetAllVector256(widthRate2));
        var recenteredY = Subtract(SetZeroVector256<float>(), Divide(Subtract(y, SetAllVector256(hightRate1)), SetAllVector256(hightRate2)));

        var result = camera.Forward +
                    (recenteredX * camera.Right) +
                    (recenteredY * camera.Up);

        return result.Normalize();
    }

    internal readonly Scene DefaultScene = CreateDefaultScene();

    private static Scene CreateDefaultScene()
    {
        SceneObject[] things = {
            new Sphere(new Vector(-0.5f, 1f, 1.5f), 0.5f, Surfaces.MatteShiny),
            new Sphere(new Vector(0f, 1f, -0.25f), 1f, Surfaces.Shiny),
            new Plane((new Vector(0, 1, 0)), 0, Surfaces.CheckerBoard)
        };

        Light[] lights = {
            new Light(new Vector(-2f,2.5f,0f),new Color(.5f,.45f,.41f)),
            new Light(new Vector(2,4.5f,2), new Color(.99f,.95f,.8f))
        };

        Camera camera = Camera.Create(new Vector(2.75f, 2f, 3.75f), new Vector(-0.6f, .5f, 0f));

        return new Scene(things, lights, camera);
    }
}