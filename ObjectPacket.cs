using System.Runtime.Intrinsics;

internal abstract class ObjectPacket256
{
    public Surface Surface {get; private set;}
    public abstract Vector256<float> Intersect(RayPacket256 rayPacket256);
    public abstract VectorPacket256 Normals(VectorPacket256 pos);

    public ObjectPacket256(Surface surface)
    {
        Surface = surface;
    }
}