using static System.Runtime.Intrinsics.X86.Avx;
using static System.Runtime.Intrinsics.X86.Avx2;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;
using System;

internal class Intersections
{
    public Vector256<float> Distances {get; set;}
    public SceneObject Thing {get; set;}
    // The RayPacket256 is too big to pass through the function, 
    // so we keep it outside the function and use it carefully

    public static readonly float NullValue = 0f;

    public Intersections(Vector256<float> dis, SceneObject thing)
    {
        Distances = dis;
        Thing = thing;
    }

    public static Intersections Null = new Intersections(SetAllVector256<float>(Intersections.NullValue), null);

    public bool AllNullIntersections()
    {
        var cmp = Compare(Distances, SetAllVector256<float>(Intersections.NullValue), FloatComparisonMode.EqualOrderedNonSignaling);
        var zero = SetZeroVector256<int>();
        var mask = Avx2.CompareEqual(zero, zero);
        return TestC(cmp, StaticCast<int, float>(mask));
    }
}