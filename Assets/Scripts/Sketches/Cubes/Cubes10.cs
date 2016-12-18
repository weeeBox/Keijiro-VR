using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes10 : Sketch
{
    protected override void setup()
    {
        size(500, 500, P3D);
        colorMode(HSB, 1);
        frameRate(24);
        stroke(0, 0, 0.2f);
        smooth(4);
    }

    protected override void draw()
    {
        int totalFrames = 24 * 4;
        float time = 1.0f / totalFrames * frameCount;

        background(0.13f, 0.07f, 1);

        perspective(0.5f, 1, 0.01f, 100);

        camera(
            0, 0, 18 + sin(PI * 2 * time) * 1.5f,
            0, 0, 0,
            0, 1, 0
        );

        rotateX(0.11f * cos(PI * 2 * time) - 1.1f);
        rotateZ(0.11f * sin(PI * 2 * time));

        const int points = 52;
        const int rings = 22;
        const float radius = 9;

        int id = 0;
        for (int i = 0; i < rings; i++)
        {
            float s = pow(1.0f / rings * i, 2);
            float l = radius * s;

            for (int j = 0; j < points; j++)
            {
                float phi = 2 * PI * j / points;
                float a = abs((abs(1.0f / 23 * id - time * 6) % 2) - 1);
                float s2 = a + 0.15f;

                fill(lerp(0, 0.2f, a), 0.35f, 1);

                pushMatrix();
                rotateY(phi);
                translate(0, 0, l);
                box(s2 * s, s2 * s, s2 * s);
                popMatrix();

                id++;
            }
        }

        //  if (frameCount <= totalFrames) saveFrame();
    }
}
