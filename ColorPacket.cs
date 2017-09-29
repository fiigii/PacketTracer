using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;

using ColorPacket = VectorPacket;

internal static class ColorPacketHelper
{
    public static IntRGBPacket ConvertToIntRGB(this VectorPacket colors)
    {
        var one = Avx.Set1<float>(1.0f);
        var max = Avx.Set1<float>(255.0f);

        var rsMask = Avx.Compare(colors.xs, one, FloatComparisonMode.GreaterThanOrderedNonSignaling);
        var gsMask = Avx.Compare(colors.ys, one, FloatComparisonMode.GreaterThanOrderedNonSignaling);;
        var bsMask = Avx.Compare(colors.zs, one, FloatComparisonMode.GreaterThanOrderedNonSignaling);

        var rs = Avx.BlendVariable(colors.xs, one, rsMask);
        var gs = Avx.BlendVariable(colors.ys, one, gsMask);
        var bs = Avx.BlendVariable(colors.zs, one, bsMask);

        var rsInt = Avx.ConvertToVector256Int(Avx.Multiply(rs, max));
        var gsInt = Avx.ConvertToVector256Int(Avx.Multiply(gs, max));
        var bsInt = Avx.ConvertToVector256Int(Avx.Multiply(bs, max));

        return new IntRGBPacket(rsInt, gsInt, bsInt);
    }

    public static ColorPacket BackgroundColor = new ColorPacket(Avx.SetZero<float>());
    public static ColorPacket DefaultColor = new ColorPacket(Avx.SetZero<float>());
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