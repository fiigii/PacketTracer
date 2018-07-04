using ColorPacket256 = VectorPacket256;

internal class LightPacket256
{
    public VectorPacket256 Positions {get; private set;}
    public ColorPacket256 Colors {get; private set;}

    public LightPacket256(Vector pos, Color col)
    {
        Positions = new VectorPacket256(pos.X, pos.Y, pos.Z);
        Colors = col.ToColorPacket256();
    }
}