using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
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
                var floored = Avx.ConvertToVector256Int32(Avx.Add(Avx.Floor(pos.zs), Avx.Floor(pos.xs)));
                var modMask = Avx.SetAllVector256<uint>(1);
                var evenMaskUint = Avx2.And(Avx.StaticCast<int, uint>(floored), modMask);
                var evenMask = Avx2.CompareEqual(evenMaskUint, modMask); 
                
                var white = new ColorPacket256(Avx.SetAllVector256(1.0f));
                var black = new ColorPacket256(new Vector(0.02f, 0.0f, 0.14f));

                var resultX = Avx.BlendVariable(black.xs, white.xs, Avx.StaticCast<uint, float>(evenMask));
                var resultY = Avx.BlendVariable(black.ys, white.ys, Avx.StaticCast<uint, float>(evenMask));
                var resultZ = Avx.BlendVariable(black.zs, white.zs, Avx.StaticCast<uint, float>(evenMask));

                return new ColorPacket256(resultX, resultY, resultZ);
            },
            delegate (VectorPacket256 pos) { return (new Color(1, 1, 1)).ToColorPacket256(); },
            delegate (VectorPacket256 pos)
            {
                // test this
                var floored = Avx.ConvertToVector256Int32(Avx.Add(Avx.Floor(pos.zs), Avx.Floor(pos.xs)));
                var modMask = Avx.SetAllVector256<uint>(1);
                var evenMaskUint = Avx2.And(Avx.StaticCast<int, uint>(floored), modMask);
                var evenMask = Avx2.CompareEqual(evenMaskUint, modMask);

                return Avx.BlendVariable(Avx.SetAllVector256(0.5f), Avx.SetAllVector256(0.1f), Avx.StaticCast<uint, float>(evenMask));
            },
            150f);



    public static readonly Surface Shiny =
        new Surface(
            delegate (VectorPacket256 pos) { return (new Color(1f, 1f, 1f)).ToColorPacket256(); },
            delegate (VectorPacket256 pos) { return (new Color(.5f, .5f, .5f)).ToColorPacket256(); },
            delegate (VectorPacket256 pos) { return Avx.SetAllVector256<float>(0.7f); },
            250f);

    public static readonly Surface MatteShiny =
        new Surface(
            delegate (VectorPacket256 pos) { return (new Color(1f, 1f, 1f)).ToColorPacket256(); },
            delegate (VectorPacket256 pos) { return (new Color(.25f, .25f, .25f)).ToColorPacket256(); },
            delegate (VectorPacket256 pos) { return Avx.SetAllVector256<float>(0.7f); },
            250f);
}