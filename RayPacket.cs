using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;

internal struct RayPacket256
{
    public VectorPacket256 Starts;
    public VectorPacket256 Dirs;

    public RayPacket256(VectorPacket256 _starts, VectorPacket256 _dirs)
    {
        Starts = _starts;
        Dirs = _dirs;
    }
}