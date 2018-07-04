using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using static System.Runtime.Intrinsics.X86.Avx;
using ColorPacket256 = VectorPacket256;

using System;

internal static class Surfaces
{
    // Only works with X-Z plane.
    public static readonly Surface CheckerBoard =
        new Surface(
            delegate (VectorPacket256 pos)
            {
                // test this
                var floored = ConvertToVector256Int32(Add(Floor(pos.Zs), Floor(pos.Xs)));
                var modMask = SetAllVector256<uint>(1);
                var evenMaskUint = Avx2.And(StaticCast<int, uint>(floored), modMask);
                var evenMask = Avx2.CompareEqual(evenMaskUint, modMask); 
                
                var white = new ColorPacket256(SetAllVector256(1.0f));
                var black = new ColorPacket256(new Vector(0.02f, 0.0f, 0.14f));

                var resultX = BlendVariable(black.Xs, white.Xs, StaticCast<uint, float>(evenMask));
                var resultY = BlendVariable(black.Ys, white.Ys, StaticCast<uint, float>(evenMask));
                var resultZ = BlendVariable(black.Zs, white.Zs, StaticCast<uint, float>(evenMask));

                return new ColorPacket256(resultX, resultY, resultZ);
            },
            delegate (VectorPacket256 pos) { return (new Color(1, 1, 1)).ToColorPacket256(); },
            delegate (VectorPacket256 pos)
            {
                // test this
                var floored = ConvertToVector256Int32(Add(Floor(pos.Zs), Floor(pos.Xs)));
                var modMask = SetAllVector256<uint>(1);
                var evenMaskUint = Avx2.And(StaticCast<int, uint>(floored), modMask);
                var evenMask = Avx2.CompareEqual(evenMaskUint, modMask);

                return BlendVariable(SetAllVector256(0.5f), SetAllVector256(0.1f), StaticCast<uint, float>(evenMask));
            },
            150f);



    public static readonly Surface Shiny =
        new Surface(
            delegate (VectorPacket256 pos) { return (new Color(1f, 1f, 1f)).ToColorPacket256(); },
            delegate (VectorPacket256 pos) { return (new Color(.5f, .5f, .5f)).ToColorPacket256(); },
            delegate (VectorPacket256 pos) { return SetAllVector256<float>(0.7f); },
            250f);

    public static readonly Surface MatteShiny =
        new Surface(
            delegate (VectorPacket256 pos) { return (new Color(1f, 1f, 1f)).ToColorPacket256(); },
            delegate (VectorPacket256 pos) { return (new Color(.25f, .25f, .25f)).ToColorPacket256(); },
            delegate (VectorPacket256 pos) { return SetAllVector256<float>(0.7f); },
            250f);
}