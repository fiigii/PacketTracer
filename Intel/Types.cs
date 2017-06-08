using System;
using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices.Intrinsics
{
    // 128 bit types
    [StructLayout(LayoutKind.Sequential, Size = 16)]
    public struct Vector128<T> where T : struct {}

    // 256 bit types
    [StructLayout(LayoutKind.Sequential, Size = 32)]
    public struct Vector256<T> where T : struct {}
}