using System.Runtime.CompilerServices.Intrinsics.X86;
using System.Runtime.CompilerServices.Intrinsics;
using System;

internal struct VectorPacket
{
    public Vector256<float> xs {get; private set;}
    public Vector256<float> ys {get; private set;}
    public Vector256<float> zs {get; private set;}

    public readonly static int PacketSize = 8;

    public VectorPacket(Vector256<float> init)
    {
        xs = init;
        ys = init;
        zs = init;
    }

    public VectorPacket(Vector v)
    {
        xs = AVX.Set1(v.X);
        ys = AVX.Set1(v.Y);
        zs = AVX.Set1(v.Z);
    }

    public VectorPacket(Vector256<float> _xs, Vector256<float> _ys, Vector256<float> _zs)
    {
        xs = _xs;
        ys = _ys;
        zs = _zs; 
    }

    // Convert AoS vectors to SoA packet
    public unsafe VectorPacket(float* vectors)
    {
        var m03 = AVX.ExtendToVector256<float>(SSE2.Load(&vectors[0])); // load lower halves
        var m14 = AVX.ExtendToVector256<float>(SSE2.Load(&vectors[4]));
        var m25 = AVX.ExtendToVector256<float>(SSE2.Load(&vectors[8]));
        m03 = AVX.Insert(m03, &vectors[12], 1);  // load higher halves
        m14 = AVX.Insert(m14, &vectors[16], 1);
        m25 = AVX.Insert(m25, &vectors[20], 1);

        var xy = AVX.Shuffle(m14, m25, 2 << 6 | 1 << 4 | 3 << 2 | 2);
        var yz = AVX.Shuffle(m03, m14, 1 << 6 | 0 << 4 | 2 << 2 | 1);
        var _xs = AVX.Shuffle(m03, xy, 2 << 6 | 0 << 4 | 3 << 2 | 0);
        var _ys = AVX.Shuffle(yz, xy,  3 << 6 | 1 << 4 | 2 << 2 | 0);
        var _zs = AVX.Shuffle(yz, m25, 3 << 6 | 0 << 4 | 3 << 2 | 1);

        xs = _xs;
        ys = _ys;
        zs = _zs; 
    }

    // Convert SoA VectorPacket to AoS
    public VectorPacket Transpose()
    {
        var rxy = AVX.Shuffle(xs, ys, 2 << 6 | 0 << 4 | 2 << 2 | 0);
        var ryz = AVX.Shuffle(ys, zs, 3 << 6 | 1 << 4 | 3 << 2 | 1);
        var rzx = AVX.Shuffle(zs, xs, 3 << 6 | 1 << 4 | 2 << 2 | 0);

        var r03 = AVX.Shuffle(rxy, rzx, 2 << 6 | 0 << 4 | 2 << 2 | 0);
        var r14 = AVX.Shuffle(ryz, rxy, 3 << 6 | 1 << 4 | 2 << 2 | 0);
        var r25 = AVX.Shuffle(rzx, ryz, 3 << 6 | 1 << 4 | 3 << 2 | 1);

        var m0 = AVX.GetLowerHalf<float>(r03);
        var m1 = AVX.GetLowerHalf<float>(r14);
        var m2 = AVX.GetLowerHalf<float>(r25);
        var m3 = AVX.ExtractVector128(r03, 1);
        var m4 = AVX.ExtractVector128(r14, 1);
        var m5 = AVX.ExtractVector128(r25, 1);

        var _xs = AVX.SetHiLo(m0, m1);
        var _ys = AVX.SetHiLo(m2, m3);
        var _zs = AVX.SetHiLo(m4, m5);
        
        return new VectorPacket(_xs, _ys, _zs);
    }

    // Convert SoA VectorPacket to an incomplete AoS
    public VectorPacket FastTranspose()
    {
        var rxy = AVX.Shuffle(xs, ys, 2 << 6 | 0 << 4 | 2 << 2 | 0);
        var ryz = AVX.Shuffle(ys, zs, 3 << 6 | 1 << 4 | 3 << 2 | 1);
        var rzx = AVX.Shuffle(zs, xs, 3 << 6 | 1 << 4 | 2 << 2 | 0);

        var r03 = AVX.Shuffle(rxy, rzx, 2 << 6 | 0 << 4 | 2 << 2 | 0);
        var r14 = AVX.Shuffle(ryz, rxy, 3 << 6 | 1 << 4 | 2 << 2 | 0);
        var r25 = AVX.Shuffle(rzx, ryz, 3 << 6 | 1 << 4 | 3 << 2 | 1);

        return new VectorPacket(r03, r14, r25);
    }

    public static VectorPacket operator +(VectorPacket left, VectorPacket right)
    {
        return new VectorPacket(AVX.Add(left.xs, right.xs), AVX.Add(left.ys, right.ys), AVX.Add(left.zs, right.zs));
    }

    public static VectorPacket operator -(VectorPacket left, VectorPacket right)
    {
        return new VectorPacket(AVX.Subtract(left.xs, right.xs), AVX.Subtract(left.ys, right.ys), AVX.Subtract(left.zs, right.zs));
    }

    public static VectorPacket operator /(VectorPacket left, VectorPacket right)
    {
        return new VectorPacket(AVX.Divide(left.xs, right.xs), AVX.Divide(left.ys, right.ys), AVX.Divide(left.zs, right.zs));
    }

    public static Vector256<float> DotProduct (VectorPacket left, VectorPacket right)
    {
        var _xs = AVX.Multiply(left.xs, right.xs);
        var _ys = AVX.Multiply(left.ys, right.ys);
        var _zs = AVX.Multiply(left.zs, right.zs);
        var result = AVX.Add(_xs, _ys);
        result = AVX.Add(result, _zs);
        return result;
    }

    public static VectorPacket CrossProduct(VectorPacket left, VectorPacket right)
    {
        return new VectorPacket(AVX.Subtract(AVX.Multiply(left.ys, right.zs), AVX.Multiply(left.zs, right.ys)),
                               AVX.Subtract(AVX.Multiply(left.zs, right.xs), AVX.Multiply(left.xs, right.zs)),
                               AVX.Subtract(AVX.Multiply(left.xs, right.ys), AVX.Multiply(left.ys, right.xs)));
    }

    public static VectorPacket operator *(Vector256<float> left, VectorPacket right)
    {
        return new VectorPacket(AVX.Multiply(left, right.xs), AVX.Multiply(left, right.ys), AVX.Multiply(left, right.zs));
    }

    public Vector256<float> Lengths()
    {
        var _x = AVX.Multiply(xs, xs);
        var _y = AVX.Multiply(ys, ys);
        var _z = AVX.Multiply(zs, zs);

        var length = AVX.Add(_x, _y);
        length = AVX.Add(_x, _y);
        return AVX.Sqrt(length);
    }

    public VectorPacket Normalize()
    {
        var length = this.Lengths();
        return new VectorPacket(AVX.Divide(xs, length), AVX.Divide(ys, length), AVX.Divide(zs, length));
    }
}