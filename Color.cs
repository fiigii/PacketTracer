internal struct Color
{
    public float R {get; private set;}
    public float G {get; private set;}
    public float B {get; private set;}

    public Color(float _r, float _g, float _b)
    {
        R = _r;
        G = _g;
        B = _b;
    }
}