using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridGenerator))]
public class GridGeneratorEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		GridGenerator levelInfo = (GridGenerator)target;

		if (GUILayout.Button("Generate Grid"))
		{
			levelInfo.SetParameters();
			levelInfo.GenerateGrid();
		}

		if (GUILayout.Button("Clear Grid"))
		{
			levelInfo.SetParameters();
			levelInfo.ClearGrid();
		}
	}
}