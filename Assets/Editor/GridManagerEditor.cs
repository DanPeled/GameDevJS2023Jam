using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridManager))]
public class GridManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var manager = (GridManager)target;
        if (GUILayout.Button("Generate"))
        {
            manager.GenerateGrid();
        }
        if (GUILayout.Button("Clear"))
        {
            manager.ClearGrid();
        }
        base.OnInspectorGUI();

    }
}