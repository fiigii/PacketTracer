using System.Runtime.CompilerServices.Intrinsics.Intel;
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

    public override Intersections Intersect(RayPacket rayPacket)
    {
        var intersections = NullIntersections(this);
        var eo = Centers - rayPacket.Starts;
        var v = VectorPacket.DotProduct(eo, rayPacket.Dirs);
        var zeroVMask = AVX.GetCompareVector256Float(v, AVX.SetZero<float>(), CompareLessThanOrderedNonSignaling);
        var allOneMask = AVX.CompareVector256Float(v, v, CompareNotEqualUnorderedNonSignaling);
        if(AVX.TestC(zeroVMask, allOneMask))
        {
            return intersections; // Null Intersections
        }

        var discs = AVX.Subtract(AVX.Multiply(Radiuses, Radiuses), AVX.Subtract(VectorPacket.DotProduct(eo, eo), AVX.Multiply(v, v)));
        var dists = AVX.Sqrt(discs);
        var zeroDiscMask = AVX.GetCompareVector256Float(discs, AVX.SetZero<float>(), CompareLessThanOrderedNonSignaling);

        var nullInter = AVX.Set1(Intersections.Null);
        var filterV = AVX.BlendVariable(dists, nullInter, zeroVMask);
        var filterD = AVX.BlendVariable(filterV, nullInter, zeroDiscMask);

        intersections.Distances = filterD;
        return intersections;
    }
}