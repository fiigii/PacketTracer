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
        var cmp = AVX.CompareVector256Float(Distances, AVX.Set1<float>(Intersections.NullValue), CompareEqualOrderedNonSignaling);
        var mask = AVX.CompareVector256Float(Distances, Distances, CompareEqualOrderedNonSignaling); //Not efficient 
        return AVX.TestC(cmp, mask);
    }
}