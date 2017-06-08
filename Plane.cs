internal class Plane : SceneObject
{
    public Vector Norm;
    public double Offset;

    public Plane(Vector norm, double offset, Surface surface) : base(surface) { Norm = norm; Offset = offset; }
}