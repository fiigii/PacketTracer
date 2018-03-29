using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;

internal class PlanePacket256: ObjectPacket256
{
    public VectorPacket256 Norms {get; private set;}
    public Vector256<float> Offsets {get; private set;}

    public PlanePacket256(Plane plane): base(plane.Surface)
    {
        Norms = new VectorPacket256(Avx.SetAllVector256(plane.Norm.X), Avx.SetAllVector256(plane.Norm.Y), Avx.SetAllVector256(plane.Norm.Z));
        Offsets = Avx.SetAllVector256(plane.Offset);
    }

    public override Intersections Intersect(RayPacket256 rayPacket256, int index)
    {
        var denom = VectorPacket256.DotProduct(Norms, rayPacket256.Dirs);
        var dist = Avx.Divide(VectorPacket256.DotProduct(Norms, rayPacket256.Starts), Avx.Subtract(Avx.SetZeroVector256<float>(), denom));
        var gtMask = Avx.Compare(denom, Avx.SetZeroVector256<float>(), FloatComparisonMode.GreaterThanOrderedNonSignaling);
        var reslut = Avx.Or(Avx.And(gtMask, Avx.SetAllVector256(Intersections.NullValue)), Avx.AndNot(gtMask, dist));
        return new Intersections(reslut, Avx.SetAllVector256<int>(index));
    }

    public override VectorPacket256 Normal(VectorPacket256 pos)
    {
        return Norms;
    }
}