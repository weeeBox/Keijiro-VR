using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : Processing
{
    protected override void setup()
    {
        size(500, 500, P3D);
        //frameRate(24);
        //cube = createShape(BOX, 1, 1, 1);
    }

    protected override void draw()
    {
        int frames = 24 * 4;
        float t = (float)frameCount / frames;

        background(255);

        perspective(0.5f, 1, 0.01f, 100);

        camera(
          0, 0, 40 + sin(PI * 2 * t) * 10,
          0, 0, 0,
          0, 1, 0
        );

        rotateX(-0.5f - 0.15f * sin(PI * 4 * t));
        rotateY(-0.5f - 0.15f * cos(PI * 2 * t));

        int columns = 15;
        for (int ix = 0; ix < columns; ix++)
        {
            float x = (ix - 0.5f * columns + 0.5f) * 1.2f;

            for (int iy = 0; iy < columns; iy++)
            {
                float y = (iy - 0.5f * columns + 0.5f) * 1.2f;
                float d = sqrt(x * x + y * y);
                float z = sin(d * 0.45f + t * 4 * PI);
                z = z * z * z * 2;

                pushMatrix();
                translate(x, z, y);
                box(1, 1, 1);
                popMatrix();
            }
        }
    }
}
