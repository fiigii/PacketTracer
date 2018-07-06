// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
//

using System.Runtime.Intrinsics.X86;
using static System.Runtime.Intrinsics.X86.Avx;
using System.Runtime.Intrinsics;

internal sealed class SpherePacket256 : ObjectPacket256
{
    public VectorPacket256 Centers;
    public Vector256<float> Radiuses;

    public SpherePacket256(Sphere sphere) : base(sphere.Surface)
    {
        Centers = new VectorPacket256(SetAllVector256(sphere.Center.X), SetAllVector256(sphere.Center.Y), SetAllVector256(sphere.Center.Z));
        Radiuses = SetAllVector256(sphere.Radius);
    }

    public override VectorPacket256 Normals(VectorPacket256 pos)
    {
        return (pos - Centers).Normalize();
    }

    public override Vector256<float> Intersect(RayPacket256 rayPacket256)
    {
        var eo = Centers - rayPacket256.Starts;
        var v = VectorPacket256.DotProduct(eo, rayPacket256.Dirs);
        var zero = SetZeroVector256<float>();
        var vLessZeroMask = Compare(v, zero, FloatComparisonMode.LessThanOrderedNonSignaling);
        var discs = Subtract(Multiply(Radiuses, Radiuses), Subtract(VectorPacket256.DotProduct(eo, eo), Multiply(v, v)));
        var discLessZeroMask = Compare(discs, zero, FloatComparisonMode.LessThanOrderedNonSignaling);
        var dists = BlendVariable(Subtract(v, Sqrt(discs)), zero, Or(vLessZeroMask, discLessZeroMask));
        var isZero = Compare(dists, zero, FloatComparisonMode.EqualOrderedNonSignaling);
        return BlendVariable(dists, Intersections.NullDistance, isZero);
    }
}