using System.Runtime.CompilerServices.Intrinsics.Intel;
using System.Runtime.CompilerServices.Intrinsics;

using ColorPacket = VectorPacket;

internal static class ColorPacketHelper
{
    public static IntRGBPacket ConvertToIntRGB(this VectorPacket colors)
    {
        var one = AVX.Set1<float>(1.0f);
        var max = AVX.Set1<float>(255.0f);

        var greaterThan = AVX.GetCompareVector256Float(FloatComparisonMode.CompareGreaterThanOrderedNonSignaling);
        var rsMask = greaterThan(colors.xs, one);
        var gsMask = greaterThan(colors.ys, one);
        var bsMask = greaterThan(colors.zs, one);

        var rs = AVX.BlendVariable(colors.xs, one, rsMask);
        var gs = AVX.BlendVariable(colors.ys, one, gsMask);
        var bs = AVX.BlendVariable(colors.zs, one, bsMask);

        var rsInt = AVX.ConvertToVector256Int(AVX.Multiply(rs, max));
        var gsInt = AVX.ConvertToVector256Int(AVX.Multiply(gs, max));
        var bsInt = AVX.ConvertToVector256Int(AVX.Multiply(bs, max));

        return new IntRGBPacket(rsInt, gsInt, bsInt);
    }

    public static ColorPacket BackgroundColor = new ColorPacket(AVX.SetZero<float>());
    public static ColorPacket DefaultColor = new ColorPacket(AVX.SetZero<float>());
}

internal struct IntRGBPacket
{
    public Vector256<int> Rs {get; private set;}
    public Vector256<int> Gs {get; private set;}
    public Vector256<int> Bs {get; private set;}

    public IntRGBPacket(Vector256<int> _rs, Vector256<int> _gs, Vector256<int>_bs)
    {
        Rs = _rs;
        Gs = _gs;
        Bs = _bs;
    }
}