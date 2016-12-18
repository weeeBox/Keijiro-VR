using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes8 : Processing
{
    [SerializeField]
    bool colored = true;

    protected override void setup()
    {
        // size(500, 500, P3D);
        // colorMode(HSB, 1);
        frameRate(24);
        // stroke(0, 0, colored ? 0.4 : 0);
        // smooth(4);
    }

    protected override void draw()
    {
        int totalFrames = 24 * 4;
        float time = 1.0f / totalFrames * frameCount;

        /*
        if (colored)
            background(0.25, 0.05, 1);
        else
            background(0.03, 0.07, 1);
        */

        /*
        randomSeed(1);
        noiseDetail(1);

        perspective(0.5, 1, 0.01, 100);

        camera(
            0, 0, 35 + sin(PI * 2 * time) * 4,
            0, 0, 0,
            0, 1, 0
        );
        */

        rotateX(-0.8f + 0.2f * cos(PI * 2 * time));
        rotateZ(0.8f + 0.3f * sin(PI * 2 * time));

        const int slice = 30;
        const int ring = 26;
        const int radius = 4;

        int id = 0;
        for (int i = 0; i < slice; i++)
        {
            float y = i - slice / 2 + 0.5f;
            float em = sin(i * 0.2f + time * PI * 2) * 0.5f + 0.6f;

            for (int j = 0; j < ring; j++)
            {
                float phi = 2 * PI * j / ring;

                float l = lerp(0.5f, 1.2f, em) * radius;
                float s = lerp(0.4f, 1.1f, em);

                s *= abs((id * 0.07151f + time * 6) % 2 - 1);

                 if (colored)
                    fill(1 - s * 0.6f, 0.4f, 1);

                pushMatrix();
                translate(0, y, 0);
                rotateY(phi);
                translate(0, 0, l);
                box(s, s, s);
                popMatrix();

                id++;
            }
        }
    }
}
