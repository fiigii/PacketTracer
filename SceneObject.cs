internal abstract class SceneObject
{
    public Surface Surface;
    public abstract ObjectPacket256 ToPacket256();
    //public abstract Vector Normal(Vector pos);

    public SceneObject(Surface surface) { Surface = surface; }
}
