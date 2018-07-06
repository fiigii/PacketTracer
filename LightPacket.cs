// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
//

using ColorPacket256 = VectorPacket256;

internal class LightPacket256
{
    public VectorPacket256 Positions;
    public ColorPacket256 Colors;

    public LightPacket256(Vector pos, Color col)
    {
        Positions = new VectorPacket256(pos.X, pos.Y, pos.Z);
        Colors = col.ToColorPacket256();
    }
}