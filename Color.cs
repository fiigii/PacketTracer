// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
//

using System.Runtime.Intrinsics;
using static System.Runtime.Intrinsics.X86.Avx;
using System.Runtime.CompilerServices;

internal struct Color
{
    public float R { get; private set; }
    public float G { get; private set; }
    public float B { get; private set; }

    public static readonly Color Background = new Color(0, 0, 0);

    public Color(float _r, float _g, float _b)
    {
        R = _r;
        G = _g;
        B = _b;
    }
}
