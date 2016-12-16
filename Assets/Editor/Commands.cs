using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using LunarPlugin;

[CCommand("grabMesh")]
class Cmd_grabMesh : CCommand
{
    void Execute(string meshName = "mesh")
    {
        var obj = Selection.activeObject as GameObject;
        if (obj == null)
        {
            PrintError("No objects selected");
            return;
        }

        var meshFilter = obj.GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            PrintError("No mesh filter component");
            return;
        }

        AssetDatabase.CreateAsset(meshFilter.sharedMesh, "Assets/" + meshName + ".asset");
    }
}