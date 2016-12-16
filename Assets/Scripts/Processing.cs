using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Matrix = UnityEngine.Matrix4x4;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Processing : MonoBehaviour
{
    [SerializeField]
    private Mesh cubeMesh;

    void OnEnable()
    {
        var meshData = MeshDataFactory.box(1, 1, 1);

        var meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        mesh.vertices = meshData.vertices;
        mesh.triangles = meshData.triangles;
        mesh.RecalculateNormals();
        meshFilter.mesh = mesh;
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

        int[] triangles = {
            0, 1, 3, 2, 3, 1,
            4, 5, 7, 6, 7, 5,
            8, 9, 11, 10, 11, 9,
            12, 13, 15, 14, 15, 13,
            16, 17, 19, 18, 19, 17,
            20, 21, 23, 22, 23, 21,
        };

        return new MeshData(vertices, triangles);
    }
}

public struct MeshData
{
    public readonly Vector3[] vertices;
    public readonly int[] triangles;

    public MeshData(Vector3[] vertices, int[] triangles)
    {
        this.vertices = vertices;
        this.triangles = triangles;
    }
}
