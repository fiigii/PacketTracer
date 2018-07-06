// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
//

using static System.Runtime.Intrinsics.X86.Avx;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;
using System.Runtime.CompilerServices;
using System;

public static class VectorMath
{
    static readonly Vector256<float> MaxValue = SetAllVector256<float>(88.0f);
    static readonly Vector256<float> MinValue = SetAllVector256<float>(-88.0f);
    static readonly Vector256<float> CephesLog2 = SetAllVector256<float>(1.44269502f);
    static readonly Vector256<float> CephesC1 = SetAllVector256<float>(0.693359375f);
    static readonly Vector256<float> CephesC2 = SetAllVector256<float>(-0.0002121944417f);
    static readonly Vector256<float> CephesP0 = SetAllVector256<float>(0.0001987569121f);
    static readonly Vector256<float> CephesP1 = SetAllVector256<float>(0.001398199936f);
    static readonly Vector256<float> CephesP2 = SetAllVector256<float>(0.008333452046f);
    static readonly Vector256<float> CephesP3 = SetAllVector256<float>(0.04166579619f);
    static readonly Vector256<float> CephesP4 = SetAllVector256<float>(0.1666666567f);
    static readonly Vector256<float> Point5 = SetAllVector256<float>(0.5f);
    static readonly Vector256<float> One = SetAllVector256<float>(1.0f);
    static readonly Vector256<int> Ox7 = SetAllVector256<int>(127);
    public static Vector256<float> Pow(Vector256<float> left, Vector256<float> right)
    {
        return left;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector256<float> Exp(Vector256<float> value)
    {
        value = Min(value, MaxValue);
        value = Max(value, MinValue);
        Vector256<float> fx = Multiply(value, CephesLog2);
        fx = Floor(Add(fx, Point5));

        Vector256<float> tmp = Multiply(fx, CephesC1);
        Vector256<float> z = Multiply(fx, CephesC2);
        Vector256<float> x = Subtract(value, tmp);
        x = Subtract(x, z);
        z = Multiply(x, x);
        Vector256<float> y = CephesP0;
        y = Add(Multiply(y, x), CephesP1);
        y = Add(Multiply(y, x), CephesP2);
        y = Add(Multiply(y, x), CephesP3);
        y = Add(Multiply(y, x), CephesP4);
        y = Add(Multiply(y, x), Point5);
        y = Add(Add(Multiply(y, z), x), One);

        Vector256<int> pow2n = ConvertToVector256Int32(fx);
        pow2n = Avx2.Add(pow2n, Ox7);
        pow2n = Avx2.ShiftLeftLogical(pow2n, 23);

        return Multiply(y, StaticCast<int, float>(pow2n));
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