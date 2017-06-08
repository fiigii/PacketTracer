using System.Runtime.Compilexservices.Intrinsics.Intel;
using System.Runtime.Compilexservices.Intrinsics;
using System;

internal struct Intersections
{
    public Vector256<float> tpoint {get; private set;}
    public Vector256<float> index {get; private set;}
}