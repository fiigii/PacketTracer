using System.Runtime.CompilerServices.Intrinsics.X86;
using System.Runtime.CompilerServices.Intrinsics;

internal class SpherePacket: ObjectPacket
{
    public VectorPacket Centers {get; private set;}
    public Vector256<float> Radiuses {get; private set;}

    public SpherePacket(Sphere sphere): base(sphere.Surface)
    {
        Centers = new VectorPacket(AVX.Set1(sphere.Center.X), AVX.Set1(sphere.Center.Y), AVX.Set1(sphere.Center.Z));
        Radiuses = AVX.Set1(sphere.Radius);
    }

    public override Intersections Intersect(RayPacket rayPacket, int index)
    {
        var intersections = Intersections.Null;
        var eo = Centers - rayPacket.Starts;
        var v = VectorPacket.DotProduct(eo, rayPacket.Dirs);
        var zeroVMask = AVX.CompareVector256Float(v, AVX.SetZero<float>(), FloatComparisonMode.CompareLessThanOrderedNonSignaling);
        var zero = AVX.SetZero<int>();
        var allOneMask = AVX2.CompareEqual(zero, zero); 
        if(AVX.TestC(zeroVMask, AVX.StaticCast<int, float>(allOneMask)))
        {
            return intersections; // Null Intersections
        }

        var discs = AVX.Subtract(AVX.Multiply(Radiuses, Radiuses), AVX.Subtract(VectorPacket.DotProduct(eo, eo), AVX.Multiply(v, v)));
        var dists = AVX.Sqrt(discs);
        var zeroDiscMask = AVX.CompareVector256Float(discs, AVX.SetZero<float>(), FloatComparisonMode.CompareLessThanOrderedNonSignaling);

        var nullInter = AVX.Set1(Intersections.NullValue);
        var filter = AVX.BlendVariable(dists, nullInter, AVX.Or(zeroVMask, zeroDiscMask));

        intersections.Distances = filter;
        intersections.ThingIndex = AVX.Set1<int>(index);
        return intersections;
    }

    public override VectorPacket Normal(VectorPacket pos)
    {
        var tmp = pos - Centers;
        return tmp.Normalize();
    }
}