// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
//

using System;

internal static class Surfaces
{
    // Only works with X-Z plane.
    public static readonly Surface CheckerBoard =
        new Surface(
            delegate (Vector pos)
            {
                return ((Math.Floor(pos.Z) + Math.Floor(pos.X)) % 2 != 0)
             ? new Color(1f, 1f, 1f)
             : new Color(0.02f, 0.0f, 0.14f);
            },
            delegate (Vector pos) { return new Color(1, 1, 1); },
            delegate (Vector pos)
            {
                return ((Math.Floor(pos.Z) + Math.Floor(pos.X)) % 2 != 0)
             ? .1f
             : .5f;
            },
            150f);



    public static readonly Surface Shiny =
        new Surface(
            delegate (Vector pos) { return new Color(1f, 1f, 1f); },
            delegate (Vector pos) { return new Color(.5f, .5f, .5f); },
            delegate (Vector pos) { return .7f; },
            250f);

    public static readonly Surface MatteShiny =
        new Surface(
            delegate (Vector pos) { return new Color(1f, 1f, 1f); },
            delegate (Vector pos) { return new Color(.25f, .25f, .25f); },
            delegate (Vector pos) { return .7f; },
            250f);
}