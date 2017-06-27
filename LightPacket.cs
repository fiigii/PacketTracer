using ColorPacket = VectorPacket;

internal class LightPacket
{
    public VectorPacket Positions {get; private set;}
    public ColorPacket Colors {get; private set;}

    public LightPacket(Vector pos, Color col)
    {
        Positions = new VectorPacket(pos);
        Colors = col.ToColorPacket();
    }
}