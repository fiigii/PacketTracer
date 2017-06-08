internal struct Vector
{
    public float X {get; private set;}
    public float Y {get; private set;}
    public float Z {get; private set;}

    public Vector(float _x, float _y, float _z)
    {
        X = _x;
        Y = _y;
        Z = _z;
    }
}