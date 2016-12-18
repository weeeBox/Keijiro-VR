using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes9 : Sketch
{
    bool colored = true;

    protected override void setup()
    {
        size(500, 500, P3D);
        colorMode(HSB, 1);
        frameRate(24);
        stroke(0, 0, colored ? 0.4f : 0);
        smooth(4);
    }

    protected override void draw()
    {
        int totalFrames = 24 * 4;
        float time = 1.0f / totalFrames * frameCount;

        background(0.13f, colored ? 0.07f : 0.03f, 1);

        perspective(0.5f, 1, 0.01f, 100);

        camera(
            0, 0, 32 + sin(PI * 2 * time) * 5,
            0, 0, 0,
            0, 1, 0
        );

        rotateX(-0.8f + 0.1f * cos(PI * 2 * time));
        rotateZ( 0.8f + 0.1f * sin(PI * 2 * time));

        const int slice = 24;
        const int ring = 44;
        const int radius = 8;

        int id = 0;
        for (int i = 0; i <= slice; i++)
        {
            float theta = (1.0f * i / slice) % 1;
            theta = PI * (theta - 0.5f);

            for (int j = 0; j < ring; j++)
            {
                float phi = 2 * PI * j / ring;

                float s = cos(theta);
                float l = radius;

                s *= abs(abs(1.0f * id / 24 + time * 6) % 2 - 1);
                s *= 1.15f;

                if (colored) fill(s * 0.28f + 0.17f, 0.4f, 1);

                pushMatrix();
                rotateY(phi);
                rotateX(-theta);
                translate(0, 0, l);
                box(s, s, s);
                popMatrix();

                id++;
            }
        }

        // if (frameCount <= totalFrames) saveFrame();
    }
}
