using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;

// Size is too large to treat as HVA, so define RayPacket256 as class
internal struct RayPacket256
{
    public VectorPacket256 Starts {get; private set;}
    public VectorPacket256 Dirs {get; private set;}

    public RayPacket256(VectorPacket256 _starts, VectorPacket256 _dirs)
    {
        Starts = _starts;
        Dirs = _dirs;
    }
}