using System.Runtime.CompilerServices.Intrinsics.Intel;
using System.Runtime.CompilerServices.Intrinsics;
using System;

internal class Intersections
{
    public Vector256<float> Distances {get; set;}
    public Vector256<float> ThingIndex  {get; set;} 
    // The RayPacket is too big to pass through the function, 
    // so we keep it outside the function and use it carefully

    public static readonly float NullValue = float.MaxValue;

    public Intersections(Vector256<float> dis, Vector256<float> things)
    {
        Distances = dis;
        ThingIndex = things;
    }

    public static Intersections Null = new Intersections(AVX.Set1<float>(Intersections.NullValue), AVX.Set1<float>(-1.0f));

    public bool AllNullIntersections()
    {
        var cmp = AVX.CompareVector256Float(Distances, AVX.Set1<float>(Intersections.NullValue), FloatComparisonMode.CompareEqualOrderedNonSignaling);
        var zero = AVX.SetZero<int>();
        var mask = AVX2.CompareEqual(zero, zero); 
        return AVX.TestC(cmp, AVX.StaticCast<int, float>(mask));
    }

    public unsafe int[] WithThings()
    {
        var indexes = AVX.ConvertToVector256Int(ThingIndex);
        var temArray = new int[VectorPacket.PacketSize];
        fixed (int* ptr = &temArray[0]){
            Store(ptr, indexes);
        }
        return temArray.Distinct().ToArray();
    }
}