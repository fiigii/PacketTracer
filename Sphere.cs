// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
//

internal class Sphere : SceneObject
{
    public Vector Center;
    public float Radius;

    public Sphere(Vector center, double radius, Surface surface) : base(surface) { Center = center; Radius = (float)radius; }

    public override ObjectPacket256 ToPacket256()
    {
        return new SpherePacket256(this);
    }

}
