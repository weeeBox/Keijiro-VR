using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : Sketch
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
            0, 0, 40,
            0, 0, 0,
            0, 1, 0
        );

        rotateX(-0.5f + sin(PI * 4 * t) * 0.05f);
        rotateY(-0.5f + sin(PI * 2 * t) * 0.1f);

        int columns = 16;

        float offs = 0.5f * columns - 0.5f;
        translate(-offs, 3, -offs);

        for (int ix = 0; ix < columns; ix++)
        {
            for (int iy = 0; iy < columns; iy++)
            {
                pushMatrix();
                translate(ix, 0, iy);

                float w = random(0.2f, 0.9f);
                float h = w * random(2, 6);

                float dx = random(-0.5f, 0.5f) * (1 - w);
                float dy = random(-0.5f, 0.5f) * (1 - w);

                translate(dx, 0, dy);
                drawUnit(w, h, 1, (int)random(2, 8));

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

        w *= random(0.5f, 0.9f);
        h *= random(0.2f, 0.8f);

        drawUnit(w, h, lv + 1, maxLv);
    }
}
