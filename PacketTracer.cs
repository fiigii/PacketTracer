using System.Runtime.CompilerServices.Intrinsics.Intel;
using System.Runtime.CompilerServices.Intrinsics;

using ColorPacket = VectorPacket;

internal class PacketTracer
{
    public int Width {get; private set;}
    public int Hight {get; private set;}
    private const int MaxDepth = 5;

    public PacketTracer(int _width, int _hight)
    {
        Width = _width;
        Hight = _hight;
    }

    internal unsafe void RenderVectorized(Scene scene, int[] rgb)
    {
        Camera camera = scene.Camera;
        for (int y = 0; y < Hight; y++)
        {
            int stride = y * Hight;
            for (int x = 0; x  < Width; x += VectorPacket.PacketSize)
            {
                float fx = (float)x;
                Vector256<float> xs = AVX.Set(fx, fx+1, fx+2, fx+3, fx+4, fx+5, fx+6, fx+7);
                var dirs = GetVectorPacket(xs, AVX.Set1((float)y), camera);
                var rayPacket = new RayPacket(camera.PosPacket, dirs);
                var colors = TraceRay(rayPacket, scene, 0);

                // Writ into memory via xmm registers
                var SoA = colors.FastTranspose();
                var intSoA = SoA.ConvertToIntRGB();
                var m0 = (Vector128<int>)intSoA.Rs;
                var m1 = (Vector128<int>)intSoA.Gs;
                var m2 = (Vector128<int>)intSoA.Bs;
                var m3 = AVX2.ExtractVector128(intSoA.Rs, 1);
                var m4 = AVX2.ExtractVector128(intSoA.Gs, 1);
                var m5 = AVX2.ExtractVector128(intSoA.Bs, 1);
                
                fixed (int* output = &rgb[x + stride])
                {
                    

                }

                /* Writ into memory via ymm registers
                var SoA = colors.Transpose();
                var intSoA = SoA.ConvertToIntRGB();
                */
            }
        }

    }

    private ColorPacket TraceRay(RayPacket rayPacket, Scene scene, int depth)
    {

    }

    private Intersections MinIntersections(RayPacket rayPacket, Scene scene)
    {
        Intersect mins = Intersections.Null;
        int index = 0
        foreach (SceneObject obj in scene.Things)
        {
            var objPacket = obj.ToPacket();
            var orgIsect = objPacket.Intersect(rayPacket);
            if (!orgIsect.AllNullIntersections())
            {
                var nullMinMask = AVX.CompareVector256Float(min, Intersections.Null, CompareEqualOrderedNonSignaling);
                var lessMinMask = AVX.CompareVector256Float(min, orgIsect, CompareGreaterThanOrderedNonSignaling);
                min
            }
            index++;
        }
    }

    private VectorPacket GetVectorPacket(Vector256<float> x, Vector256<float> y, Camera camera)
    {
        float widthRate1 = Width / 2.0f;
        float widthRate2 = Width * 2.0f;

        float hightRate1 = Hight / 2.0f;
        float hightRate2 = Hight * 2.0f;

        var recenteredX = AVX.Divide(AVX.Subtract(x, AVX.Set1(widthRate1)), AVX.Set1(widthRate2));
        var recenteredY = AVX.Subtract(AVX.SetZero<float>(), AVX.Divide(AVX.Subtract(y, AVX.Set1(hightRate1)), AVX.Set1(hightRate2)));

        var result = camera.ForwardPacket + 
                    (new VectorPacket(recenteredX) * camera.RightPacket) +
                    (new VectorPacket(recenteredY) * camera.UpPacket);

        return result.Normalize();
    }
}