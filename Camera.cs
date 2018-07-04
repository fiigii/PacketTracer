using System.Runtime.Intrinsics.X86;
using static System.Runtime.Intrinsics.X86.Avx;
using System.Runtime.Intrinsics;
internal class Camera
{

    public Camera(VectorPacket256 pos, VectorPacket256 forward, VectorPacket256 up, VectorPacket256 right) { Pos = pos; Forward = forward; Up = up; Right = right; }

    public VectorPacket256 Pos {get; private set;}
    public VectorPacket256 Forward {get; private set;}
    public VectorPacket256 Up {get; private set;}
    public VectorPacket256 Right {get; private set;}

    public static Camera Create(Vector pos, Vector lookAt)
    {
        VectorPacket256 posPacket256 = new VectorPacket256(pos);
        VectorPacket256 lookAtPacket256 = new VectorPacket256(lookAt);
        VectorPacket256 forward = (lookAtPacket256 - posPacket256).Normalize();
        VectorPacket256 down = new VectorPacket256(SetAllVector256<float>(0), SetAllVector256<float>(-1), SetAllVector256<float>(0));
        VectorPacket256 right = SetAllVector256<float>(1.5f) * VectorPacket256.CrossProduct(forward, down).Normalize();
        VectorPacket256 up = SetAllVector256<float>(1.5f) * VectorPacket256.CrossProduct(forward, right).Normalize();

        return new Camera(posPacket256, forward, up, right);
    }
    
}

