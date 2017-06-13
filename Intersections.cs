using System.Runtime.CompilerServices.Intrinsics.Intel;
using System.Runtime.CompilerServices.Intrinsics;
using System;

internal class Intersections
{
    public Vector256<float> Distances {get; set;}
    public Vector256<int> ThingIndex  {get; set;} 
    // The RayPacket is too big to pass through the function, 
    // so we keep it outside the function and use it carefully

    public static readonly float Null = float.MaxValue;

    public Intersections(Vector256<float> dis, Vector256<int> things)
    {
        Distances = dis;
        ThingIndex = things;
    }

    public static Intersections Null = new Intersections(AVX.Set1<float>(Intersections.Null), AVX.Set1<int>(-1));

    public bool AllNullIntersections()
    {
        var cmp = AVX.CompareVector256Float(Distances, AVX.Set1<float>(Intersections.Null), CompareEqualOrderedNonSignaling);
        var mask = AVX.CompareVector256Float(Distances, Distances, CompareEqualOrderedNonSignaling); //Not efficient 
        return AVX.TestC(cmp, mask);
    }
}