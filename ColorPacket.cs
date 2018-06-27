using static System.Runtime.Intrinsics.X86.Avx;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;

using ColorPacket256 = VectorPacket256;

internal static class ColorPacket256Helper
{
    public static Int32RGBPacket256 ConvertToIntRGB(this VectorPacket256 colors)
    {
        var one = SetAllVector256<float>(1.0f);
        var max = SetAllVector256<float>(255.0f);

        var rsMask = Compare(colors.xs, one, FloatComparisonMode.GreaterThanOrderedNonSignaling);
        var gsMask = Compare(colors.ys, one, FloatComparisonMode.GreaterThanOrderedNonSignaling);;
        var bsMask = Compare(colors.zs, one, FloatComparisonMode.GreaterThanOrderedNonSignaling);

        var rs = BlendVariable(colors.xs, one, rsMask);
        var gs = BlendVariable(colors.ys, one, gsMask);
        var bs = BlendVariable(colors.zs, one, bsMask);

        var rsInt = ConvertToVector256Int32(Multiply(rs, max));
        var gsInt = ConvertToVector256Int32(Multiply(gs, max));
        var bsInt = ConvertToVector256Int32(Multiply(bs, max));

        return new Int32RGBPacket256(rsInt, gsInt, bsInt);
    }

    public static ColorPacket256 BackgroundColor = new ColorPacket256(SetZeroVector256<float>());
    public static ColorPacket256 DefaultColor = new ColorPacket256(SetZeroVector256<float>());
}

internal struct Int32RGBPacket256
{
    public Vector256<int> Rs {get; private set;}
    public Vector256<int> Gs {get; private set;}
    public Vector256<int> Bs {get; private set;}

    public Int32RGBPacket256(Vector256<int> _rs, Vector256<int> _gs, Vector256<int>_bs)
    {
        Rs = _rs;
        Gs = _gs;
        Bs = _bs;
    }
}