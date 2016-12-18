using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes4 : Processing
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
        float t2 = t - 1;

        noiseDetail(1);

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
        float freq = 0.5f;
        for (int ix = 0; ix < columns; ix++)
        {
            float x = ix - 0.5f * columns + 0.5f;
            for (int iy = 0; iy < columns; iy++)
            {
                float y = iy - 0.5f * columns + 0.5f;
                for (int iz = 0; iz < columns; iz++)
                {
                    float z = iz - 0.5f * columns + 0.5f;

                    float n1 = noise(x * freq + t  * 6, y * freq, z * freq + t  * 2);
                    float n2 = noise(x * freq + t2 * 6, y * freq, z * freq + t2 * 2);
                    float s = constrain(lerp(n1, n2, t) * 6 - 1.5f, 0, 1);

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
