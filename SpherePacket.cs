using System.Runtime.Intrinsics.X86;
using static System.Runtime.Intrinsics.X86.Avx;
using System.Runtime.Intrinsics;

internal class SpherePacket256 : ObjectPacket256
{
    public VectorPacket256 Centers { get; private set; }
    public Vector256<float> Radiuses { get; private set; }


    public SpherePacket256(Sphere sphere) : base(sphere.Surface)
    {
        Centers = new VectorPacket256(SetAllVector256(sphere.Center.X), SetAllVector256(sphere.Center.Y), SetAllVector256(sphere.Center.Z));
        Radiuses = SetAllVector256(sphere.Radius);
    }

    public override VectorPacket256 Normals(VectorPacket256 pos)
    {
        return (pos - Centers).Normalize();
    }

    public override Vector256<float> Intersect(RayPacket256 rayPacket256)
    {
        var eo = Centers - rayPacket256.Starts;
        var v = VectorPacket256.DotProduct(eo, rayPacket256.Dirs);

        var zeroVMask = Compare(v, SetZeroVector256<float>(), FloatComparisonMode.LessThanOrderedSignaling);
        var zero = SetZeroVector256<int>();
        var allOneMask = Avx2.CompareEqual(zero, zero);
        if (TestC(zeroVMask, StaticCast<int, float>(allOneMask)))
        {
            return Intersections.Null.Distances; // Null Intersections
        }

        var discs = Subtract(Multiply(Radiuses, Radiuses), Subtract(VectorPacket256.DotProduct(eo, eo), Multiply(v, v)));
        var zeroDiscMask = Compare(discs, SetZeroVector256<float>(), FloatComparisonMode.LessThanOrderedSignaling);
        var dists = BlendVariable(Subtract(v, Sqrt(discs)), SetZeroVector256<float>(), Or(zeroVMask, zeroDiscMask));

        return BlendVariable(dists, SetZeroVector256<float>(), zeroVMask);
    }
}