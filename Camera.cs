// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
//

using System.Runtime.Intrinsics.X86;
using static System.Runtime.Intrinsics.X86.Avx;
using System.Runtime.Intrinsics;
internal class Camera
{

    public Camera(VectorPacket256 pos, VectorPacket256 forward, VectorPacket256 up, VectorPacket256 right) { Pos = pos; Forward = forward; Up = up; Right = right; }

    public VectorPacket256 Pos;
    public VectorPacket256 Forward;
    public VectorPacket256 Up;
    public VectorPacket256 Right;

    public static Camera Create(VectorPacket256 pos, VectorPacket256 lookAt)
    {
        VectorPacket256 forward = (lookAt - pos).Normalize();
        VectorPacket256 down = new VectorPacket256(SetAllVector256<float>(0), SetAllVector256<float>(-1), SetAllVector256<float>(0));
        VectorPacket256 right = SetAllVector256<float>(1.5f) * VectorPacket256.CrossProduct(forward, down).Normalize();
        VectorPacket256 up = SetAllVector256<float>(1.5f) * VectorPacket256.CrossProduct(forward, right).Normalize();

        return new Camera(pos, forward, up, right);
    }
    
}

