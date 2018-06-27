using static System.Runtime.Intrinsics.X86.Avx;
using static System.Runtime.Intrinsics.X86.Avx2;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;
using System;

internal class Intersections
{
    public Vector256<float> Distances {get; set;}
    public Vector256<int> ThingIndex  {get; set;}
    // The RayPacket256 is too big to pass through the function, 
    // so we keep it outside the function and use it carefully

    public static readonly float NullValue = float.MaxValue;

    public Intersections(Vector256<float> dis, Vector256<int> things)
    {
        Distances = dis;
        ThingIndex = things;
    }

    public static Intersections Null = new Intersections(SetAllVector256<float>(Intersections.NullValue), SetAllVector256<int>(-1));

    public bool AllNullIntersections()
    {
        var cmp = Compare(Distances, SetAllVector256<float>(Intersections.NullValue), FloatComparisonMode.EqualOrderedNonSignaling);
        var zero = SetZeroVector256<int>();
        var mask = Avx2.CompareEqual(zero, zero);
        return TestC(cmp, StaticCast<int, float>(mask));
    }

    public unsafe int[] WithThings()
    {
        var result = new int[VectorPacket256.Packet256Size];
        fixed (int* ptr = result){
            Store(ptr, ThingIndex);
        }
        return result;
    }
}