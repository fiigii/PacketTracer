using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;
using System;

internal struct VectorPacket256
{
    public Vector256<float> xs {get; private set;}
    public Vector256<float> ys {get; private set;}
    public Vector256<float> zs {get; private set;}

    public Vector256<float> Lengths
    {
        get
        {
            var _x = Avx.Multiply(xs, xs);
            var _y = Avx.Multiply(ys, ys);
            var _z = Avx.Multiply(zs, zs);

            var length = Avx.Add(_x, _y);
            length = Avx.Add(_x, _y);
            return Avx.Sqrt(length);
        }
    }

    public readonly static int Packet256Size = 8;

    public VectorPacket256(Vector256<float> init)
    {
        xs = init;
        ys = init;
        zs = init;
    }

    public VectorPacket256(Vector v)
    {
        xs = Avx.SetAllVector256(v.X);
        ys = Avx.SetAllVector256(v.Y);
        zs = Avx.SetAllVector256(v.Z);
    }

    public VectorPacket256(Vector256<float> _xs, Vector256<float> _ys, Vector256<float> _zs)
    {
        xs = _xs;
        ys = _ys;
        zs = _zs; 
    }

    // Convert AoS vectors to SoA Packet256
    public unsafe VectorPacket256(float* vectors)
    {
        Vector256<float> m03 = Avx.ExtendToVector256<float>(Sse.LoadVector128(&vectors[0])); // load lower halves
        Vector256<float> m14 = Avx.ExtendToVector256<float>(Sse.LoadVector128(&vectors[4]));
        Vector256<float> m25 = Avx.ExtendToVector256<float>(Sse.LoadVector128(&vectors[8]));
        m03 = Avx.InsertVector128(m03, &vectors[12], 1);  // load higher halves
        m14 = Avx.InsertVector128(m14, &vectors[16], 1);
        m25 = Avx.InsertVector128(m25, &vectors[20], 1);

        var xy = Avx.Shuffle(m14, m25, 2 << 6 | 1 << 4 | 3 << 2 | 2);
        var yz = Avx.Shuffle(m03, m14, 1 << 6 | 0 << 4 | 2 << 2 | 1);
        var _xs = Avx.Shuffle(m03, xy, 2 << 6 | 0 << 4 | 3 << 2 | 0);
        var _ys = Avx.Shuffle(yz, xy,  3 << 6 | 1 << 4 | 2 << 2 | 0);
        var _zs = Avx.Shuffle(yz, m25, 3 << 6 | 0 << 4 | 3 << 2 | 1);

        xs = _xs;
        ys = _ys;
        zs = _zs; 
    }

    // Convert SoA VectorPacket256 to AoS
    public VectorPacket256 Transpose()
    {
        var rxy = Avx.Shuffle(xs, ys, 2 << 6 | 0 << 4 | 2 << 2 | 0);
        var ryz = Avx.Shuffle(ys, zs, 3 << 6 | 1 << 4 | 3 << 2 | 1);
        var rzx = Avx.Shuffle(zs, xs, 3 << 6 | 1 << 4 | 2 << 2 | 0);

        var r03 = Avx.Shuffle(rxy, rzx, 2 << 6 | 0 << 4 | 2 << 2 | 0);
        var r14 = Avx.Shuffle(ryz, rxy, 3 << 6 | 1 << 4 | 2 << 2 | 0);
        var r25 = Avx.Shuffle(rzx, ryz, 3 << 6 | 1 << 4 | 3 << 2 | 1);

        var m0 = Avx.GetLowerHalf<float>(r03);
        var m1 = Avx.GetLowerHalf<float>(r14);
        var m2 = Avx.GetLowerHalf<float>(r25);
        var m3 = Avx.ExtractVector128(r03, 1);
        var m4 = Avx.ExtractVector128(r14, 1);
        var m5 = Avx.ExtractVector128(r25, 1);

        var _xs = Avx.SetHighLow(m1, m0);
        var _ys = Avx.SetHighLow(m3, m2);
        var _zs = Avx.SetHighLow(m5, m4);
        
        return new VectorPacket256(_xs, _ys, _zs);
    }

    // Convert SoA VectorPacket256 to an incomplete AoS
    public VectorPacket256 FastTranspose()
    {
        var rxy = Avx.Shuffle(xs, ys, 2 << 6 | 0 << 4 | 2 << 2 | 0);
        var ryz = Avx.Shuffle(ys, zs, 3 << 6 | 1 << 4 | 3 << 2 | 1);
        var rzx = Avx.Shuffle(zs, xs, 3 << 6 | 1 << 4 | 2 << 2 | 0);

        var r03 = Avx.Shuffle(rxy, rzx, 2 << 6 | 0 << 4 | 2 << 2 | 0);
        var r14 = Avx.Shuffle(ryz, rxy, 3 << 6 | 1 << 4 | 2 << 2 | 0);
        var r25 = Avx.Shuffle(rzx, ryz, 3 << 6 | 1 << 4 | 3 << 2 | 1);

        return new VectorPacket256(r03, r14, r25);
    }

    public static VectorPacket256 operator +(VectorPacket256 left, VectorPacket256 right)
    {
        return new VectorPacket256(Avx.Add(left.xs, right.xs), Avx.Add(left.ys, right.ys), Avx.Add(left.zs, right.zs));
    }

    public static VectorPacket256 operator -(VectorPacket256 left, VectorPacket256 right)
    {
        return new VectorPacket256(Avx.Subtract(left.xs, right.xs), Avx.Subtract(left.ys, right.ys), Avx.Subtract(left.zs, right.zs));
    }

    public static VectorPacket256 operator /(VectorPacket256 left, VectorPacket256 right)
    {
        return new VectorPacket256(Avx.Divide(left.xs, right.xs), Avx.Divide(left.ys, right.ys), Avx.Divide(left.zs, right.zs));
    }

    public static Vector256<float> DotProduct (VectorPacket256 left, VectorPacket256 right)
    {
        var _xs = Avx.Multiply(left.xs, right.xs);
        var _ys = Avx.Multiply(left.ys, right.ys);
        var _zs = Avx.Multiply(left.zs, right.zs);
        var result = Avx.Add(_xs, _ys);
        result = Avx.Add(result, _zs);
        return result;
    }

    public static VectorPacket256 CrossProduct(VectorPacket256 left, VectorPacket256 right)
    {
        return new VectorPacket256(Avx.Subtract(Avx.Multiply(left.ys, right.zs), Avx.Multiply(left.zs, right.ys)),
                               Avx.Subtract(Avx.Multiply(left.zs, right.xs), Avx.Multiply(left.xs, right.zs)),
                               Avx.Subtract(Avx.Multiply(left.xs, right.ys), Avx.Multiply(left.ys, right.xs)));
    }

    public static VectorPacket256 operator *(Vector256<float> left, VectorPacket256 right)
    {
        return new VectorPacket256(Avx.Multiply(left, right.xs), Avx.Multiply(left, right.ys), Avx.Multiply(left, right.zs));
    }

    public VectorPacket256 Normalize()
    {
        var length = this.Lengths;
        return new VectorPacket256(Avx.Divide(xs, length), Avx.Divide(ys, length), Avx.Divide(zs, length));
    }
}