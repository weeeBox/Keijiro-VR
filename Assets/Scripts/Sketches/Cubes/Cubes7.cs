using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes7 : Sketch
{
    float smoothstep(float x, float low, float high)
    {
        x = constrain((x - low) / (high - low), 0, 1);
        return (3 - 2 * x) * x * x;
    }

    protected override void setup()
    {
        size(500, 500, P3D);
        colorMode(HSB, 1);
        frameRate(24);
        stroke(0, 0, 0);
    }

    protected override void draw()
    {
        int totalFrames = 24 * 5;
        float time = 1.0f / totalFrames * frameCount;

        background(0, 0, 1);

        randomSeed(1);
        noiseDetail(0);

        perspective(0.5f, 1, 0.01f, 100);

        camera(
            0, 0, 3.2f + sin(PI * 2 * time) * 0.5f,
            0, 0, 0,
            0, 1, 0
        );

        rotateX(-0.9f + 0.4f * cos(PI * 2 * time));
        rotateZ(0.3f * sin(PI * 1.8f * time));

        for (int i = 0; i < 300; i++)
        {
            float y = random(-1, 1);
            y *= smoothstep(time, 0, 0.1f);
            y *= smoothstep(time, 1, 0.9f);

            float l = random(0.2f, 0.7f);
            l *= smoothstep(time, 0.05f, 0.5f);
            l *= smoothstep(time, 0.9f, 0.8f);

            float omega = random(6, 20);
            float phi = omega * (time + 0.2f);

            float s = noise(i * 0.132f + time) * 0.2f;
            s *= smoothstep(time, 0, 0.05f);
            s *= smoothstep(time, 1, 0.95f);

            pushMatrix();
            translate(0, y, 0);
            rotateY(phi);
            translate(0, 0, l);
            box(s, s, s);
            popMatrix();
        }

        //if (frameCount <= totalFrames + 8) saveFrame();
    }
}
