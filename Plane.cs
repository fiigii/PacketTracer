internal class Plane : SceneObject
{
    public Vector Norm;
    public float Offset;

    public Plane(Vector norm, float offset, Surface surface) : base(surface) { Norm = norm; Offset = offset; }

    public override ObjectPacket256 ToPacket256()
    {
        return new PlanePacket256(this);
    }
}