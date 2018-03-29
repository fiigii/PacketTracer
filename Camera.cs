internal class Camera
{
    public Vector Pos;
    public Vector Forward;
    public Vector Up;
    public Vector Right;

    public Camera(Vector pos, Vector forward, Vector up, Vector right) { Pos = pos; Forward = forward; Up = up; Right = right; }

    public VectorPacket256 PosPacket256 => new VectorPacket256(Pos);
    public VectorPacket256 ForwardPacket256 => new VectorPacket256(Forward);
    public VectorPacket256 UpPacket256 => new VectorPacket256(Up);
    public VectorPacket256 RightPacket256 => new VectorPacket256(Right);
    
}

