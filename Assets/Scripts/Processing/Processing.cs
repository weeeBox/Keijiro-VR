using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Matrix = UnityEngine.Matrix4x4;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public abstract partial class Processing : MonoBehaviour
{
    Mesh m_mesh;
    bool m_meshDirty;
    List<Vector3> m_vertices;
    List<Color> m_colors;
    List<int> m_triangles;
    
    int m_frameRate;
    float m_frameTime;
    float m_frameElapsed;
    int m_frameCount;

    void OnEnable()
    {
        frameRate(24);

        m_vertices = new List<Vector3>();
        m_colors = new List<Color>();
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
                m_mesh.SetColors(m_colors);
                m_mesh.RecalculateNormals();
                m_meshDirty = false;

                m_vertices.Clear();
                m_colors.Clear();
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
            m_colors.Add(m_fillColor);
        }

        for (int i = 0; i < triangles.Length; ++i)
        {
            m_triangles.Add(triangleOffset + triangles[i]);
        }

        m_meshDirty = true;
    }

    #endregion

    #region Debug

    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    protected void warning(string name)
    {
        Debug.LogWarning("NOT IMPLEMENTED:" + name);
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
