
internal abstract class ObjectPacket256
{
    public Surface Surface {get; private set;}
    public abstract Intersections Intersect(RayPacket256 rayPacket256);
    public abstract VectorPacket256 Normal(VectorPacket256 pos);

    public ObjectPacket256(Surface surface)
    {
        Surface = surface;
    }
}