using System.Runtime.CompilerServices.Intrinsics;
using System;
using ColorPacket = VectorPacket;

internal class Surface
{
    public Func<VectorPacket, ColorPacket> Diffuse;
    public Func<VectorPacket, ColorPacket> Specular;
    public Func<VectorPacket, Vector256<float>> Reflect;
    public float Roughness;

    public Surface(Func<VectorPacket, ColorPacket> Diffuse,
                    Func<VectorPacket, ColorPacket> Specular,
                    Func<VectorPacket, Vector256<float>> Reflect,
                    float Roughness)
    {
        this.Diffuse = Diffuse;
        this.Specular = Specular;
        this.Reflect = Reflect;
        this.Roughness = Roughness;
    }
}

