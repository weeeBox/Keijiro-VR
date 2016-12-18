using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes6 : Sketch
{
    protected override void setup()
    {
        size(500, 500, P3D);
        colorMode(HSB, 1);
        frameRate(24);
        stroke(0, 0, 0.4f);
    }

    protected override void draw()
    {
        int columns = 8;
        int totalFrames = 74;
        float time = 1.0f / totalFrames * frameCount;
        float time2 = max(0, (time % 1) - 0.25f) / 0.75f;
        float param = 0.5f - 0.5f * cos(time2 * PI * 2);

        background(0.15f, 0.05f, 1);

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
        for (int iz = 0; iz < columns; iz++)
        {
            float z = 0.5f - (iz + 0.5f) / columns;
            for (int iy = 0; iy < columns; iy++)
            {
                float y = (iy + 0.5f) / columns - 0.5f;
                for (int ix = 0; ix < columns; ix++)
                {
                    float x = 0.5f - (ix + 0.5f) / columns;
                    float s = abs(((id * PI / 17 + time * 6) % 2) - 1);

                    fill(lerp(0.3f, 0, s) + param * 0.2f, 0.7f - 0.2f * param, 1);

                    float px = lerp(x, random(-1, 1), param);
                    float py = lerp(y, random(-1, 1), param);
                    float pz = lerp(z, random(-1, 1), param);

                    float rx = random(-1, 1) * PI * 2 * param;
                    float ry = random(-1, 1) * PI * 2 * param;
                    float rz = random(-1, 1) * PI * 2 * param;

                    s /= columns;

                    pushMatrix();
                    translate(px, py, pz);
                    rotateX(rx);
                    rotateY(ry);
                    rotateZ(rz);
                    box(s, s, s);
                    popMatrix();

                    id++;
                }
            }
        }

        // if (frameCount <= totalFrames) saveFrame();
    }
}
