
internal abstract class ObjectPacket
{
    public Surface Surface {get; private set;}
    public abstract Intersections Intersect(RayPacket rayPacket, int index);

    public ObjectPacket(Surface surface)
    {
        Surface = surface;
    }
}