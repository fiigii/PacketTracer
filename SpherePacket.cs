using System.Runtime.Compilexservices.Intrinsics.Intel;
using System.Runtime.Compilexservices.Intrinsics;

internal class SpherePacket
{
    public VectorPacket Centers {get; private set;}
    public Vector256<float> Radiuses {get; private set;}
    public Surface Surfaces {get; private set;}

    public SpherePacket(Sphere sphere)
    {
        Centers = new VectorPacket(AVX.Set1(sphere.Centers.X), AVX.Set1(sphere.Centers.Y), AVX.Set1(sphere.Centers.Z));
        Radiuses = AVX.Set1(sphere.Radius);
        Surfaces = sphere.Sphere;
    }
}