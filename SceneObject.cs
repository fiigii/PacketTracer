internal abstract class SceneObject
{
    public Surface Surface;
    //public abstract Intersections Intersect(Ray ray);
    public abstract Vector Normal(Vector pos);

    public SceneObject(Surface surface) { Surface = surface; }
}
