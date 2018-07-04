using System.Runtime.Intrinsics.X86;
using static System.Runtime.Intrinsics.X86.Avx;
using System.Runtime.Intrinsics;

internal class SpherePacket256: ObjectPacket256
{
    public VectorPacket256 Centers {get; private set;}
    public Vector256<float> Radiuses {get; private set;}


    public SpherePacket256(Sphere sphere): base(sphere.Surface)
    {
        Centers = new VectorPacket256(SetAllVector256(sphere.Center.X), SetAllVector256(sphere.Center.Y), SetAllVector256(sphere.Center.Z));
        Radiuses = SetAllVector256(sphere.Radius);
    }
}