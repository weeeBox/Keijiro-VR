using System;
using UnityEngine;

public partial class Processing
{
    #region Lights

    protected void ambientLight() { throw new NotImplementedException(); }
    protected void directionalLight() { throw new NotImplementedException(); }
    protected void lightFalloff() { throw new NotImplementedException(); }
    protected void lights() { throw new NotImplementedException(); }
    protected void lightSpecular() { throw new NotImplementedException(); }
    protected void noLights() { throw new NotImplementedException(); }
    protected void normal() { throw new NotImplementedException(); }
    protected void pointLight() { throw new NotImplementedException(); }
    protected void spotLight() { throw new NotImplementedException(); }

    #endregion

    #region Camera

    protected void beginCamera() { throw new NotImplementedException(); }

    /// <summary>
    /// Sets the position of the camera through setting the eye position, the center of the scene, and which axis is facing upward. Moving the eye position and the direction it is pointing (the center of the scene) allows the images to be seen from different angles. The version without any parameters sets the camera to the default position, pointing to the center of the display window with the Y axis as up. The default values are camera(width/2.0, height/2.0, (height/2.0) / tan(PI*30.0 / 180.0), width/2.0, height/2.0, 0, 0, 1, 0). This function is similar to gluLookAt() in OpenGL, but it first clears the current camera settings.
    /// </summary>
    /// <param name="eyeX">x-coordinate for the eye</param>
    /// <param name="eyeY">y-coordinate for the eye</param>
    /// <param name="eyeZ">z-coordinate for the eye</param>
    /// <param name="centerX">x-coordinate for the center of the scene</param>
    /// <param name="centerY">y-coordinate for the center of the scene</param>
    /// <param name="centerZ">z-coordinate for the center of the scene</param>
    /// <param name="upX">usually 0.0, 1.0, or -1.0</param>
    /// <param name="upY">usually 0.0, 1.0, or -1.0</param>
    /// <param name="upZ">usually 0.0, 1.0, or -1.0</param>
    protected void camera(float eyeX, float eyeY, float eyeZ, float centerX, float centerY, float centerZ, float upX, float upY, float upZ)
    {
    }

    protected void endCamera() { throw new NotImplementedException(); }
    protected void frustum() { throw new NotImplementedException(); }
    protected void ortho() { throw new NotImplementedException(); }

    /// <summary>
    /// Sets a perspective projection applying foreshortening, making distant objects appear smaller than closer ones. The parameters define a viewing volume with the shape of truncated pyramid. Objects near to the front of the volume appear their actual size, while farther objects appear smaller. This projection simulates the perspective of the world more accurately than orthographic projection. The version of perspective without parameters sets the default perspective and the version with four parameters allows the programmer to set the area precisely. The default values are: perspective(PI/3.0, width/height, cameraZ/10.0, cameraZ*10.0) where cameraZ is ((height/2.0) / tan(PI*60.0/360.0));
    /// </summary>
    protected void perspective()
    {
        warning("perspective()");
    }

    /// <summary>
    /// Sets a perspective projection applying foreshortening, making distant objects appear smaller than closer ones. The parameters define a viewing volume with the shape of truncated pyramid. Objects near to the front of the volume appear their actual size, while farther objects appear smaller. This projection simulates the perspective of the world more accurately than orthographic projection. The version of perspective without parameters sets the default perspective and the version with four parameters allows the programmer to set the area precisely. The default values are: perspective(PI/3.0, width/height, cameraZ/10.0, cameraZ*10.0) where cameraZ is ((height/2.0) / tan(PI*60.0/360.0));
    /// </summary>
    protected void perspective(float fovy, float aspect, float zNear, float zFar)
    {
        warning("perspective(fovy, aspect, zNear, zFar)");
    }

    protected void printCamera() { throw new NotImplementedException(); }
    protected void printProjection() { throw new NotImplementedException(); }

    #endregion

    #region Coordinates
    protected void modelX() { throw new NotImplementedException(); }
    protected void modelY() { throw new NotImplementedException(); }
    protected void modelZ() { throw new NotImplementedException(); }
    protected void screenX() { throw new NotImplementedException(); }
    protected void screenY() { throw new NotImplementedException(); }
    protected void screenZ() { throw new NotImplementedException(); }

    #endregion

    #region Material Properties

    protected void ambient() { throw new NotImplementedException(); }
    protected void emissive() { throw new NotImplementedException(); }
    protected void shininess() { throw new NotImplementedException(); }
    protected void specular() { throw new NotImplementedException(); }

    #endregion
}

