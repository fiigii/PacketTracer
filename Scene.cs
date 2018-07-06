
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
        VectorPacket256 norms = new VectorPacket256(1, 1, 1);

        for (int i = 0; i < Things.Length; i++)
        {
            Vector256<float> mask = StaticCast<int, float>(CompareEqual(things, SetAllVector256<int>(i)));
            var n = Things[i].ToPacket256().Normals(pos);
            norms.Xs = BlendVariable(norms.Xs, n.Xs, mask);
            norms.Ys = BlendVariable(norms.Ys, n.Ys, mask);
            norms.Zs = BlendVariable(norms.Zs, n.Zs, mask);
        }

        return norms;
    }

    public Vector256<float> Reflect(Vector256<int> things, VectorPacket256 pos)
    {
        Vector256<float> rfl =  SetAllVector256<float>(1);
        for (int i = 0; i < Things.Length; i++)
        {
            Vector256<float> mask = StaticCast<int, float>(CompareEqual(things, SetAllVector256<int>(i)));
            rfl = BlendVariable(rfl, Things[i].Surface.Reflect(pos), mask);
        }
        return rfl;
    }

}