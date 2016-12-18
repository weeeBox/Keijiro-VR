using System;
using System.Collections.Generic;

using UnityEngine;

public partial class Sketch
{
    #region 3D Primitives

    /// <summary>
    /// A box is an extruded rectangle. A box with equal dimensions on all sides is a cube.
    /// </summary>
    /// <param name="size">Dimension of the box in all dimensions (creates a cube).</param>
    protected void box(float size)
    {
        box(size, size, size);
    }

    /// <summary>
    /// A box is an extruded rectangle. A box with equal dimensions on all sides is a cube.
    /// </summary>
    /// <param name="w">Dimension of the box in the x-dimension.</param>
    /// <param name="h">Dimension of the box in the y-dimension.</param>
    /// <param name="d">Dimension of the box in the z-dimension.</param>
    protected void box(float w, float h, float d)
    {
        AddPrimitive(Primitives.Box, new Vector3(w, h, d));
    }

    #endregion
}

