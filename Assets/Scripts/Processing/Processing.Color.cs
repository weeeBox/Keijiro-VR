using System;
using UnityEngine;

public partial class Processing
{
    protected const int RGB = 1;
    protected const int HSB = 2;

    private Color m_fillColor = Color.white;
    private int m_mode = RGB;

    #region Setting

    /// <summary>
    /// The background() function sets the color used for the background of the Processing window. The default background is light gray. This function is typically used within draw() to clear the display window at the beginning of each frame, but it can be used inside setup() to set the background on the first frame of animation or if the backgound need only be set once. 
    ///
    /// An image can also be used as the background for a sketch, although the image's width and height must match that of the sketch window. Images used with background() will ignore the current tint() setting. To resize an image to the size of the sketch window, use image.resize(width, height). 
    ///
    /// It is not possible to use the transparency alpha parameter with background colors on the main drawing surface.It can only be used along with a PGraphics object and createGraphics().
    /// </summary>
    /// <param name="rgb">Any value of the color datatype</param>
    /// <param name="alpha">Opacity of the background</param>
    protected void background(int rgb, float alpha = 1)
    {
        warning("background(rgb, alpha)");
    }

    /// <summary>
    /// The background() function sets the color used for the background of the Processing window. The default background is light gray. This function is typically used within draw() to clear the display window at the beginning of each frame, but it can be used inside setup() to set the background on the first frame of animation or if the backgound need only be set once. 
    ///
    /// An image can also be used as the background for a sketch, although the image's width and height must match that of the sketch window. Images used with background() will ignore the current tint() setting. To resize an image to the size of the sketch window, use image.resize(width, height). 
    ///
    /// It is not possible to use the transparency alpha parameter with background colors on the main drawing surface.It can only be used along with a PGraphics object and createGraphics().
    /// </summary>
    /// <param name="gray">Specifies a value between white and black</param>
    /// <param name="alpha">Opacity of the background</param>
    protected void background(float gray, float alpha = 1)
    {
        warning("background(gray, alpha)");
    }

    /// <summary>
    /// The background() function sets the color used for the background of the Processing window. The default background is light gray. This function is typically used within draw() to clear the display window at the beginning of each frame, but it can be used inside setup() to set the background on the first frame of animation or if the backgound need only be set once. 
    ///
    /// An image can also be used as the background for a sketch, although the image's width and height must match that of the sketch window. Images used with background() will ignore the current tint() setting. To resize an image to the size of the sketch window, use image.resize(width, height). 
    ///
    /// It is not possible to use the transparency alpha parameter with background colors on the main drawing surface.It can only be used along with a PGraphics object and createGraphics().
    /// </summary>
    /// <param name="v1">Red or hue value (depending on the current color mode)</param>
    /// <param name="v2">Green or saturation value (depending on the current color mode)</param>
    /// <param name="v3">Blue or brightness value (depending on the current color mode)</param>
    /// <param name="alpha"></param>
    protected void background(float v1, float v2, float v3, float alpha = 1)
    {
        warning("background(v1, v2, v3, alpha)");
    }

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

    protected void fill(color color)
    {
        warning("fill(color)");
    }

    // noFill()

    /// <summary>
    /// Disables drawing the stroke (outline). If both noStroke() and noFill() are called, nothing will be drawn to the screen.
    /// </summary>
    protected void noStroke()
    {
        warning("noStroke()");
    }

    // stroke()

    #endregion

    #region Creating & Reading

    // alpha()
    // blue()
    // brightness()

    protected int color(float gray, float alpha = 1)
    {
        return 0;
    }

    protected int color(float v1, float v2, float v3, float alpha = 1)
    {
        return 0;
    }

    // green()
    // hue()

    /// <summary>
    /// Calculates a color or colors between two color at a specific increment. The amt parameter is the amount to interpolate between the two values where 0.0 equal to the first point, 0.1 is very near the first point, 0.5 is halfway in between, etc. 
    /// An amount below 0 will be treated as 0. Likewise, amounts above 1 will be capped at 1. This is different from the behavior of lerp(), but necessary because otherwise numbers outside the range will produce strange and unexpected colors.
    /// </summary>
    /// <param name="c1">interpolate from this color</param>
    /// <param name="c2">interpolate to this color</param>
    /// <param name="amt">between 0.0 and 1.0</param>
    protected int lerpColor(int c1, int c2, float amt)
    {
        return c1; // FIXME
    }

    // red()
    // saturation()

    #endregion
}

