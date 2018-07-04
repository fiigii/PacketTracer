using static System.Runtime.Intrinsics.X86.Avx;
using static System.Runtime.Intrinsics.X86.Avx2;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;
using System;

internal struct Intersections
{
    public Vector256<float> Distances {get; set;}
    public Vector256<int> ThingIndeces {get; set;}

    private static readonly float NullDistance = float.MaxValue;
    private static readonly int NullIndex = -1;

    public Intersections(Vector256<float> dis, Vector256<int> things)
    {
        Distances = dis;
        ThingIndeces = things;
    }

    //public static Intersections Null { get {return new Intersections(SetAllVector256<float>(Intersections.NullValue), null);}}
    public readonly static Intersections Null = new Intersections(SetAllVector256<float>(Intersections.NullDistance), 
                                                                  SetAllVector256<int>(Intersections.NullIndex));

    public bool AllNullIntersections()
    {
        return AllNullIntersections(Distances);
    }

    public static bool AllNullIntersections(Vector256<float> dis)
    {
        var cmp = Compare(dis, Null.Distances, FloatComparisonMode.EqualOrderedSignaling);
        var zero = SetZeroVector256<int>();
        var mask = Avx2.CompareEqual(zero, zero);
        return TestC(cmp, StaticCast<int, float>(mask));
    }

    
}