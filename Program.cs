using System;
using System.Runtime.Intrinsics.X86;

class Program
{
    private const int _width = 248;
    private const int _height = 248;
    static unsafe void Main(string[] args)
    {
        /* 
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
        Avx.Store(outptr, vp.Xs);
        Avx.Store(outptr+8, vp.Ys);
        Avx.Store(outptr+16, vp.Zs);
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
        Avx.Store(outptr3, vp.Xs);
        Avx.Store(outptr3+8, vp.Ys);
        Avx.Store(outptr3+16, vp.Zs);
        for (int i = 0; i < 24; i++)
        {
            Console.Write(outptr3[i] + ",");
        }
        Console.WriteLine();

        var s = new SpherePacket256(new Sphere(new Vector(1, 2, 3), 2.0, Surfaces.Shiny));
        float* outptr4 = stackalloc float[24];
        Avx.Store(outptr4, s.Centers.Xs);
        Avx.Store(outptr4+8, s.Centers.Ys);
        Avx.Store(outptr4+16, s.Centers.Zs);
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
        var inter = s.Intersect(rays);
        Avx.Store(outptr4, inter.Distances);
        for (int i = 0; i < 8; i++)
        {
            Console.Write(outptr4[i] + ",");
        }
        Console.WriteLine();
        Console.WriteLine();
        */
        RenderTo("./pic.ppm");
    }

    private static unsafe void RenderTo(string fileName)
    {
        var packetTracer = new Packet256Tracer(_width, _height);
        var scene = packetTracer.DefaultScene;
        var sphere2 = (Sphere)scene.Things[0];
        var baseY = sphere2.Radius;
        sphere2.Center.Y = sphere2.Radius;

        var rgb = new int[_width * 3 * _height];
        fixed(int* ptr = rgb)
        {
            packetTracer.RenderVectorized(scene, ptr);
        }
        
        var file = new System.IO.StreamWriter(fileName);
        file.WriteLine("P3");
        file.WriteLine(_width + " " + _height);
        file.WriteLine("255");

        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                int pos = i * _height + j;
                file.Write(rgb[pos] + " " + rgb[pos + 1] + " " + rgb[pos + 2] + " ");
            }
            file.WriteLine();
        }
    }
}

