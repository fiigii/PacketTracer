using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;

internal class PlanePacket: ObjectPacket
{
    public VectorPacket Norms {get; private set;}
    public Vector256<float> Offsets {get; private set;}

    public PlanePacket(Plane plane): base(plane.Surface)
    {
        Norms = new VectorPacket(Avx.Set1(plane.Norm.X), Avx.Set1(plane.Norm.Y), Avx.Set1(plane.Norm.Z));
        Offsets = Avx.Set1(plane.Offset);
    }

    public override Intersections Intersect(RayPacket rayPacket, int index)
    {
        var denom = VectorPacket.DotProduct(Norms, rayPacket.Dirs);
        var dist = Avx.Divide(VectorPacket.DotProduct(Norms, rayPacket.Starts), Avx.Subtract(Avx.SetZero<float>(), denom));
        var gtMask = Avx.Compare(denom, Avx.SetZero<float>(), FloatComparisonMode.GreaterThanOrderedNonSignaling);
        var reslut = Avx.Or(Avx.And(gtMask, Avx.Set1(Intersections.NullValue)), Avx.AndNot(gtMask, dist));
        return new Intersections(reslut, Avx.Set1<int>(index));
    }

    public override VectorPacket Normal(VectorPacket pos)
    {
        return Norms;
    }
}