using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure2 : Processing
{
    protected override void setup()
    {
        size(500, 500, P3D);
        colorMode(RGB, 1);
    }

    protected override void draw()
    {
        int totalFrames = 24 * 3;
        float t = (float)frameCount / totalFrames;

        randomSeed(0);

        background(1);

        perspective(0.5f, 1, 0.01f, 100);

        camera(
            0, 0, 10,
            0, 0, 0,
            0, 1, 0
        );

        rotateX(-0.5f + sin(PI * 4 * t) * 0.05f);
        rotateY(-0.5f + sin(PI * 2 * t) * 0.1f);

        int columns = 4;

        float offs = 0.5f * columns - 0.5f;
        translate(-offs, 1, -offs);

        for (int ix = 0; ix < columns; ix++)
        {
            for (int iy = 0; iy < columns; iy++)
            {
                pushMatrix();
                translate(ix, 0, iy);

                float w = random(0.95f, 1.0f);
                float h = random(0.1f, 0.6f);
                drawUnit(w, h, 1, (int)random(4, 6));

                popMatrix();
            }
        }

        //if (frameCount <= totalFrames) saveFrame();
    }

    void drawUnit(float w, float h, int lv, int maxLv)
    {
        if (lv >= maxLv) return;

        translate(0, -0.5f * h, 0);
        box(w, h, w);
        translate(0, -0.5f * h, 0);

        for (int i = 0; i < 4; i++)
        {
            float w2 = w * 0.5f * random(0.9f, 1);
            float h2 = h * random(0.1f, 1.6f);

            float dx = w * 0.5f * ((i / 2) - 0.5f);
            float dy = w * 0.5f * ((i & 1) - 0.5f);

            int maxLv2 = maxLv + (int)random(-1, 1.1f);

            pushMatrix();
            translate(dx, 0, dy);
            drawUnit(w2, h2, lv + 1, maxLv2);
            popMatrix();
        }
    }
}
