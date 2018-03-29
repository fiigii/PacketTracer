using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;

internal class SpherePacket256: ObjectPacket256
{
    public VectorPacket256 Centers {get; private set;}
    public Vector256<float> Radiuses {get; private set;}

    public SpherePacket256(Sphere sphere): base(sphere.Surface)
    {
        Centers = new VectorPacket256(Avx.SetAllVector256(sphere.Center.X), Avx.SetAllVector256(sphere.Center.Y), Avx.SetAllVector256(sphere.Center.Z));
        Radiuses = Avx.SetAllVector256(sphere.Radius);
    }

    public override Intersections Intersect(RayPacket256 rayPacket256, int index)
    {
        var intersections = Intersections.Null;
        var eo = Centers - rayPacket256.Starts;
        var v = VectorPacket256.DotProduct(eo, rayPacket256.Dirs);
        var zeroVMask = Avx.Compare(v, Avx.SetZeroVector256<float>(), FloatComparisonMode.LessThanOrderedNonSignaling);
        var zero = Avx.SetZeroVector256<int>();
        var allOneMask = Avx2.CompareEqual(zero, zero); 
        if(Avx.TestC(zeroVMask, Avx.StaticCast<int, float>(allOneMask)))
        {
            return intersections; // Null Intersections
        }

        var discs = Avx.Subtract(Avx.Multiply(Radiuses, Radiuses), Avx.Subtract(VectorPacket256.DotProduct(eo, eo), Avx.Multiply(v, v)));
        var dists = Avx.Sqrt(discs);
        var zeroDiscMask = Avx.Compare(discs, Avx.SetZeroVector256<float>(), FloatComparisonMode.LessThanOrderedNonSignaling);

        var nullInter = Avx.SetAllVector256(Intersections.NullValue);
        var filter = Avx.BlendVariable(dists, nullInter, Avx.Or(zeroVMask, zeroDiscMask));

        intersections.Distances = filter;
        intersections.ThingIndex = Avx.SetAllVector256<int>(index);
        return intersections;
    }

    public override VectorPacket256 Normal(VectorPacket256 pos)
    {
        var tmp = pos - Centers;
        return tmp.Normalize();
    }
}