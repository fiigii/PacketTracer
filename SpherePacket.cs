using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;

internal class SpherePacket: ObjectPacket
{
    public VectorPacket Centers {get; private set;}
    public Vector256<float> Radiuses {get; private set;}

    public SpherePacket(Sphere sphere): base(sphere.Surface)
    {
        Centers = new VectorPacket(Avx.Set1(sphere.Center.X), Avx.Set1(sphere.Center.Y), Avx.Set1(sphere.Center.Z));
        Radiuses = Avx.Set1(sphere.Radius);
    }

    public override Intersections Intersect(RayPacket rayPacket, int index)
    {
        var intersections = Intersections.Null;
        var eo = Centers - rayPacket.Starts;
        var v = VectorPacket.DotProduct(eo, rayPacket.Dirs);
        var zeroVMask = Avx.Compare(v, Avx.SetZero<float>(), FloatComparisonMode.LessThanOrderedNonSignaling);
        var zero = Avx.SetZero<int>();
        var allOneMask = Avx2.CompareEqual(zero, zero); 
        if(Avx.TestC(zeroVMask, Avx.StaticCast<int, float>(allOneMask)))
        {
            return intersections; // Null Intersections
        }

        var discs = Avx.Subtract(Avx.Multiply(Radiuses, Radiuses), Avx.Subtract(VectorPacket.DotProduct(eo, eo), Avx.Multiply(v, v)));
        var dists = Avx.Sqrt(discs);
        var zeroDiscMask = Avx.Compare(discs, Avx.SetZero<float>(), FloatComparisonMode.LessThanOrderedNonSignaling);

        var nullInter = Avx.Set1(Intersections.NullValue);
        var filter = Avx.BlendVariable(dists, nullInter, Avx.Or(zeroVMask, zeroDiscMask));

        intersections.Distances = filter;
        intersections.ThingIndex = Avx.Set1<int>(index);
        return intersections;
    }

    public override VectorPacket Normal(VectorPacket pos)
    {
        var tmp = pos - Centers;
        return tmp.Normalize();
    }
}