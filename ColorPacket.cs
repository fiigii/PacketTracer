using System.Runtime.Compilexservices.Intrinsics.Intel;
using System.Runtime.Compilexservices.Intrinsics;

using ColorPacket = VectorPacket;

public class ColorPacketMethods
{
    public IntRGBPacket ConvertToIntRGB(this ColorPacket colors)
    {
        var one = AVX.Set1<float>(1.0);
        var max = AVX.Set1<float>(255.0);

        var greaterThan = AVX.GetCompareVector256Float(CompareGreaterThanOrderedNonSignaling);
        var rsMask = greaterThan(colors.xs, one);
        var gsMask = greaterThan(colors.ys, one);
        var bsMask = greaterThan(colors.zs, one);

        var rs = AVX.Or(AVX.And(rsMask, one), AVX.AndNot(rsMask, colors.xs));
        var gs = AVX.Or(AVX.And(gsMask, one), AVX.AndNot(gsMask, colors.ys));
        var bs = AVX.Or(AVX.And(bsMask, one), AVX.AndNot(bsMask, colors.zs));

        var rsInt = AVX.ConvertToVector256Int(AVX.Multiply(rs, max));
        var gsInt = AVX.ConvertToVector256Int(AVX.Multiply(gs, max));
        var bsInt = AVX.ConvertToVector256Int(AVX.Multiply(bs, max));

        return new IntRGBPacket(rsInt, gsInt, bsInt);
    }
}

public class IntRGBPacket
{
    public Vector256<int> Rs {get; private set;}
    public Vector256<int> Gs {get; private set;}
    public Vector256<int> Gs {get; private set;}

    public IntRGBPacket(Vector256<int> _rs, Vector256<int> _gs, Vector256<int>_bs)
    {
        Rs = _rs;
        Gs = _gs;
        Bs = _bs;
    }
}