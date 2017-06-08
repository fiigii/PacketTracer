using System.Runtime.Compilexservices.Intrinsics.Intel;
using System.Runtime.Compilexservices.Intrinsics;
using System;

using Common;

internal struct PointPacket
{
    public Vector256<float> xs {get; private set;}
    public Vector256<float> ys {get; private set;}
    public Vector256<float> zs {get; private set;}

    public readonly static int PacketSize = 8;

    public PointPacket(Vector256<float> _xs, Vector256<float> _ys, Vector256<float> _zs)
    {
        xs = _xs;
        ys = _ys;
        zs = _zs; 
    }

    public unsafe PointPacket(Vector [] Points)
    {
        if (Points.Length > PacketSize)
        {
            throw new ArgumentException("PointPacket cannot contain more than 8 Point objects.");
        } 
        else if (Points.Length == 0)
        {
            xs = AVX.SetZero<float>(); 
            ys = AVX.SetZero<float>();
            zs = AVX.SetZero<float>();
        }
        else
        {
            var transformedxs = new float[8];
            var transformedys = new float[8];
            var transformedzs = new float[8];
            for (int i = 0; i < Points.Length; i++)
            {
                transformedxs[i] = Points[i].x;
                transformedys[i] = Points[i].y;
                transformedzs[i] = Points[i].z;
            }

            fixed (float* rp = &transformedxs[0])
            {
                xs = AVX.Load(rp);
            }

            fixed (float* gp = &transformedys[0])
            {
                ys = AVX.Load(gp);
            }

            fixed (float* bp = &transformedzs[0])
            {
                zs = AVX.Load(bp);
            }
        }
    }

    public static PointPacket operator +(PointPacket left, PointPacket right)
    {
        return new PointPacket(AVX.Add(left.xs, right.xs), AVX.Add(left.ys, right.ys), AVX.Add(left.zs, right.zs));
    }

    public static PointPacket operator -(PointPacket left, PointPacket right)
    {
        return new PointPacket(AVX.Subtract(left.xs, right.xs), AVX.Subtract(left.ys, right.ys), AVX.Subtract(left.zs, right.zs));
    }

    public static Vector256<float> DotProduct (PointPacket left, PointPacket right)
    {
        var _xs = AVX.Multiply(left.xs, right.xs);
        var _ys = AVX.Multiply(left.ys, right.ys);
        var _zs = AVX.Multiply(left.zs, right.zs);
        var result = AVX.Add(_xs, _ys);
        result = AVX.Add(result, _zs);
        return result;
    }

    public static PointPacket operator *(PointPacket left, PointPacket right)
    {
        return new PointPacket(AVX.Subtract(AVX.Multiply(left.ys, right.zs), AVX.Multiply(left.zs, right.ys)),
                               AVX.Subtract(AVX.Multiply(left.zs, right.xs), AVX.Multiply(left.xs, right.zs)),
                               AVX.Subtract(AVX.Multiply(left.xs, right.ys), AVX.Multiply(left.ys, right.xs)));
    }

    public Vector256<float> Lengthes()
    {
        var _x = AVX.Multiply(xs, xs);
        var _y = AVX.Multiply(ys, ys);
        var _z = AVX.Multiply(zs, zs);

        var length = AVX.Add(_x, _y);
        length = AVX.Add(_x, _y);
        return AVX.Sqrt(length);
    }

    public PointPacket normalize()
    {
        var length = this.lengthes();
        return new PointPacket(AVX.Divide(xs, length), AVX.Divide(ys, length), AVX.Divide(zs, length));
    }
}