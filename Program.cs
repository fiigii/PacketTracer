using System;
using System.Runtime.Intrinsics.X86;

class Program
{
    static unsafe void Main(string[] args)
    {
        float* ptr = stackalloc float[24];
        for (int i = 0; i < 24; i++)
        {
            ptr[i] = i + 1;
            Console.Write(ptr[i] + ",");
        }
        Console.WriteLine();
        var vp = new VectorPacket256(ptr);
        vp = (vp + vp) / (new VectorPacket256(Avx.SetAllVector256<float>(2.0f)));

        float* outptr = stackalloc float[24];
        Avx.Store(outptr, vp.xs);
        Avx.Store(outptr+8, vp.ys);
        Avx.Store(outptr+16, vp.zs);
        for (int i = 0; i < 24; i++)
        {
            Console.Write(outptr[i] + ",");
        }
        Console.WriteLine();

        var onePack = new VectorPacket256(new Vector(1, 1, 1));
        var result = vp.Lengths;

        float* outptr2 = stackalloc float[8];
        Avx.Store(outptr2, result);
        for (int i = 0; i < 8; i++)
        {
            Console.Write(outptr2[i] + ",");
        }
        Console.WriteLine();

        vp = vp.Normalize();
        float* outptr3 = stackalloc float[24];
        Avx.Store(outptr3, vp.xs);
        Avx.Store(outptr3+8, vp.ys);
        Avx.Store(outptr3+16, vp.zs);
        for (int i = 0; i < 24; i++)
        {
            Console.Write(outptr3[i] + ",");
        }
        Console.WriteLine();

        var s = new SpherePacket256(new Sphere(new Vector(1, 2, 3), 2.0, Surfaces.Shiny));
        float* outptr4 = stackalloc float[24];
        Avx.Store(outptr4, s.Centers.xs);
        Avx.Store(outptr4+8, s.Centers.ys);
        Avx.Store(outptr4+16, s.Centers.zs);
        for (int i = 0; i < 24; i++)
        {
            Console.Write(outptr4[i] + ",");
        }
        Console.WriteLine();

        Avx.Store(outptr4, s.Radiuses);
        for (int i = 0; i < 8; i++)
        {
            Console.Write(outptr4[i] + ",");
        }
        Console.WriteLine();

        var rays = new RayPacket256(vp, new VectorPacket256(new Vector(2, 10, 1)));
        var inter = s.Intersect(rays, 0);
        Avx.Store(outptr4, inter.Distances);
        for (int i = 0; i < 8; i++)
        {
            Console.Write(outptr4[i] + ",");
        }
        Console.WriteLine();
        int* intout = stackalloc int[8];
        Avx.Store(intout, inter.ThingIndex);
        for (int i = 0; i < 8; i++)
        {
            Console.Write(intout[i] + ",");
        }
        Console.WriteLine();
    }
}

