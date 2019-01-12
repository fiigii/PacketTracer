// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
//

using System;
using System.Diagnostics;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
//using Microsoft.Xunit.Performance;

//[assembly: OptimizeForBenchmarks]

class Program
{
#if DEBUG

    private const int RunningTime = 200;
    private const int Width = 248;
    private const int Height = 248;
    private const int Iterations = 1;
    private const int MaxIterations = 1000;

#else

    private const int RunningTime = 1000;
    private const int Width = 2480;
    private const int Height = 2480;
    private const int Iterations = 7;
    private const int MaxIterations = 1000;

#endif

    private static int _width, _height;

    public Program()
    {
        _width = Width;
        _height = Height;
    }

    static unsafe int Main(string[] args)
    {
        if (Avx2.IsSupported)
        {
            var r = new Program();
            // We can use `RenderTo` to generate a picture in a PPM file for debugging
            r.RenderTo("./pic.ppm", true);
        }
        return 0;
    }

    private unsafe void RenderTo(string fileName, bool wirteToFile)
    {
        var packetTracer = new Packet256Tracer(_width, _height);
        var scene = packetTracer.DefaultScene;
        var rgb = new int[_width * 3 * _height];
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        fixed (int* ptr = rgb)
        {
            packetTracer.RenderVectorized(scene, ptr);
        }
        stopWatch.Stop();
        TimeSpan ts = stopWatch.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
           ts.Hours, ts.Minutes, ts.Seconds,
           ts.Milliseconds / 10);
        Console.WriteLine("RunTime " + elapsedTime);

        if (wirteToFile)
        {
            using (var file = new System.IO.StreamWriter(fileName))
            {
                file.WriteLine("P3");
                file.WriteLine(_width + " " + _height);
                file.WriteLine("255");

                for (int i = 0; i < _height; i++)
                {
                    for (int j = 0; j < _width; j++)
                    {
                        // Each pixel has 3 fields (RGB)
                        int pos = (i * _width + j) * 3;
                        file.Write(rgb[pos] + " " + rgb[pos + 1] + " " + rgb[pos + 2] + " ");
                    }
                    file.WriteLine();
                }
            }

        }
    }
}
