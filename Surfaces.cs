using System.Runtime.CompilerServices.Intrinsics;
using System.Runtime.CompilerServices.Intrinsics.Intel;
using ColorPacket = VectorPacket;

using System;

internal static class Surfaces
{
    // Only works with X-Z plane.
    public static readonly Surface CheckerBoard =
        new Surface(
            delegate (VectorPacket pos)
            {
                var floored = AVX.Add(AVX.Floor(pos.zs), AVX.Floor(pos.xs));
                var modMask = AVX.Set1<uint>(1);
                var evenMaskUint = AVX2.And(StaticCast<float, uint>(floored), modMask);
                var evenMask = AVX2.CompareEqual(evenMask, modMask);
                
                var white = new ColorPacket(AVX.Set1(1.0f));
                var black = new ColorPacket(new Vector(0.02f, 0.0f, 0.14f));

                var resultX = AVX.BlendVariable(black.xs, white.xs, StaticCast<uint, float>(evenMask));
                var resultY = AVX.BlendVariable(black.ys, white.ys, StaticCast<uint, float>(evenMask));
                var resultZ = AVX.BlendVariable(black.zs, white.zs, StaticCast<uint, float>(evenMask));

                return new ColorPacket(resultX, resultY, resultZ);
            }
            delegate (VectorPacket pos) { return (new Color(1, 1, 1)).ToColorPacket(); },
            delegate (VectorPacket pos)
            {
                var floored = AVX.Add(AVX.Floor(pos.zs), AVX.Floor(pos.xs));
                var modMask = AVX.Set1<uint>(1);
                var evenMaskUint = AVX2.And(StaticCast<float, uint>(floored), modMask);
                var evenMask = AVX2.CompareEqual(evenMask, modMask);

                return AVX.BlendVariable(AVX.Set1(0.5f), AVX.Set1(0.1f), StaticCast<uint, float>(evenMask));
            },
            150f);



    public static readonly Surface Shiny =
        new Surface(
            delegate (VectorPacket pos) { return (new Color(1f, 1f, 1f)).ToColorPacket(); },
            delegate (VectorPacket pos) { return (new Color(.5f, .5f, .5f)).ToColorPacket(); },
            delegate (VectorPacket pos) { return new ColorPacket(AVX.Set1<float>(0.7f)); },
            250f);

    public static readonly Surface MatteShiny =
        new Surface(
            delegate (VectorPacket pos) { return (new Color(1f, 1f, 1f)).ToColorPacket(); },
            delegate (VectorPacket pos) { return (new Color(.25f, .25f, .25f)).ToColorPacket(); },
            delegate (VectorPacket pos) { return new ColorPacket(AVX.Set1<float>(0.7f)); },
            250f);
}