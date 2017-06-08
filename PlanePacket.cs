internal class PlanePacket
{
    public PointPacket Norms {get; private set;}
    public Vector256<float> Offsets {get; private set;}

    public PlanePacket(Plane plane)
    {
        Norms = new PointPacket(AVX.Set1(plane.Norm.X), AVX.Set1(plane.Norm.Y), AVX.Set1(plane.Norm.Z));
        Offsets = AVX.Set1(plane.Offset);
    }
}