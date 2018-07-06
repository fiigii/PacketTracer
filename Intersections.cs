using static System.Runtime.Intrinsics.X86.Avx;
using static System.Runtime.Intrinsics.X86.Avx2;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;
using System.Runtime.CompilerServices;
using System;

internal struct Intersections
{
    public Vector256<float> Distances;
    public Vector256<int> ThingIndeces;

    public static readonly Vector256<float> NullDistance = SetAllVector256<float>(float.MaxValue);
    public static readonly Vector256<int> NullIndex = SetAllVector256<int>(-1);

    public Intersections(Vector256<float> dis, Vector256<int> things)
    {
        Distances = dis;
        ThingIndeces = things;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool AllNullIntersections()
    {
        return AllNullIntersections(Distances);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool AllNullIntersections(Vector256<float> dis)
    {
        var cmp = Compare(dis, NullDistance, FloatComparisonMode.EqualOrderedNonSignaling);
        var zero = SetZeroVector256<int>();
        var mask = Avx2.CompareEqual(zero, zero);
        return TestC(cmp, StaticCast<int, float>(mask));
    }

    
}