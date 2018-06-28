using static System.Runtime.Intrinsics.X86.Avx;
using System.Runtime.Intrinsics;
using System;

internal static class VectorUtilities
{
    internal static Vector256<float> Pow(Vector256<float> left, Vector256<float> right)
    {
        return left;
    }

}