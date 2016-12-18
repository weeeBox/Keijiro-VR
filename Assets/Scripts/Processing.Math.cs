using System;
using UnityEngine;

public partial class Processing
{
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

    //    constrain()
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
    //    max()
    //    min()
    //    norm()
    //    pow()
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
    //    radians()

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
}

