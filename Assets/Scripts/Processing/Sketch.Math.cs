﻿using System;
using UnityEngine;

using Random = UnityEngine.Random;

public partial class Sketch
{
    protected const float PI = 3.1415927f;

    #region Calculation

    /// <summary>
    /// Calculates the absolute value (magnitude) of a number. The absolute value of a number is always positive.
    /// </summary>
    protected int abs(int n)
    {
        return Mathf.Abs(n);
    }

    /// <summary>
    /// Calculates the absolute value (magnitude) of a number. The absolute value of a number is always positive.
    /// </summary>
    protected float abs(float n)
    {
        return Mathf.Abs(n);
    }

    /// <summary>
    /// Calculates the closest int value that is greater than or equal to the value of the parameter. 
    /// For example, ceil(9.03) returns the value 10.
    /// </summary>
    protected int ceil(float n)
    {
        return (int)Mathf.Ceil(n);
    }

    /// <summary>
    /// Constrains a value to not exceed a maximum and minimum value.
    /// </summary>
    /// <param name="amt">the value to constrain</param>
    /// <param name="low">minimum limit</param>
    /// <param name="high">maximum limit</param>
    protected float constrain(float amt, float low, float high)
    {
        return Mathf.Clamp(amt, low, high);
    }

    /// <summary>
    /// Constrains a value to not exceed a maximum and minimum value.
    /// </summary>
    /// <param name="amt">the value to constrain</param>
    /// <param name="low">minimum limit</param>
    /// <param name="high">maximum limit</param>
    protected int constrain(int amt, int low, int high)
    {
        return Mathf.Clamp(amt, low, high);
    }

    //    dist()
    //    exp()
    //    floor()

    /// <summary>
    /// Calculates a number between two numbers at a specific increment. The amt parameter is the amount 
    /// to interpolate between the two values where 0.0 equal to the first point, 0.1 is very near the 
    /// first point, 0.5 is half-way in between, etc. The lerp function is convenient for creating motion 
    /// along a straight path and for drawing dotted lines.
    /// </summary>
    protected float lerp(float start, float stop, float amt)
    {
        return Mathf.Lerp(start, stop, amt);
    }

    //    log()
    //    mag()
    //    map()


    /// <summary>
    /// Determines the largest value in a sequence of numbers, and then returns that value. max() accepts either two or three float or int values as parameters, or an array of any length.
    /// </summary>
    protected float max(float a, float b)
    {
        return Mathf.Max(a, b);
    }

    /// <summary>
    /// Determines the largest value in a sequence of numbers, and then returns that value. max() accepts either two or three float or int values as parameters, or an array of any length.
    /// </summary>
    protected float max(int a, int b)
    {
        return Mathf.Max(a, b);
    }

    //    min()
    //    norm()

    /// <summary>
    /// Facilitates exponential expressions. The pow() function is an efficient way of multiplying numbers by themselves (or their reciprocals) in large quantities. For example, pow(3, 5) is equivalent to the expression 3*3*3*3*3 and pow(3, -5) is equivalent to 1 / 3*3*3*3*3.
    /// </summary>
    protected float pow(float n, float e)
    {
        return Mathf.Pow(n, e);
    }

    //    round()
    //    sq()

    /// <summary>
    /// Calculates the square root of a number. The square root of a number is always positive, even though there may be a valid negative root. The square root s of number a is such that s*s = a. It is the opposite of squaring.
    /// </summary>
    /// <returns></returns>
    protected float sqrt(float n)
    {
        return Mathf.Sqrt(n);
    }

    #endregion

    #region Trigonometry

    //    acos()
    //    asin()
    //    atan()
    //    atan2()

    /// <summary>
    /// Calculates the cosine of an angle. This function expects the values of the angle parameter to be 
    /// provided in radians (values from 0 to PI*2). Values are returned in the range -1 to 1.
    /// </summary>
    protected float cos(float angle)
    {
        return Mathf.Cos(angle);
    }

    //    degrees()

    /// <summary>
    /// Converts a degree measurement to its corresponding value in radians. Radians and degrees are two ways of measuring the same thing. There are 360 degrees in a circle and 2*PI radians in a circle. For example, 90° = PI/2 = 1.5707964. All trigonometric functions in Processing require their parameters to be specified in radians.
    /// </summary>
    protected float radians(float degrees)
    {
        return degrees * Mathf.Deg2Rad;
    }

    /// <summary>
    /// Calculates the sine of an angle. This function expects the values of the angle parameter to be 
    /// provided in radians (values from 0 to 6.28). Values are returned in the range -1 to 1.
    /// </summary>
    protected float sin(float angle)
    {
        return Mathf.Sin(angle);
    }

    //    tan()

    #endregion

    #region Random

    /// <summary>
    /// Returns the Perlin noise value at specified coordinates. Perlin noise is a random sequence generator producing a more natural, harmonic succession of numbers than that of the standard random() function. It was developed by Ken Perlin in the 1980s and has been used in graphical applications to generate procedural textures, shapes, terrains, and other seemingly organic forms.
    /// 
    /// In contrast to the random() function, Perlin noise is defined in an infinite n-dimensional space, in which each pair of coordinates corresponds to a fixed semi-random value (fixed only for the lifespan of the program). The resulting value will always be between 0.0 and 1.0. Processing can compute 1D, 2D and 3D noise, depending on the number of coordinates given. The noise value can be animated by moving through the noise space, as demonstrated in the first example above. The 2nd and 3rd dimensions can also be interpreted as time.
    /// 
    /// The actual noise structure is similar to that of an audio signal, in respect to the function's use of frequencies. Similar to the concept of harmonics in physics, Perlin noise is computed over several octaves which are added together for the final result.
    /// 
    /// Another way to adjust the character of the resulting sequence is the scale of the input coordinates. As the function works within an infinite space, the value of the coordinates doesn't matter as such; only the distance between successive coordinates is important (such as when using noise() within a loop). As a general rule, the smaller the difference between coordinates, the smoother the resulting noise sequence. Steps of 0.005-0.03 work best for most applications, but this will differ depending on use.
    /// 
    /// There have been debates over the accuracy of the implementation of noise in Processing. For clarification, it's an implementation of "classic Perlin noise" from 1983, and not the newer "simplex noise" method from 2001.
    /// </summary>
    protected float noise(float x, float y = 0, float z = 0)
    {
        return PerlinNoise.Noise(x, y, z);
    }

    /// <summary>
    /// Adjusts the character and level of detail produced by the Perlin noise function. Similar to harmonics in physics, noise is computed over several octaves. Lower octaves contribute more to the output signal and as such define the overal intensity of the noise, whereas higher octaves create finer-grained details in the noise sequence.
    ///
    /// By default, noise is computed over 4 octaves with each octave contributing exactly half than its predecessor, starting at 50% strength for the first octave. This falloff amount can be changed by adding an additional function parameter. For example, a falloff factor of 0.75 means each octave will now have 75% impact (25% less) of the previous lower octave. While any number between 0.0 and 1.0 is valid, note that values greater than 0.5 may result in noise() returning values greater than 1.0.
    ///
    /// By changing these parameters, the signal created by the noise() function can be adapted to fit very specific needs and characteristics.
    /// </summary>
    /// <param name="lod">number of octaves to be used by the noise</param>
    protected void noiseDetail(int lod)
    {
        warning("noiseDetail(lod)");
    }

    // noiseSeed()

    /// <summary>
    /// Generates random numbers. Each time the random() function is called, it returns an unexpected value within the specified range. If only one parameter is passed to the function, it will return a float between zero and the value of the high parameter. For example, random(5) returns values between 0 and 5 (starting at zero, and up to, but not including, 5).
    /// </summary>
    protected float random(float high)
    {
        return Random.Range(0, high);
    }

    /// <summary>
    /// Generates random numbers. Each time the random() function is called, it returns an unexpected value within the specified range. If only one parameter is passed to the function, it will return a float between zero and the value of the high parameter. For example, random(5) returns values between 0 and 5 (starting at zero, and up to, but not including, 5).
    /// </summary>
    protected float random(float low, float high)
    {
        return Random.Range(low, high);
    }

    // randomGaussian()

    /// <summary>
    /// Sets the seed value for random(). By default, random() produces different results each time the program is run. Set the seed parameter to a constant to return the same pseudo-random numbers each time the software is run.
    /// </summary>
    protected void randomSeed(int seed)
    {
        Random.seed = seed;
    }

    #endregion
}

