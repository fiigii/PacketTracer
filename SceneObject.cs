// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
//

internal abstract class SceneObject
{
    public Surface Surface;
    public abstract ObjectPacket256 ToPacket256();

    public SceneObject(Surface surface) { Surface = surface; }
}
