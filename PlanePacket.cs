using System.Runtime.CompilerServices.Intrinsics.X86;
using System.Runtime.CompilerServices.Intrinsics;

internal class PlanePacket: ObjectPacket
{
    public VectorPacket Norms {get; private set;}
    public Vector256<float> Offsets {get; private set;}

    public PlanePacket(Plane plane): base(plane.Surface)
    {
        Norms = new VectorPacket(AVX.Set1(plane.Norm.X), AVX.Set1(plane.Norm.Y), AVX.Set1(plane.Norm.Z));
        Offsets = AVX.Set1(plane.Offset);
    }

    public override Intersections Intersect(RayPacket rayPacket, int index)
    {
        var denom = VectorPacket.DotProduct(Norms, rayPacket.Dirs);
        var dist = AVX.Divide(VectorPacket.DotProduct(Norms, rayPacket.Starts), AVX.Subtract(AVX.SetZero<float>(), denom));
        var gtMask = AVX.CompareVector256(denom, AVX.SetZero<float>(), FloatComparisonMode.CompareGreaterThanOrderedNonSignaling);
        var reslut = AVX.Or(AVX.And(gtMask, AVX.Set1(Intersections.NullValue)), AVX.AndNot(gtMask, dist));
        return new Intersections(reslut, AVX.Set1<int>(index));
    }

    public override VectorPacket Normal(VectorPacket pos)
    {
        return Norms;
    }
}