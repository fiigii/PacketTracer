using static System.Runtime.Intrinsics.X86.Avx;
using static System.Runtime.Intrinsics.X86.Sse;
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
            var x2 = Multiply(xs, xs);
            var y2 = Multiply(ys, ys);
            var z2 = Multiply(zs, zs);

            var l2 = Add(x2, y2);
            l2 = Add(l2, z2);
            return Sqrt(l2);
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
        xs = SetAllVector256(v.X);
        ys = SetAllVector256(v.Y);
        zs = SetAllVector256(v.Z);
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
        Vector256<float> m03 = ExtendToVector256<float>(LoadVector128(&vectors[0])); // load lower halves
        Vector256<float> m14 = ExtendToVector256<float>(LoadVector128(&vectors[4]));
        Vector256<float> m25 = ExtendToVector256<float>(LoadVector128(&vectors[8]));
        m03 = InsertVector128(m03, &vectors[12], 1);  // load higher halves
        m14 = InsertVector128(m14, &vectors[16], 1);
        m25 = InsertVector128(m25, &vectors[20], 1);

        var xy = Shuffle(m14, m25, 2 << 6 | 1 << 4 | 3 << 2 | 2);
        var yz = Shuffle(m03, m14, 1 << 6 | 0 << 4 | 2 << 2 | 1);
        var _xs = Shuffle(m03, xy, 2 << 6 | 0 << 4 | 3 << 2 | 0);
        var _ys = Shuffle(yz, xy,  3 << 6 | 1 << 4 | 2 << 2 | 0);
        var _zs = Shuffle(yz, m25, 3 << 6 | 0 << 4 | 3 << 2 | 1);

        xs = _xs;
        ys = _ys;
        zs = _zs; 
    }

    // Convert SoA VectorPacket256 to AoS
    public VectorPacket256 Transpose()
    {
        var rxy = Shuffle(xs, ys, 2 << 6 | 0 << 4 | 2 << 2 | 0);
        var ryz = Shuffle(ys, zs, 3 << 6 | 1 << 4 | 3 << 2 | 1);
        var rzx = Shuffle(zs, xs, 3 << 6 | 1 << 4 | 2 << 2 | 0);

        var r03 = Shuffle(rxy, rzx, 2 << 6 | 0 << 4 | 2 << 2 | 0);
        var r14 = Shuffle(ryz, rxy, 3 << 6 | 1 << 4 | 2 << 2 | 0);
        var r25 = Shuffle(rzx, ryz, 3 << 6 | 1 << 4 | 3 << 2 | 1);

        var m0 = GetLowerHalf<float>(r03);
        var m1 = GetLowerHalf<float>(r14);
        var m2 = GetLowerHalf<float>(r25);
        var m3 = ExtractVector128(r03, 1);
        var m4 = ExtractVector128(r14, 1);
        var m5 = ExtractVector128(r25, 1);

        var _xs = SetHighLow(m1, m0);
        var _ys = SetHighLow(m3, m2);
        var _zs = SetHighLow(m5, m4);
        
        return new VectorPacket256(_xs, _ys, _zs);
    }

    // Convert SoA VectorPacket256 to an incomplete AoS
    public VectorPacket256 FastTranspose()
    {
        var rxy = Shuffle(xs, ys, 2 << 6 | 0 << 4 | 2 << 2 | 0);
        var ryz = Shuffle(ys, zs, 3 << 6 | 1 << 4 | 3 << 2 | 1);
        var rzx = Shuffle(zs, xs, 3 << 6 | 1 << 4 | 2 << 2 | 0);

        var r03 = Shuffle(rxy, rzx, 2 << 6 | 0 << 4 | 2 << 2 | 0);
        var r14 = Shuffle(ryz, rxy, 3 << 6 | 1 << 4 | 2 << 2 | 0);
        var r25 = Shuffle(rzx, ryz, 3 << 6 | 1 << 4 | 3 << 2 | 1);

        return new VectorPacket256(r03, r14, r25);
    }

    public static VectorPacket256 operator +(VectorPacket256 left, VectorPacket256 right)
    {
        return new VectorPacket256(Add(left.xs, right.xs), Add(left.ys, right.ys), Add(left.zs, right.zs));
    }

    public static VectorPacket256 operator -(VectorPacket256 left, VectorPacket256 right)
    {
        return new VectorPacket256(Subtract(left.xs, right.xs), Subtract(left.ys, right.ys), Subtract(left.zs, right.zs));
    }

    public static VectorPacket256 operator /(VectorPacket256 left, VectorPacket256 right)
    {
        return new VectorPacket256(Divide(left.xs, right.xs), Divide(left.ys, right.ys), Divide(left.zs, right.zs));
    }

    public static Vector256<float> DotProduct (VectorPacket256 left, VectorPacket256 right)
    {
        var x2 = Multiply(left.xs, right.xs);
        var y2 = Multiply(left.ys, right.ys);
        var z2 = Multiply(left.zs, right.zs);
        return Add(Add(x2, y2), z2);
    }

    public static VectorPacket256 CrossProduct(VectorPacket256 left, VectorPacket256 right)
    {
        return new VectorPacket256(Subtract(Multiply(left.ys, right.zs), Multiply(left.zs, right.ys)),
                                   Subtract(Multiply(left.zs, right.xs), Multiply(left.xs, right.zs)),
                                   Subtract(Multiply(left.xs, right.ys), Multiply(left.ys, right.xs)));
    }

    public static VectorPacket256 operator *(Vector256<float> left, VectorPacket256 right)
    {
        return new VectorPacket256(Multiply(left, right.xs), Multiply(left, right.ys), Multiply(left, right.zs));
    }

    public VectorPacket256 Normalize()
    {
        var length = this.Lengths;
        return new VectorPacket256(Divide(xs, length), Divide(ys, length), Divide(zs, length));
    }
}