using ColorPacket = VectorPacket;

internal class PacketTracer
{
    public int Width {get; private set;}
    public int Hight {get; private set;}
    private static const int MaxDepth = 5;

    public PacketTracer(int _width, int _hight)
    {
        Width = _width;
        Hight = _hight;
    }

    internal unsafe void RenderVectorized(Scene scene, Color[] rgb)
    {
        Camera camera = scene.Camera;
        for (int y = 0; y < Hight; y++)
        {
            int stride = y * _screenWidth;
            for (int x = 0; x  < Width; x += VectorPacket.PacketSize)
            {
                Vector256<float> xs;
                fixed (int* pt = &x)
                {
                    xs = AVX.Load(pt);
                    xs = AVX.ConvertToVector256Float(xs);
                }
                var dirs = GetVectorPacket(xs, y, camera);
                var rayPacket = new RayPacket(new VectorPacket(camera.Pos, dirs), scene, 0);
                var colors = TraceRayVectorized(rayPacket, scene, 0);

                fixed (Color* output = &rgb[x + stride])
                {
                    // Writ into memory via xmm registers
                    var inSoA = colors.FastTranspose();
                    var m0 = (Vector128<float>)inSoA.xs;
                    var m1 = (Vector128<float>)inSoA.ys;
                    var m2 = (Vector128<float>)inSoA.zs;
                    var m3 = AVX.ExtractVector128(inSoA.xs, 1);
                    var m4 = AVX.ExtractVector128(inSoA.ys, 1);
                    var m5 = AVX.ExtractVector128(inSoA.zs, 1);


                    /* Writ into memory via ymm registers
                     */
                    var SoA = colors.Transpose();
                    
                }
            }
        }

    }

    private ColorPacket TraceRayVectorized(RayPacket rayPacket, Scene scene, int depth)
    {

    }

    private VectorPacket GetVectorPacket(Vector256<float> x, float y, Camera camera)
    {

    }
}