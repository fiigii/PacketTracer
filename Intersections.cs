using System.Runtime.CompilerServices.Intrinsics.X86;
using System.Runtime.CompilerServices.Intrinsics;
using System;

internal class Intersections
{
    public Vector256<float> Distances {get; set;}
    public Vector256<int> ThingIndex  {get; set;} 
    // The RayPacket is too big to pass through the function, 
    // so we keep it outside the function and use it carefully

    public static readonly float NullValue = float.MaxValue;

    public Intersections(Vector256<float> dis, Vector256<int> things)
    {
        Distances = dis;
        ThingIndex = things;
    }

    public static Intersections Null = new Intersections(AVX.Set1<float>(Intersections.NullValue), AVX.Set1<int>(-1));

    public bool AllNullIntersections()
    {
        var cmp = AVX.CompareVector256(Distances, AVX.Set1<float>(Intersections.NullValue), FloatComparisonMode.CompareEqualOrderedNonSignaling);
        var zero = AVX.SetZero<int>();
        var mask = AVX2.CompareEqual(zero, zero); 
        return AVX.TestC(cmp, AVX.StaticCast<int, float>(mask));
    }

    public unsafe int[] WithThings()
    {
        var result = new int[VectorPacket.PacketSize];
        fixed (int* ptr = result){
            AVX.Store(ptr, ThingIndex);
        }
        return result;
    }
}