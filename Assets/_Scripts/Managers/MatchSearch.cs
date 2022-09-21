using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MatchSearch
{
	public Tile[,] map;
	public bool[,] visited;
	int matchCounter = 0;

	public MatchSearch(ref Tile[,] map)
	{
		this.map = map;
	}

	public int Search(Tile tile, ref Stack<Tile> tiles)
	{
		matchCounter = 0;
		visited = new bool[map.GetLength(0), map.GetLength(1)];
		FindMatch(tile, tile.item.GetMatchType(), ref tiles);
		return matchCounter;
	}

	public void FindMatch(Tile tile, MatchType matchType, ref Stack<Tile> tiles)
	{
		if (tile == null || visited[tile.x, tile.y] || matchType == MatchType.None) return;

		visited[tile.x, tile.y] = true;

		if (tile.item.CanBeExplodedByNeighbourMatch()) // Balloon
		{
			tiles.Push(tile);
			return;
		}
		if (tile.item.GetMatchType() == matchType) // Cube
		{
			matchCounter++;
			tiles.Push(tile);
			for (int i = 0; i < tile.neighbourTiles.Length; i++)
			{
				FindMatch(tile.neighbourTiles[i], matchType, ref tiles);
			}
		}
	}
}