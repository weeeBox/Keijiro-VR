using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Matrix = UnityEngine.Matrix4x4;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Processing : MonoBehaviour
{
    Mesh m_mesh;

    bool m_meshDirty;
    List<Vector3> m_vertices;
    List<Vector3> m_normals;
    List<int> m_triangles;

    void OnEnable()
    {
        m_vertices = new List<Vector3>();
        m_normals = new List<Vector3>();
        m_triangles = new List<int>();

        var meshFilter = GetComponent<MeshFilter>();
        m_mesh = new Mesh();
        m_mesh.MarkDynamic();
        meshFilter.mesh = m_mesh;
    }

    void Update()
    {
        if (m_meshDirty)
        {
            m_mesh.SetVertices(m_vertices);
            m_mesh.SetNormals(m_normals);
            m_mesh.SetTriangles(m_triangles, 0);
            m_meshDirty = false;

            m_vertices.Clear();
            m_normals.Clear();
            m_triangles.Clear();
        }
    }

    /// <summary>
    /// A box is an extruded rectangle. A box with equal dimensions on all sides is a cube.
    /// </summary>
    /// <param name="size">Dimension of the box in all dimensions (creates a cube).</param>
    public void box(float size)
    {
        box(size, size, size);
    }

    /// <summary>
    /// A box is an extruded rectangle. A box with equal dimensions on all sides is a cube.
    /// </summary>
    /// <param name="w">Dimension of the box in the x-dimension.</param>
    /// <param name="h">Dimension of the box in the y-dimension.</param>
    /// <param name="d">Dimension of the box in the z-dimension.</param>
    public void box(float w, float h, float d)
    {
        AddMesh(MeshDataFactory.box(w, h, d));
    }

    void AddMesh(MeshData meshData)
    {
        int triangleOffset = m_vertices.Count;

        m_vertices.AddRange(meshData.vertices);
        m_normals.AddRange(meshData.normals);

        var triangles = meshData.triangles;
        for (int i = 0; i < triangles.Length; ++i)
        {
            m_triangles.Add(triangleOffset + triangles[i]);
        }

        m_meshDirty = true;
    }
}

public static class MeshDataFactory
{
    public static MeshData box(float w, float h, float d)
    {
        float w2 = 0.5f * w;
        float h2 = 0.5f * h;
        float d2 = 0.5f * d;

        Vector3[] vertices =
        {
            /* 0 */  new Vector3(-w2, -h2, -d2),
            /* 1 */  new Vector3(-w2,  h2, -d2),
            /* 2 */  new Vector3( w2,  h2, -d2),
            /* 3 */  new Vector3( w2, -h2, -d2),

            /* 4 */  new Vector3( w2, -h2, -d2),
            /* 5 */  new Vector3( w2,  h2, -d2),
            /* 6 */  new Vector3( w2,  h2, d2),
            /* 7 */  new Vector3( w2, -h2, d2),

            /* 8 */  new Vector3( w2, -h2, d2),
            /* 9 */  new Vector3( w2,  h2, d2),
            /* 10 */ new Vector3(-w2,  h2, d2),
            /* 11 */ new Vector3(-w2, -h2, d2),

            /* 12 */ new Vector3(-w2, -h2, d2),
            /* 13 */ new Vector3(-w2,  h2, d2),
            /* 14 */ new Vector3(-w2,  h2, -d2),
            /* 15 */ new Vector3(-w2, -h2, -d2),

            /* 16 */ new Vector3( w2,  h2, -d2),
            /* 17 */ new Vector3(-w2,  h2, -d2),
            /* 18 */ new Vector3(-w2,  h2, d2),
            /* 19 */ new Vector3( w2,  h2, d2),

            /* 20 */ new Vector3(-w2, -h2, -d2),
            /* 21 */ new Vector3( w2, -h2, -d2),
            /* 22 */ new Vector3( w2, -h2, d2),
            /* 23 */ new Vector3(-w2, -h2, d2),
        };

        Vector3[] normals =
        {
            /* 0 */  Vector3.back,
            /* 1 */  Vector3.back,
            /* 2 */  Vector3.back,
            /* 3 */  Vector3.back,

            /* 4 */  Vector3.right,
            /* 5 */  Vector3.right,
            /* 6 */  Vector3.right,
            /* 7 */  Vector3.right,

            /* 8 */  Vector3.forward,
            /* 9 */  Vector3.forward,
            /* 10 */ Vector3.forward,
            /* 11 */ Vector3.forward,

            /* 12 */ Vector3.left,
            /* 13 */ Vector3.left,
            /* 14 */ Vector3.left,
            /* 15 */ Vector3.left,

            /* 16 */ Vector3.up,
            /* 17 */ Vector3.up,
            /* 18 */ Vector3.up,
            /* 19 */ Vector3.up,

            /* 20 */ Vector3.down,
            /* 21 */ Vector3.down,
            /* 22 */ Vector3.down,
            /* 23 */ Vector3.down,
        };

        int[] triangles = {
            0, 1, 3, 2, 3, 1,
            4, 5, 7, 6, 7, 5,
            8, 9, 11, 10, 11, 9,
            12, 13, 15, 14, 15, 13,
            16, 17, 19, 18, 19, 17,
            20, 21, 23, 22, 23, 21,
        };

        return new MeshData(vertices, normals, triangles);
    }
}

public struct MeshData
{
    public readonly Vector3[] vertices;
    public readonly Vector3[] normals;
    public readonly int[] triangles;

    public MeshData(Vector3[] vertices, Vector3[] normals, int[] triangles)
    {
        this.vertices = vertices;
        this.normals = normals;
        this.triangles = triangles;
    }

    public void ApplyTransform(Matrix matrix)
    {
        for (int i = 0; i < vertices.Length; ++i)
        {
            vertices[i] = matrix.MultiplyVector(vertices[i]);
        }
    }
}
