
internal abstract class ObjectPacket
{
    public Surface Surface {get; private set;}
    public abstract Intersections Intersect(RayPacket rayPacket, int index);
    public abstract VectorPacket Normal(VectorPacket pos);

    public ObjectPacket(Surface surface)
    {
        Surface = surface;
    }
}