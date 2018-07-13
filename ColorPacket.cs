// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
//

using static System.Runtime.Intrinsics.X86.Avx;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;
using System.Runtime.CompilerServices;

using ColorPacket256 = VectorPacket256;

internal static class ColorPacket256Helper
{
    public static Int32RGBPacket256 ConvertToIntRGB(this VectorPacket256 colors)
    {
        var one = SetAllVector256<float>(1.0f);
        var max = SetAllVector256<float>(255.0f);

        var rsMask = Compare(colors.Xs, one, FloatComparisonMode.GreaterThanOrderedNonSignaling);
        var gsMask = Compare(colors.Ys, one, FloatComparisonMode.GreaterThanOrderedNonSignaling);
        var bsMask = Compare(colors.Zs, one, FloatComparisonMode.GreaterThanOrderedNonSignaling);

        var rs = BlendVariable(colors.Xs, one, rsMask);
        var gs = BlendVariable(colors.Ys, one, gsMask);
        var bs = BlendVariable(colors.Zs, one, bsMask);

        var rsInt = ConvertToVector256Int32(Multiply(rs, max));
        var gsInt = ConvertToVector256Int32(Multiply(gs, max));
        var bsInt = ConvertToVector256Int32(Multiply(bs, max));

        return new Int32RGBPacket256(rsInt, gsInt, bsInt);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ColorPacket256 Times(ColorPacket256 left, ColorPacket256 right)
    {
        return new VectorPacket256(Multiply(left.Xs, right.Xs), Multiply(left.Ys, right.Ys), Multiply(left.Zs, right.Zs));
    }

    public static ColorPacket256 BackgroundColor = new ColorPacket256(SetZeroVector256<float>());
    public static ColorPacket256 DefaultColor = new ColorPacket256(SetZeroVector256<float>());
}

internal struct Int32RGBPacket256
{
    public Vector256<int> Rs;
    public Vector256<int> Gs;
    public Vector256<int> Bs;

    public Int32RGBPacket256(Vector256<int> _rs, Vector256<int> _gs, Vector256<int>_bs)
    {
        Rs = _rs;
        Gs = _gs;
        Bs = _bs;
    }
}