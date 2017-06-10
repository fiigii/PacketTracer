internal class PlanePacket
{
    public VectorPacket Norms {get; private set;}
    public Vector256<float> Offsets {get; private set;}
    public Surface Surfaces {get; private set;}

    public PlanePacket(Plane plane)
    {
        Norms = new VectorPacket(AVX.Set1(plane.Norm.X), AVX.Set1(plane.Norm.Y), AVX.Set1(plane.Norm.Z));
        Offsets = AVX.Set1(plane.Offset);
        Surfaces = plane.Surface;
    }
}