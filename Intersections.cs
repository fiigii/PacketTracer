using System.Runtime.CompilerServices.Intrinsics.Intel;
using System.Runtime.CompilerServices.Intrinsics;
using System;

internal class Intersections
{
    public Vector256<float> Distances {get; set;}
    public SceneObject Thing  {get; private set;}
    // The RayPacket is too big to pass through the function, 
    // so we keep it outside the function and use it carefully

    public static readonly float Null = float.MaxValue;

    public Intersections(Vector256<float> dis, SceneObject thing)
    {
        Distances = dis;
        Thing = thing;
    }

    public static Intersections NullIntersections(SceneObject thing)
    {
        return Intersections(AVX.Set1<float>(Intersections.Null), thing);
    }

    public bool AllNullIntersections()
    {
        var cmp = AVX.CompareVector256Float(Distances, AVX.Set1<float>(Intersections.Null), CompareEqualOrderedNonSignaling);
        var mask = AVX.CompareVector256Float(Distances, Distances, CompareNotEqualUnorderedNonSignaling); //Not efficient 
        return AVX.TestC(cmp, mask);
    }
}