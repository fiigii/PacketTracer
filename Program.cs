// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
//

using System;
using System.Runtime.Intrinsics.X86;

class Program
{
    private const int _width = 2480;
    private const int _height = 2480;
    static unsafe void Main(string[] args)
    {
        var onetwo = Avx.SetAllVector256<float>(1.2f);
        var pone = Avx.SetAllVector256<float>(0.1f);
        VectorMath.Log(onetwo).Display();
        VectorMath.Exp(VectorMath.Log(onetwo)).Display();
        VectorMath.Log(VectorMath.Exp(onetwo)).Display();
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

