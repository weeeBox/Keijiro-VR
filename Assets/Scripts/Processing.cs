using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Matrix = UnityEngine.Matrix4x4;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public abstract class Processing : MonoBehaviour
{
    protected const float PI = 3.1415927f;

    Mesh m_mesh;
    bool m_meshDirty;
    List<Vector3> m_vertices;
    List<int> m_triangles;

    Matrix m_matrix;
    Stack<Matrix> m_matrixStack;

    int m_frameRate;
    float m_frameTime;
    float m_frameElapsed;
    int m_frameCount;

    void OnEnable()
    {
        frameRate(24);

        m_vertices = new List<Vector3>();
        m_triangles = new List<int>();

        var meshFilter = GetComponent<MeshFilter>();
        m_mesh = new Mesh();
        m_mesh.MarkDynamic();
        meshFilter.mesh = m_mesh;

        m_matrix = Matrix.identity;
        m_matrixStack = new Stack<Matrix>();

        setup();
    }

    void Update()
    {
        m_frameElapsed += Time.deltaTime;
        if (m_frameElapsed > m_frameTime)
        {
            m_frameElapsed = 0.0f;
            m_matrixStack.Clear();
            m_matrix = Matrix.identity;

            draw();

            if (m_meshDirty)
            {
                m_mesh.SetVertices(m_vertices);
                m_mesh.SetTriangles(m_triangles, 0);
                m_mesh.RecalculateNormals();
                m_meshDirty = false;

                m_vertices.Clear();
                m_triangles.Clear();
            }

            ++m_frameCount;
        }
    }

    #region Structure

    protected virtual void setup()
    {
    }

    protected virtual void draw()
    {
    }

    #endregion

    #region Environment

    /// <summary>
    /// The system variable frameCount contains the number of frames that have been displayed since the program started. 
    /// Inside setup() the value is 0, after the first iteration of draw it is 1, etc.
    /// </summary>
    protected int frameCount
    {
        get { return m_frameCount; }
    }

    protected void frameRate(int fps)
    {
        m_frameRate = fps;
        m_frameTime = 1.0f / fps;
        m_frameElapsed = 0;
    }

    #endregion

    #region Transform

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

    #endregion

    /// <summary>
    /// A box is an extruded rectangle. A box with equal dimensions on all sides is a cube.
    /// </summary>
    /// <param name="size">Dimension of the box in all dimensions (creates a cube).</param>
    protected void box(float size)
    {
        box(size, size, size);
    }

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
        return (int) Mathf.Ceil(n);
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
    //    sqrt()

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

    /// <summary>
    /// A box is an extruded rectangle. A box with equal dimensions on all sides is a cube.
    /// </summary>
    /// <param name="w">Dimension of the box in the x-dimension.</param>
    /// <param name="h">Dimension of the box in the y-dimension.</param>
    /// <param name="d">Dimension of the box in the z-dimension.</param>
    protected void box(float w, float h, float d)
    {
        AddPrimitive(Primitives.Box, new Vector3(w, h, d));
    }

    #region Primitives

    void AddPrimitive(Primitive primitive, Vector3 scale)
    {
        var vertices = primitive.vertices;
        var triangles = primitive.triangles;
        int triangleOffset = m_vertices.Count;

        for (int i = 0; i < vertices.Length; ++i)
        {
            var vertex = vertices[i];
            vertex.Scale(scale);
            m_vertices.Add(m_matrix.MultiplyPoint3x4(vertex));
        }


        for (int i = 0; i < triangles.Length; ++i)
        {
            m_triangles.Add(triangleOffset + triangles[i]);
        }

        m_meshDirty = true;
    }

    #endregion
}

static class Primitives
{
    public static readonly Primitive Box = new Primitive
    (
        new Vector3[]
        {
            new Vector3(0.5f, -0.5f, 0.5f),
            new Vector3(-0.5f, -0.5f, 0.5f),
            new Vector3(0.5f, 0.5f, 0.5f),
            new Vector3(-0.5f, 0.5f, 0.5f),
            new Vector3(0.5f, 0.5f, -0.5f),
            new Vector3(-0.5f, 0.5f, -0.5f),
            new Vector3(0.5f, -0.5f, -0.5f),
            new Vector3(-0.5f, -0.5f, -0.5f),
            new Vector3(0.5f, 0.5f, 0.5f),
            new Vector3(-0.5f, 0.5f, 0.5f),
            new Vector3(0.5f, 0.5f, -0.5f),
            new Vector3(-0.5f, 0.5f, -0.5f),
            new Vector3(0.5f, -0.5f, -0.5f),
            new Vector3(0.5f, -0.5f, 0.5f),
            new Vector3(-0.5f, -0.5f, 0.5f),
            new Vector3(-0.5f, -0.5f, -0.5f),
            new Vector3(-0.5f, -0.5f, 0.5f),
            new Vector3(-0.5f, 0.5f, 0.5f),
            new Vector3(-0.5f, 0.5f, -0.5f),
            new Vector3(-0.5f, -0.5f, -0.5f),
            new Vector3(0.5f, -0.5f, -0.5f),
            new Vector3(0.5f, 0.5f, -0.5f),
            new Vector3(0.5f, 0.5f, 0.5f),
            new Vector3(0.5f, -0.5f, 0.5f),
        },
        new int[]
        {
            0, 2, 3,
            0, 3, 1,
            8, 4, 5,
            8, 5, 9,
            10, 6, 7,
            10, 7, 11,
            12, 13, 14,
            12, 14, 15,
            16, 17, 18,
            16, 18, 19,
            20, 21, 22,
            20, 22, 23,
        }
    );
}

class Primitive
{
    public readonly Vector3[] vertices;
    public readonly int[] triangles;

    public Primitive(Vector3[] vertices, int[] triangles)
    {
        this.vertices = vertices;
        this.triangles = triangles;
    }
}
