// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
//

using static System.Runtime.Intrinsics.X86.Avx;
using static System.Runtime.Intrinsics.X86.Avx2;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;
using System.Runtime.CompilerServices;
using System;

public static class VectorDXMath
{
    private static readonly Vector256<float> One = SetAllVector256<float>(1.0f);
    private static readonly Vector256<int> ExponentBias = SetAllVector256<int>(127);
    private static readonly Vector256<int> SubnormalExponent = SetAllVector256<int>(-126);
    private static readonly Vector256<int> NegativeZero = StaticCast<uint, int>(SetAllVector256<uint>(0x80000000));
    private static readonly Vector256<int> E253 = SetAllVector256<int>(253);
    private static readonly Vector256<float> QNaN = StaticCast<uint, float>(SetAllVector256<uint>(0x7FC00000));
    private static readonly Vector256<float> QNaNTest = StaticCast<uint, float>(SetAllVector256<uint>(0x007FFFFF));
    private static readonly Vector256<float> NegQNaN = StaticCast<uint, float>(SetAllVector256<uint>(0xFFC00000));
    private static readonly Vector256<float> Bin128 = StaticCast<uint, float>(SetAllVector256<uint>(0x43000000));
    private static readonly Vector256<int> BinNeg150 = StaticCast<uint, int>(SetAllVector256<uint>(0xC3160000));
    private static readonly Vector256<int> MinNormal = SetAllVector256<int>(0x00800000);
    private static readonly Vector256<int> NumTrailing = SetAllVector256<int>(23);
    private static readonly Vector256<float> Infinity = StaticCast<int, float>(SetAllVector256<int>(0x7F800000));
    private static readonly Vector256<float> AbsMask = StaticCast<uint, float>(SetAllVector256<uint>(0x7FFFFFFF));
    private static readonly Vector256<float> ExpEst1 = SetAllVector256<float>(-6.93147182e-1f);
    private static readonly Vector256<float> ExpEst2 = SetAllVector256<float>(+2.40226462e-1f);
    private static readonly Vector256<float> ExpEst3 = SetAllVector256<float>(-5.55036440e-2f);
    private static readonly Vector256<float> ExpEst4 = SetAllVector256<float>(+9.61597636e-3f);
    private static readonly Vector256<float> ExpEst5 = SetAllVector256<float>(-1.32823968e-3f);
    private static readonly Vector256<float> ExpEst6 = SetAllVector256<float>(+1.47491097e-4f);
    private static readonly Vector256<float> ExpEst7 = SetAllVector256<float>(-1.08635004e-5f);
    private static readonly Vector256<float> LogEst0 = SetAllVector256<float>(+1.442693f);
    private static readonly Vector256<float> LogEst1 = SetAllVector256<float>(-0.721242f);
    private static readonly Vector256<float> LogEst2 = SetAllVector256<float>(+0.479384f);
    private static readonly Vector256<float> LogEst3 = SetAllVector256<float>(-0.350295f);
    private static readonly Vector256<float> LogEst4 = SetAllVector256<float>(+0.248590f);
    private static readonly Vector256<float> LogEst5 = SetAllVector256<float>(-0.145700f);
    private static readonly Vector256<float> LogEst6 = SetAllVector256<float>(+0.057148f);
    private static readonly Vector256<float> LogEst7 = SetAllVector256<float>(-0.010578f);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector256<float> Pow(Vector256<float> left, Vector256<float> right)
    {
        //return Exp(Multiply(right, Log(left)));
        return left;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector256<float> Exp(Vector256<float> value)
    {
        Vector256<float> ftrunc = Floor(value);
        Vector256<float> y = Subtract(value, ftrunc);
        Vector256<float> poly = Multiply(ExpEst7, y);
        poly = Multiply(Add(ExpEst6, poly), y);
        poly = Multiply(Add(ExpEst5, poly), y);
        poly = Multiply(Add(ExpEst4, poly), y);
        poly = Multiply(Add(ExpEst3, poly), y);
        poly = Multiply(Add(ExpEst2, poly), y);
        poly = Multiply(Add(ExpEst1, poly), y);
        poly = Add(One, poly);

        Vector256<int> itrunc = ConvertToVector256Int32WithTruncation(value);
        Vector256<int> biased = Add(itrunc, ExponentBias);
        biased = ShiftLeftLogical(biased, 23);
        Vector256<float> result0 = Divide(StaticCast<int, float>(biased), poly);

        biased = Add(itrunc, E253);
        biased = ShiftLeftLogical(biased, 23);
        Vector256<float> result1 = Divide(StaticCast<int, float>(biased), poly);
        result1 = Multiply(StaticCast<int, float>(MinNormal), result1);

        Vector256<float> comp = Compare(value, Bin128, FloatComparisonMode.LessThanOrderedNonSignaling);
        Vector256<float> result2 = BlendVariable(Infinity, result0, comp);

        comp = StaticCast<int, float>(CompareGreaterThan(SubnormalExponent, itrunc));
        Vector256<float> result3 = BlendVariable(result0, result1, comp);

        comp = StaticCast<int, float>(CompareGreaterThan(BinNeg150, StaticCast<float, int>(value)));
        Vector256<float> result4 = BlendVariable(SetZeroVector256<float>(), result3, comp);

        Vector256<int> sign = And(StaticCast<float, int>(value), NegativeZero);
        comp = StaticCast<int, float>(Avx2.CompareEqual(sign, NegativeZero));
        Vector256<float> result5 = BlendVariable(result2, result4, comp);

        Vector256<float> t0 = And(value, QNaNTest);
        Vector256<float> t1 = And(value, Infinity);
        t0 = CompareEqual(t0, SetZeroVector256<float>());
        t1 = CompareEqual(t1, Infinity);
        Vector256<float> isNaN = AndNot(t0, t1);

        return BlendVariable(result5, QNaN, isNaN);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector256<float> Log(Vector256<float> value)
    {
        Vector256<int> rawBiased = StaticCast<float, int>(And(value, Infinity));
        Vector256<float> trailing = And(value, QNaNTest);
        Vector256<float> isExponentZero = CompareEqual(SetZeroVector256<float>(), StaticCast<int, float>(rawBiased));

        Vector256<int> biased = ShiftRightLogical(rawBiased, 23);
        Vector256<float> exponentNor = StaticCast<int, float>(Subtract(biased, ExponentBias));
        Vector256<float> trailingNor = trailing;

        Vector256<int> leading = GetLeadingBit(trailing);
        Vector256<int> shift = Subtract(NumTrailing, leading);
        Vector256<float> exponentSub = StaticCast<int, float>(Subtract(SubnormalExponent, shift));
        Vector256<float> trailingSub = MultiSll(trailing, shift);
        trailingSub = And(trailingSub, QNaNTest);
        Vector256<float> e = BlendVariable(exponentNor, exponentSub, isExponentZero);
        Vector256<float> t = BlendVariable(trailingNor, trailingSub, isExponentZero);

        Vector256<float> y = Subtract(Or(One, t), One);
        Vector256<float> log2 = Multiply(LogEst7, y);
        log2 = Multiply(Add(LogEst6, log2), y);
        log2 = Multiply(Add(LogEst5, log2), y);
        log2 = Multiply(Add(LogEst4, log2), y);
        log2 = Multiply(Add(LogEst3, log2), y);
        log2 = Multiply(Add(LogEst2, log2), y);
        log2 = Multiply(Add(LogEst1, log2), y);
        log2 = Multiply(Add(LogEst0, log2), y);
        log2 = Add(log2, ConvertToVector256Single(StaticCast<float, int>(e)));

        Vector256<float> isInfinite = And(value, AbsMask);
        isInfinite = CompareEqual(isInfinite, Infinity);

        Vector256<float> isGreaterZero = Compare(value, SetZeroVector256<float>(), FloatComparisonMode.GreaterThanOrderedNonSignaling);
        Vector256<float> isNotFinite = StaticCast<int, float>(CompareGreaterThan(StaticCast<float, int>(value), StaticCast<float, int>(Infinity)));
        Vector256<float> isPositive = AndNot(isNotFinite, isGreaterZero);
        Vector256<float> isZero = CompareEqual(And(value, AbsMask), SetZeroVector256<float>());

        Vector256<float> t0 = And(value, QNaNTest);
        Vector256<float> t1 = And(value, Infinity);
        t0 = CompareEqual(t0, SetZeroVector256<float>());
        t1 = CompareEqual(t1, Infinity);
        Vector256<float> isNaN = AndNot(t0, t1);

        Vector256<float> result = BlendVariable(log2, Infinity, isInfinite);
        Vector256<float> tmp = BlendVariable(NegQNaN, Infinity, isZero); 
        result = BlendVariable(tmp, result, isPositive);
        return BlendVariable(result, QNaN, isNaN);
    }

    private static readonly Vector256<int> Vffff = SetAllVector256(0x0000FFFF);
    private static readonly Vector256<int> Vff = SetAllVector256(0x000000FF);
    private static readonly Vector256<int> Vf = SetAllVector256(0x0000000F);
    private static readonly Vector256<int> Vthree = SetAllVector256(0x00000003);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Vector256<int> GetLeadingBit(Vector256<float> value)
    {
        Vector256<int> v = StaticCast<float, int>(value);
        Vector256<int> c = CompareGreaterThan(v, Vffff);
        Vector256<int> b = ShiftRightLogical(c, 31);
        Vector256<int> r = ShiftLeftLogical(b, 4);
        return v;

    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Vector256<float> MultiSll(Vector256<float> value, Vector256<int> count)
    {
        return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Vector256<int> MultiSrl(Vector256<int> value, Vector256<int> count)
    {
        return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Vector256<float> CompareEqual(Vector256<float> left, Vector256<float> right)
    {
        return StaticCast<int, float>(Avx2.CompareEqual(StaticCast<float, int>(left), StaticCast<float, int>(right)));
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