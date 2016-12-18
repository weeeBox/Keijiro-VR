using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes5 : Sketch
{
    bool colored = true;

    protected override void setup()
    {
        size(400, 400, P3D);
        colorMode(HSB, 1);
        frameRate(24);

        if (colored) stroke(0, 0, 0.4f);
    }

    protected override void draw()
    {
        int columns = 8;
        int totalFrames = 64;
        float time = 1.0f / totalFrames * frameCount;

        if (colored)
            background(0.15f, 0.05f, 1);
        else
            background(1);

        randomSeed(10);

        perspective(0.5f, 1, 0.01f, 100);

        camera(
            0, 0, 3.2f + sin(PI * 2 * time) * 0.5f,
            0, 0, 0,
            0, 1, 0
        );

        rotateX(-0.5f - 0.05f * sin(PI * 4 * time));
        rotateY(-0.5f - 0.15f * cos(PI * 2 * time));

        int id = 0;
        for (int ix = 0; ix < columns; ix++)
        {
            float x = (ix + 0.5f) / columns - 0.5f;
            for (int iy = 0; iy < columns; iy++)
            {
                float y = (iy + 0.5f) / columns - 0.5f;
                for (int iz = 0; iz < columns; iz++)
                {
                    float z = (iz + 0.5f) / columns - 0.5f;
                    float s = abs(((id * PI / 17 + time * 4) % 2) - 1);

                    if (colored) fill(lerp(0.5f, 0.2f, s), lerp(0.7f, 0.5f, s), lerp(0.8f, 1, s));

                    pushMatrix();
                    translate(x, y, z);
                    s /= columns;
                    box(s, s, s);
                    popMatrix();

                    id++;
                }
            }
        }

        // if (frameCount <= totalFrames) saveFrame();
    }
}
