using System;
using UnityEngine;

public partial class Processing
{
    protected const int RGB = 1;
    protected const int HSB = 2;

    private Color m_fillColor;
    private int m_mode = RGB;

    #region Setting

    // background()
    // clear()

    /// <summary>
    /// Changes the way Processing interprets color data. By default, the parameters for fill(), stroke(), background(), 
    /// and color() are defined by values between 0 and 255 using the RGB color model. The colorMode() function is used 
    /// to change the numerical range used for specifying colors and to switch color systems. For example, calling 
    /// colorMode(RGB, 1.0) will specify that values are specified between 0 and 1. The limits for defining colors are 
    /// altered by setting the parameters max, max1, max2, max3, and maxA. 
    ///
    /// After changing the range of values for colors with code like colorMode(HSB, 360, 100, 100), those ranges remain 
    /// in use until they are explicitly changed again. For example, after running colorMode(HSB, 360, 100, 100) and then 
    /// changing back to colorMode(RGB), the range for R will be 0 to 360 and the range for G and B will be 0 to 100. 
    /// To avoid this, be explicit about the ranges when changing the color mode. For instance, instead of colorMode(RGB), 
    /// write colorMode(RGB, 255, 255, 255).
    /// </summary>
    protected void colorMode(int mode, float max)
    {
        if (mode != RGB && mode != HSB)
        {
            throw new ArgumentException("Invalid mode: " + mode);
        }

        m_mode = mode;
    }

    /// <summary>
    /// Sets the color used to fill shapes. For example, if you run fill(204, 102, 0), all subsequent 
    /// shapes will be filled with orange. This color is either specified in terms of the RGB or HSB 
    /// color depending on the current colorMode(). The default color space is RGB, with each value in the range from 0 to 255. 
    ///
    /// When using hexadecimal notation to specify a color, use "#" or "0x" before the values (e.g., #CCFFAA 
    /// or 0xFFCCFFAA). The # syntax uses six digits to specify a color (just as colors are typically specified 
    /// in HTML and CSS). When using the hexadecimal notation starting with "0x", the hexadecimal value must be 
    /// specified with eight characters; the first two characters define the alpha component, and the remainder define the red, green, and blue components. 
    ///
    /// The value for the "gray" parameter must be less than or equal to the current maximum value as specified 
    /// by colorMode(). The default maximum value is 255. 
    ///
    /// To change the color of an image or a texture, use tint().
    /// </summary>
    protected void fill(float v1, float v2, float v3, float alpha = 1.0f)
    {
        if (m_mode == RGB)
        {
            m_fillColor = new Color(v1, v2, v3, alpha);
        }
        else
        {
            m_fillColor = Color.HSVToRGB(v1, v2, v3);
            m_fillColor.a = alpha;
        }
    }

    // noFill()
    // noStroke()
    // stroke()

    #endregion

    #region Creating & Reading

    // alpha()
    // blue()
    // brightness()
    // color()
    // green()
    // hue()
    // lerpColor()
    // red()
    // saturation()

    #endregion
}

