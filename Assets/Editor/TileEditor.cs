using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Tile)), CanEditMultipleObjects]
public class TileEditor : Editor
{
	private Tile[] tiles;

	private void OnEnable()
	{
		Object[] objects = targets;
		tiles = new Tile[objects.Length];
		for (int i = 0; i < objects.Length; i++)
		{
			tiles[i] = (Tile)objects[i];
		}
	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		if (GUILayout.Button("Apply Item Type"))
		{
			for (int i = 0; i < tiles.Length; i++)
			{
				tiles[i].ApplyItemType();
			}
		}
	}
}