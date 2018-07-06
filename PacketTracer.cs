// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
//

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
    private static readonly int MaxDepth = 0;

    public Packet256Tracer(int _width, int _hight)
    {
        if (_width % VectorPacket256.Packet256Size != 0)
        {
            _width += VectorPacket256.Packet256Size - _width % VectorPacket256.Packet256Size;
        }
        Width = _width;
        Hight = _hight;
    }

    internal unsafe void RenderVectorized(Scene scene, int* rgb)
    {
        Camera camera = scene.Camera;
        for (int y = 0; y < Hight; y++)
        {
            int stride = y * Width;
            for (int x = 0; x < Width; x += VectorPacket256.Packet256Size)
            {
                float fx = (float)x;
                Vector256<float> Xs = SetVector256(fx + 7, fx + 6, fx + 5, fx + 4, fx + 3, fx + 2, fx + 1, fx);
                var dirs = GetVectorPacket256(Xs, SetAllVector256<float>(y), camera);
                var rayPacket256 = new RayPacket256(camera.Pos, dirs);
                var SoAcolors = TraceRay(rayPacket256, scene, 0);

                var AoS = SoAcolors.FastTranspose();
                var intAoS = AoS.ConvertToIntRGB();
                /* 
                SoAcolors.Display();
                Console.WriteLine("AoS");

                AoS.Display();
                Console.WriteLine("Store");
                */



                int* output = &rgb[x + stride];
                {
                    Store(output, GetLowerHalf<int>(intAoS.Rs));
                    Store(output + 4, GetLowerHalf<int>(intAoS.Gs));
                    Store(output + 8, GetLowerHalf<int>(intAoS.Bs));
                    Avx2.ExtractVector128(output + 12, intAoS.Rs, 1);
                    Avx2.ExtractVector128(output + 16, intAoS.Gs, 1);
                    Avx2.ExtractVector128(output + 20, intAoS.Bs, 1);
                }
                /* 
                var AoS = SoAcolors.Transpose();
                var intAoS = AoS.ConvertToIntRGB();

                int* output = &rgb[x + stride];
                {
                    Store(output, intAoS.Rs);
                    Store(output + 8, intAoS.Gs);
                    Store(output + 16, intAoS.Bs);
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
        var color = Shade(isect, rayPacket256, scene, depth);
        var isNull = Compare(isect.Distances, Intersections.NullDistance, FloatComparisonMode.EqualOrderedNonSignaling);
        var backgroundColor = ColorPacket256Helper.BackgroundColor.Xs;
        return new ColorPacket256(BlendVariable(color.Xs, backgroundColor, isNull),
                                  BlendVariable(color.Ys, backgroundColor, isNull),
                                  BlendVariable(color.Xs, backgroundColor, isNull));
    }

    private Vector256<float> TestRay(RayPacket256 rayPacket256, Scene scene)
    {
        var isect = MinIntersections(rayPacket256, scene);
        if (isect.AllNullIntersections())
        {
            return SetZeroVector256<float>();
        }
        var isNull = Compare(isect.Distances, Intersections.NullDistance, FloatComparisonMode.EqualOrderedNonSignaling);
        return BlendVariable(isect.Distances, SetZeroVector256<float>(), isNull);
    }

    private Intersections MinIntersections(RayPacket256 rayPacket256, Scene scene)
    {
        Intersections mins = new Intersections(Intersections.NullDistance, Intersections.NullIndex);
        for (int i = 0; i < scene.Things.Length; i++)
        {
            Vector256<float> distance = scene.Things[i].ToPacket256().Intersect(rayPacket256);

            if (!Intersections.AllNullIntersections(distance))
            {
                var notNullMask = Compare(distance, Intersections.NullDistance, FloatComparisonMode.NotEqualOrderedNonSignaling);
                var nullMinMask = Compare(mins.Distances, Intersections.NullDistance, FloatComparisonMode.EqualOrderedNonSignaling);

                var lessMinMask = Compare(mins.Distances, distance, FloatComparisonMode.GreaterThanOrderedNonSignaling);
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
        var reflectDirs = ds - (Multiply(VectorPacket256.DotProduct(normals, ds), SetAllVector256<float>(2)) * normals);
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
        for (int i = 0; i < scene.Lights.Length; i++)
        {
            var light = scene.Lights[i];
            var colorPacket = light.Color.ToColorPacket256();
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
            var tmpColor1 = illum * colorPacket;
            var defaultRGB = SetZeroVector256<float>();
            Vector256<float> lcolorR = BlendVariable(defaultRGB, tmpColor1.Xs, illumGraterThanZero);
            Vector256<float> lcolorG = BlendVariable(defaultRGB, tmpColor1.Ys, illumGraterThanZero);
            Vector256<float> lcolorB = BlendVariable(defaultRGB, tmpColor1.Zs, illumGraterThanZero);
            ColorPacket256 lcolor = new ColorPacket256(lcolorR, lcolorG, lcolorB);
            
            Vector256<float> specular = VectorPacket256.DotProduct(livec, rds.Normalize());
            Vector256<float> specularGraterThanZero = Compare(specular, SetZeroVector256<float>(), FloatComparisonMode.GreaterThanOrderedNonSignaling);
            
            var difColor = new ColorPacket256(1, 1, 1);
            var splColor = new ColorPacket256(1, 1, 1);
            var roughness = SetAllVector256<float>(1);

            for (int j = 0; j < scene.Things.Length; j++)
            {
                Vector256<float> thingMask = StaticCast<int, float>(CompareEqual(things, SetAllVector256<int>(j)));
                var rgh = SetAllVector256<float>(scene.Things[j].Surface.Roughness);
                var dif = scene.Things[j].Surface.Diffuse(pos);
                var spl = scene.Things[j].Surface.Specular(pos);

                roughness = BlendVariable(roughness, rgh, thingMask);

                difColor.Xs = BlendVariable(difColor.Xs, dif.Xs, thingMask);
                difColor.Ys = BlendVariable(difColor.Ys, dif.Ys, thingMask);
                difColor.Zs = BlendVariable(difColor.Zs, dif.Zs, thingMask);

                splColor.Xs = BlendVariable(splColor.Xs, spl.Xs, thingMask);
                splColor.Ys = BlendVariable(splColor.Ys, spl.Ys, thingMask);
                splColor.Zs = BlendVariable(splColor.Zs, spl.Zs, thingMask);
            }

            var tmpColor2 = VectorUtilities.Pow(specular, roughness) * colorPacket;
            Vector256<float> scolorR = BlendVariable(defaultRGB, tmpColor2.Xs, specularGraterThanZero);
            Vector256<float> scolorG = BlendVariable(defaultRGB, tmpColor2.Ys, specularGraterThanZero);
            Vector256<float> scolorB = BlendVariable(defaultRGB, tmpColor2.Zs, specularGraterThanZero);
            ColorPacket256 scolor = new ColorPacket256(scolorR, scolorG, scolorB);

            var oldColor = colors;

            colors = colors + ColorPacket256Helper.Times(difColor, lcolor) + ColorPacket256Helper.Times(splColor, scolor);

            colors = new ColorPacket256(BlendVariable(colors.Xs, oldColor.Xs, isInShadow), BlendVariable(colors.Ys, oldColor.Ys, isInShadow), BlendVariable(colors.Zs, oldColor.Zs, isInShadow));

        }
        return colors;
    }

    private ColorPacket256 GetReflectionColor(Vector256<int> things, VectorPacket256 pos, VectorPacket256 norms, VectorPacket256 rds, Scene scene, int depth)
    {
        return scene.Reflect(things, pos) * TraceRay(new RayPacket256(pos, rds), scene, depth + 1);
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

        Camera camera = Camera.Create(new VectorPacket256(2.75f, 2f, 3.75f), new VectorPacket256(-0.6f, .5f, 0f));

        return new Scene(things, lights, camera);
    }
}