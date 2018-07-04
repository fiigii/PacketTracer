
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using static System.Runtime.Intrinsics.X86.Avx;
using static System.Runtime.Intrinsics.X86.Avx2;
using System.Runtime.Intrinsics;
using System;

internal class Scene
{
    public SceneObject[] Things;
    public Light[] Lights;
    public Camera Camera;

    public Scene(SceneObject[] things, Light[] lights, Camera camera) { Things = things; Lights = lights; Camera = camera; }

    public VectorPacket256 Normals(Vector256<int> things, VectorPacket256 pos)
    {
        Vector256<float> normXs = SetZeroVector256<float>();
        Vector256<float> normYs = SetZeroVector256<float>();
        Vector256<float> normZs = SetZeroVector256<float>();

        for (int i = 0; i < Things.Length; i++)
        {
            Vector256<float> mask = StaticCast<int, float>(CompareEqual(things, SetAllVector256<int>(i)));
            var norms = Things[i].ToPacket256().Normals(pos);
            normXs = BlendVariable(normXs, norms.Xs, mask);
            normYs = BlendVariable(normYs, norms.Ys, mask);
            normZs = BlendVariable(normZs, norms.Zs, mask);
        }

        return new VectorPacket256(normXs, normYs, normZs);
    }

    public Vector256<float> Roughness(Vector256<int> things)
    {
        Vector256<float> rgh =  SetZeroVector256<float>();
        for (int i = 0; i < Things.Length; i++)
        {
            Vector256<float> mask = StaticCast<int, float>(CompareEqual(things, SetAllVector256<int>(i)));
            rgh = BlendVariable(rgh, SetAllVector256<float>(Things[i].Surface.Roughness), mask);
        }
        return rgh;
    }

    public Vector256<float> Reflect(Vector256<int> things, VectorPacket256 pos)
    {
        Vector256<float> rfl =  SetZeroVector256<float>();
        for (int i = 0; i < Things.Length; i++)
        {
            Vector256<float> mask = StaticCast<int, float>(CompareEqual(things, SetAllVector256<int>(i)));
            rfl = BlendVariable(rfl, Things[i].Surface.Reflect(pos), mask);
        }
        return rfl;
    }

    public VectorPacket256 Specular(Vector256<int> things, VectorPacket256 pos)
    {
        Vector256<float> splXs =  SetZeroVector256<float>();
        Vector256<float> splYs =  SetZeroVector256<float>();
        Vector256<float> splZs =  SetZeroVector256<float>();
        for (int i = 0; i < Things.Length; i++)
        {
            Vector256<float> mask = StaticCast<int, float>(CompareEqual(things, SetAllVector256<int>(i)));
            var spl = Things[i].Surface.Specular(pos);
            splXs = BlendVariable(splXs, spl.Xs, mask);
            splYs = BlendVariable(splYs, spl.Ys, mask);
            splZs = BlendVariable(splZs, spl.Zs, mask);
        }
        return new VectorPacket256(splXs, splYs, splZs);
    }

    public VectorPacket256 Diffuse(Vector256<int> things, VectorPacket256 pos)
    {
        Vector256<float> difXs =  SetZeroVector256<float>();
        Vector256<float> difYs =  SetZeroVector256<float>();
        Vector256<float> difZs =  SetZeroVector256<float>();
        for (int i = 0; i < Things.Length; i++)
        {
            Vector256<float> mask = StaticCast<int, float>(CompareEqual(things, SetAllVector256<int>(i)));
            var dif = Things[i].Surface.Diffuse(pos);
            difXs = BlendVariable(difXs, dif.Xs, mask);
            difYs = BlendVariable(difYs, dif.Ys, mask);
            difZs = BlendVariable(difZs, dif.Zs, mask);
        }
        return new VectorPacket256(difXs, difYs, difZs);
    }

}