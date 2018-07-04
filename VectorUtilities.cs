using static System.Runtime.Intrinsics.X86.Avx;
using System.Runtime.Intrinsics;
using System;

internal static class VectorUtilities
{
    internal static Vector256<float> Pow(Vector256<float> left, Vector256<float> right)
    {
        return left;
    }

    internal unsafe static void Display(this Vector256<float> v)
    {
        float[] buffer = new float[8];
        fixed(float* ptr = buffer)
        {
            Store(ptr, v);
        }
        foreach (var item in buffer)
        {
            Console.Write(item + ", ");
        }
        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------------");
    }

    internal unsafe static void Display(this Vector256<int> v)
    {
        int[] buffer = new int[8];
        fixed(int* ptr = buffer)
        {
            Store(ptr, v);
        }
        foreach (var item in buffer)
        {
            Console.Write(item + ", ");
        }
        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------------");
    }

}