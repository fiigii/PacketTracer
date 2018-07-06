using System.Runtime.Intrinsics.X86;
using static System.Runtime.Intrinsics.X86.Avx;
using System.Runtime.Intrinsics;

internal class SpherePacket256 : ObjectPacket256
{
    public VectorPacket256 Centers { get; private set; }
    public Vector256<float> Radiuses { get; private set; }


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