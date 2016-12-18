using System;
using UnityEngine;

public partial class Sketch
{
    protected const int P2D = 1;
    protected const int P3D = 2;

    private int _width = 100;
    private int _height = 100;

    private int _pixelWidth;
    private int _pixelHeight;

    private bool _focused = true;

    protected void cursor() { throw new NotImplementedException(); }
    protected void delay() { throw new NotImplementedException(); }
    protected void displayDensity() { throw new NotImplementedException(); }

    protected void frameRate() { throw new NotImplementedException(); }
    protected void fullScreen() { throw new NotImplementedException(); }
    protected void noCursor() { throw new NotImplementedException(); }
    protected void noSmooth() { throw new NotImplementedException(); }
    protected void pixelDensity() { throw new NotImplementedException(); }
    protected void settings() { throw new NotImplementedException(); }

    /// <summary>
    /// Defines the dimension of the display window width and height in units of pixels. In a program that has the setup() function, the size() function must be the first line of code inside setup().
    /// </summary>
    protected void size(int width, int height, int renderer = P3D)
    {
        _width = width;
        _height = height;
    }

    /// <summary>
    /// Draws all geometry with smooth (anti-aliased) edges. This behavior is the default, so smooth() only needs to be used when a program needs to set the smoothing in a different way. The level parameter increases the level of smoothness. This is the level of over sampling applied to the graphics buffer.
    /// 
    /// With the P2D and P3D renderers, smooth(2) is the default, this is called "2x anti-aliasing." The code smooth(4) is used for 4x anti-aliasing and smooth(8) is specified for 8x anti-aliasing. The maximum anti-aliasing level is determined by the hardware of the machine that is running the software, so smooth(4) and smooth(8) will not work with every computer.
    ///
    /// The default renderer uses smooth(3) by default. This is bicubic smoothing. The other option for the default renderer is smooth(2), which is bilinear smoothing.
    ///
    /// With Processing 3.0, smooth() is different than before. It was common to use smooth() and noSmooth() to turn on and off antialiasing within a sketch. Now, because of how the software has changed, smooth() can only be set once within a sketch. It can be used either at the top of a sketch without a setup(), or after the size() function when used in a sketch with setup(). The noSmooth() function also follows the same rules.
    /// </summary>
    protected void smooth(int level)
    {
        warning("smooth(level)");
    }

    #region Properties

    /// <summary>
    /// System variable that stores the width of the display window. This value is set by the first parameter of the size() function. For example, the function call size(320, 240) sets the width variable to the value 320. The value of width defaults to 100 if size() is not used in a program.
    /// </summary>
    protected int width
    {
        get { return _width; }
    }

    /// <summary>
    /// System variable that stores the height of the display window. This value is set by the second parameter of the size() function. For example, the function call size(320, 240) sets the height variable to the value 240. The value of height defaults to 100 if size() is not used in a program.
    /// </summary>
    protected int height
    {
        get { return _height; }
    }

    /// <summary>
    /// When pixelDensity(2) is used to make use of a high resolution display (called a Retina display on OS X or high-dpi on Windows and Linux), the width and height of the sketch do not change, but the number of pixels is doubled. As a result, all operations that use pixels (like loadPixels(), get(), set(), etc.) happen in this doubled space. As a convenience, the variables pixelWidth and pixelHeight hold the actual width and height of the sketch in pixels. This is useful for any sketch that uses the pixels[] array, for instance, because the number of elements in the array will be pixelWidth*pixelHeight, not width*height.
    /// </summary>
    protected int pixelWidth
    {
        get { return _pixelWidth; }
    }

    /// <summary>
    /// When pixelDensity(2) is used to make use of a high resolution display (called a Retina display on OS X or high-dpi on Windows and Linux), the width and height of the sketch do not change, but the number of pixels is doubled. As a result, all operations that use pixels (like loadPixels(), get(), set(), etc.) happen in this doubled space. As a convenience, the variables pixelWidth and pixelHeight hold the actual width and height of the sketch in pixels. This is useful for any sketch that uses the pixels[] array, for instance, because the number of elements in the array will be pixelWidth*pixelHeight, not width*height.
    /// </summary>
    protected int pixelHeight
    {
        get { return _pixelHeight; }
    }

    /// <summary>
    /// Confirms if a Processing program is "focused," meaning that it is active and will accept mouse or keyboard input. This variable is "true" if it is focused and "false" if not.
    /// </summary>
    protected bool focused
    {
        get { return _focused; }
    }

    /// <summary>
    /// The system variable frameCount contains the number of frames that have been displayed since the program started. 
    /// Inside setup() the value is 0, after the first iteration of draw it is 1, etc.
    /// </summary>
    protected int frameCount
    {
        get { return m_frameCount; }
    }

    /// <summary>
    /// Specifies the number of frames to be displayed every second. For example, the function call frameRate(30) will attempt to refresh 30 times a second. If the processor is not fast enough to maintain the specified rate, the frame rate will not be achieved. Setting the frame rate within setup() is recommended. The default rate is 60 frames per second.
    /// </summary>
    /// <param name="fps">Number of desired frames per second</param>
    protected void frameRate(int fps)
    {
        m_frameRate = fps;
        m_frameTime = 1.0f / fps;
        m_frameElapsed = 0;
    }

    #endregion
}

