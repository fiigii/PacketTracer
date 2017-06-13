internal class Camera
{
    public Vector Pos;
    public Vector Forward;
    public Vector Up;
    public Vector Right;

    public Camera(Vector pos, Vector forward, Vector up, Vector right) { Pos = pos; Forward = forward; Up = up; Right = right; }

    public VectorPacket PosPacket => new VectorPacket(Pos);
    public VectorPacket ForwardPacket => new VectorPacket(Forward);
    public VectorPacket UpPacket => new VectorPacket(Up);
    public VectorPacket RightPacket => new VectorPacket(Right);
    
}

