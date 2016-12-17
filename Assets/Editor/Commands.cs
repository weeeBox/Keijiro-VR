using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEditor;

using LunarPlugin;

[CCommand("generate")]
class Cmd_generate : CCommand
{
    void Execute()
    {
        var obj = Selection.activeGameObject;
        var mesh = obj.GetComponent<MeshFilter>().mesh;

        StringBuilder buffer = new StringBuilder();
        buffer.Append("new Vector3[]\n{\n");
        foreach (var vertex in mesh.vertices)
        {
            buffer.AppendFormat("\tnew Vector3({0}f, {1}f, {2}f),\n", vertex.x, vertex.y, vertex.z);
        }
        buffer.Append("},\n");
        buffer.Append("new Vector3[]\n{\n");
        foreach (var normal in mesh.normals)
        {
            buffer.AppendFormat("\tnew Vector3({0}, {1}, {2}),\n", normal.x, normal.y, normal.z);
        }
        buffer.Append("},\n");

        buffer.Append("new int[]\n{\n");
        int[] triangles = mesh.triangles;
        for (int i = 0; i < triangles.Length; i += 3)
        {
            buffer.AppendFormat("\t{0}, {1}, {2},\n", triangles[i], triangles[i + 1], triangles[i + 2]);
        }
        buffer.Append("}\n");

        Print(buffer.ToString());
    }
}