using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MatchSearch : MonoBehaviour
{
	public static MatchSearch Instance { get; private set; }

	public bool[,] visited;

	private void Awake()
	{
		Instance = this;
	}

	public void Search(Tile[,] map, Tile tile, ref Stack<Tile> stack)
	{
		if (visited == null)
		{
			visited = new bool[map.GetLength(0), map.GetLength(1)];
		}

		TileAttribute tileAtt = tile.tileAttribute;
		visited[tileAtt.x, tileAtt.y] = true;

		// Left search
		if (tileAtt.x - 1 >= 0 && !visited[tileAtt.x - 1, tileAtt.y] && tileAtt.type == map[tileAtt.x - 1, tileAtt.y].tileAttribute.type)
		{
			Search(map, map[tileAtt.x - 1, tileAtt.y], ref stack);
		}
		// Right search
		if (tileAtt.x + 1 < map.GetLength(0) && !visited[tileAtt.x + 1, tileAtt.y] && tileAtt.type == map[tileAtt.x + 1, tileAtt.y].tileAttribute.type)
		{
			Search(map, map[tileAtt.x + 1, tileAtt.y], ref stack);
		}
		// Top search
		if (tileAtt.y + 1 < map.GetLength(1) && !visited[tileAtt.x, tileAtt.y + 1] && tileAtt.type == map[tileAtt.x, tileAtt.y + 1].tileAttribute.type)
		{
			Search(map, map[tileAtt.x, tileAtt.y + 1], ref stack);
		}
		// Bottom search
		if (tileAtt.y - 1 >= 0 && !visited[tileAtt.x, tileAtt.y - 1] && tileAtt.type == map[tileAtt.x, tileAtt.y - 1].tileAttribute.type)
		{
			Search(map, map[tileAtt.x, tileAtt.y - 1], ref stack);
		}
		stack.Push(tile);
	}
}