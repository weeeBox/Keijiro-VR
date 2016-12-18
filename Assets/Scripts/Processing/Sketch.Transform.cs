using System;
using System.Collections.Generic;

using UnityEngine;

using Matrix = UnityEngine.Matrix4x4;

public partial class Sketch
{
    private Matrix m_matrix;
    private Stack<Matrix> m_matrixStack;

    //    applyMatrix()

    private void applyMatrix(Matrix matrix)
    {
        m_matrix = m_matrix * matrix;
    }

    /// <summary>
    /// Pops the current transformation matrix off the matrix stack. Understanding pushing and popping requires 
    /// understanding the concept of a matrix stack. The pushMatrix() function saves the current coordinate system 
    /// to the stack and popMatrix() restores the prior coordinate system. pushMatrix() and popMatrix() are used in 
    /// conjuction with the other transformation functions and may be embedded to control the scope of the 
    /// transformations.
    /// </summary>
    protected void popMatrix()
    {
        m_matrix = m_matrixStack.Pop();
    }

    //    printMatrix()

    /// <summary>
    /// Pushes the current transformation matrix onto the matrix stack. Understanding pushMatrix() and popMatrix() 
    /// requires understanding the concept of a matrix stack. The pushMatrix() function saves the current coordinate 
    /// system to the stack and popMatrix() restores the prior coordinate system. pushMatrix() and popMatrix() are 
    /// used in conjuction with the other transformation functions and may be embedded to control the scope of the 
    /// transformations.
    /// </summary>
    protected void pushMatrix()
    {
        m_matrixStack.Push(m_matrix);
    }

    //    resetMatrix()
    //    rotate()

    /// <summary>
    /// Rotates around the x-axis the amount specified by the angle parameter. Angles should be specified in radians
    /// (values from 0 to TWO_PI) or converted from degrees to radians with the radians() function. Coordinates are 
    /// always rotated around their relative position to the origin. Positive numbers rotate in a clockwise direction 
    /// and negative numbers rotate in a counterclockwise direction. Transformations apply to everything that happens 
    /// after and subsequent calls to the function accumulates the effect. For example, calling rotateX(PI/2) and then 
    /// rotateX(PI/2) is the same as rotateX(PI). If rotateX() is run within the draw(), the transformation is reset 
    /// when the loop begins again. This function requires using P3D as a third parameter to size() as shown in the 
    /// example above.
    /// </summary>
    protected void rotateX(float angle)
    {
        applyMatrix(Matrix.TRS(Vector3.zero, Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.right), Vector3.one));
    }

    /// <summary>
    /// Rotates around the z-axis the amount specified by the angle parameter. Angles should be specified in radians 
    /// (values from 0 to TWO_PI) or converted from degrees to radians with the radians() function. Coordinates are 
    /// always rotated around their relative position to the origin. Positive numbers rotate in a clockwise direction 
    /// and negative numbers rotate in a counterclockwise direction. Transformations apply to everything that happens 
    /// after and subsequent calls to the function accumulates the effect. For example, calling rotateZ(PI/2) and then 
    /// rotateZ(PI/2) is the same as rotateZ(PI). If rotateZ() is run within the draw(), the transformation is reset 
    /// when the loop begins again. This function requires using P3D as a third parameter to size() as shown in the 
    /// example above.
    /// </summary>
    protected void rotateZ(float angle)
    {
        applyMatrix(Matrix.TRS(Vector3.zero, Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward), Vector3.one));
    }

    /// <summary>
    /// Rotates around the y-axis the amount specified by the angle parameter. Angles should be specified in radians 
    /// (values from 0 to TWO_PI) or converted from degrees to radians with the radians() function. Coordinates are a
    /// lways rotated around their relative position to the origin. Positive numbers rotate in a clockwise direction 
    /// and negative numbers rotate in a counterclockwise direction. Transformations apply to everything that happens 
    /// after and subsequent calls to the function accumulates the effect. For example, calling rotateY(PI/2) and then 
    /// rotateY(PI/2) is the same as rotateY(PI). If rotateY() is run within the draw(), the transformation is reset 
    /// when the loop begins again. This function requires using P3D as a third parameter to size() as shown in the 
    /// example above.
    /// </summary>
    protected void rotateY(float angle)
    {
        applyMatrix(Matrix.TRS(Vector3.zero, Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.up), Vector3.one));
    }

    /// <summary>
    /// Increases or decreases the size of a shape by expanding and contracting vertices. Objects always scale from 
    /// their relative origin to the coordinate system. Scale values are specified as decimal percentages. For example, 
    /// the function call scale(2.0) increases the dimension of a shape by 200%.
    ///
    /// Transformations apply to everything that happens after and subsequent calls to the function multiply the effect. 
    /// For example, calling scale(2.0) and then scale(1.5) is the same as scale(3.0). If scale() is called within draw(), 
    /// the transformation is reset when the loop begins again. Using this function with the z parameter requires using P3D 
    /// as a parameter for size(), as shown in the third example above. This function can be further controlled with pushMatrix() 
    /// and popMatrix().
    /// </summary>
    protected void scale(float x, float y, float z)
    {
        applyMatrix(Matrix.TRS(Vector3.zero, Quaternion.identity, new Vector3(x, y, z)));
    }

    //    shearX()
    //    shearY()

    /// <summary>
    /// Specifies an amount to displace objects within the display window. The x parameter specifies left/right translation, 
    /// the y parameter specifies up/down translation, and the z parameter specifies translations toward/away from the screen. 
    /// Using this function with the z parameter requires using P3D as a parameter in combination with size as shown in the 
    /// above example. 
    ///
    /// Transformations are cumulative and apply to everything that happens after and subsequent calls to the function 
    /// accumulates the effect. For example, calling translate(50, 0) and then translate(20, 0) is the same as translate(70, 0).
    ///  If translate() is called within draw(), the transformation is reset when the loop begins again. This function can be 
    /// further controlled by using pushMatrix() and popMatrix().
    /// </summary>
    protected void translate(float x, float y, float z)
    {
        applyMatrix(Matrix.TRS(new Vector3(x, y, z), Quaternion.identity, Vector3.one));
    }
}

