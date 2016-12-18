using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : Sketch
{
    private float distance;

    protected override void draw()
    {
        int totalFrames = 24 * 4;
        float time = 1.0f / totalFrames * frameCount;

        // box(1);

        // scale(1, 2, 3);
        translate(2, 2, 2);
        box(1);

        distance += 0.1f;
    }
}
