using System.Runtime.Intrinsics.X86;
using static System.Runtime.Intrinsics.X86.Avx;
using System.Runtime.Intrinsics;

internal sealed class PlanePacket256 : ObjectPacket256
{
    public VectorPacket256 Norms;
    public Vector256<float> Offsets;

    public PlanePacket256(Plane plane) : base(plane.Surface)
    {
        Norms = new VectorPacket256(SetAllVector256(plane.Norm.X), SetAllVector256(plane.Norm.Y), SetAllVector256(plane.Norm.Z));
        Offsets = SetAllVector256(plane.Offset);
    }

    public override VectorPacket256 Normals(VectorPacket256 pos)
    {
        return Norms;
    }

    public override Vector256<float> Intersect(RayPacket256 rayPacket256)
    {
        var denom = VectorPacket256.DotProduct(Norms, rayPacket256.Dirs);
        var dist = Divide(Add(VectorPacket256.DotProduct(Norms, rayPacket256.Starts), Offsets), Subtract(SetZeroVector256<float>(), denom));
        var gtMask = Compare(denom, SetZeroVector256<float>(), FloatComparisonMode.GreaterThanOrderedNonSignaling);
        return BlendVariable(dist, Intersections.NullDistance, gtMask);
    }
}