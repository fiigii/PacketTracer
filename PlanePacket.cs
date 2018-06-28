using System.Runtime.Intrinsics.X86;
using static System.Runtime.Intrinsics.X86.Avx;
using System.Runtime.Intrinsics;

internal class PlanePacket256: ObjectPacket256
{
    public VectorPacket256 Norms {get; private set;}
    public Vector256<float> Offsets {get; private set;}

    private Plane SinglePlane {get; set;}

    public PlanePacket256(Plane plane): base(plane.Surface)
    {
        Norms = new VectorPacket256(SetAllVector256(plane.Norm.X), SetAllVector256(plane.Norm.Y), SetAllVector256(plane.Norm.Z));
        Offsets = SetAllVector256(plane.Offset);
        SinglePlane = plane;
    }

    public override Intersections Intersect(RayPacket256 rayPacket256)
    {
        var denom = VectorPacket256.DotProduct(Norms, rayPacket256.Dirs);
        var dist = Divide(VectorPacket256.DotProduct(Norms, rayPacket256.Starts), Subtract(SetZeroVector256<float>(), denom));
        var gtMask = Compare(denom, SetZeroVector256<float>(), FloatComparisonMode.GreaterThanOrderedNonSignaling);
        var reslut = Or(And(gtMask, SetAllVector256(Intersections.NullValue)), AndNot(gtMask, dist));
        return new Intersections(reslut, SinglePlane);
    }

    public override VectorPacket256 Normal(VectorPacket256 pos)
    {
        return Norms;
    }
}