internal abstract class SceneObject
{
    public Surface Surface;
    public abstract ObjectPacket256 ToPacket256();

    public SceneObject(Surface surface) { Surface = surface; }
}
