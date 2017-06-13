internal class Sphere : SceneObject
{
    public Vector Center;
    public float Radius;

    public Sphere(Vector center, double radius, Surface surface) : base(surface) { Center = center; Radius = (float)radius; }

    public override ObjectPacket ToPacket()
    {
        return new SpherePacket(this);
    }

}