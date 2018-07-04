using System.Runtime.Intrinsics.X86;
using static System.Runtime.Intrinsics.X86.Avx;
using System.Runtime.Intrinsics;

internal class PlanePacket256: ObjectPacket256
{
    public VectorPacket256 Norms {get; private set;}
    public Vector256<float> Offsets {get; private set;}

    public PlanePacket256(Plane plane): base(plane.Surface)
    {
        Norms = new VectorPacket256(SetAllVector256(plane.Norm.X), SetAllVector256(plane.Norm.Y), SetAllVector256(plane.Norm.Z));
        Offsets = SetAllVector256(plane.Offset);
    }
}