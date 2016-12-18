using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes2 : Processing
{
    protected override void setup()
    {
        colorMode(RGB, 1);
        size(500, 500, P3D);
        frameRate(24);
    }

    protected override void draw()
    {
        int frames = 24 * 3;
        float t = (float)frameCount / frames;

        background(1);

        perspective(0.5f, 1, 0.01f, 100);

        camera(
            0, 0, 25 + sin(PI * 2 * t) * 3,
            0, 0, 0,
            0, 1, 0
        );

        rotateX(-0.5f - 0.05f * sin(PI * 4 * t));
        rotateY(-0.5f - 0.05f * cos(PI * 2 * t));

        int columns = 8;
        for (int ix = 0; ix < columns; ix++)
        {
            float x = ix - 0.5f * columns + 0.5f;
            for (int iy = 0; iy < columns; iy++)
            {
                float y = iy - 0.5f * columns + 0.5f;
                for (int iz = 0; iz < columns; iz++)
                {
                    float z = iz - 0.5f * columns + 0.5f;

                    float d = sqrt(x * x + y * y + z * z);
                    float s = abs(sin(d - t * 4 * PI));

                    pushMatrix();
                    translate(x, z, y);
                    box(s);
                    popMatrix();
                }
            }
        }

        //if (frameCount <= frames) saveFrame();
    }
}
