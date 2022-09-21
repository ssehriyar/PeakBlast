using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class ActionManager
{
	public Tile[,] map;

	public ActionManager(ref Tile[,] map)
	{
		this.map = map;
	}

	public void Fall()
	{
		int maxX = map.GetLength(0);
		int maxY = map.GetLength(1);
		for (int x = 0; x < maxX; x++)
		{
			for (int y = 0; y < maxY; y++)
			{
				if (map[x, y].item == null)
				{
					map[x, y].item = ItemFactory.CreateRandomItem(new Vector3(x, y + maxY), null);
					map[x, y].item.MoveTo(new Vector3(x, y));
				}
			}
		}
	}

	public void Fill(Stack<Tile> tiles)
	{
		int maxX = map.GetLength(0);
		int maxY = map.GetLength(1);
		foreach (var tile in tiles)
		{
			tile.item.Explode();
			tile.item = null;
		}
		for (int x = 0; x < maxX; x++)
		{
			for (int y = 0; y < maxY; y++)
			{
				if (map[x, y].item == null)
				{
					for (int i = y + 1; i < maxY; i++)
					{
						if (map[x, i].item != null)
						{
							map[x, y].item = map[x, i].item;
							map[x, y].itemType = map[x, i].itemType;
							map[x, i].item = null;
							map[x, i].itemType = ItemType.None;
							map[x, y].item.MoveTo(new Vector3(x, y));
							break;
						}
					}
				}
			}
		}
	}

	public bool FreeDuck(Tile tile)
	{
		tile.item.Explode();
		tile.item = null;
		for (int i = tile.y + 1; i < map.GetLength(1); i++)
		{
			if (map[tile.x, i].item != null)
			{
				map[tile.x, tile.y].item = map[tile.x, i].item;
				map[tile.x, i].item = null;
				map[tile.x, tile.y].item.MoveTo(new Vector3(tile.x, tile.y));
				break;
			}
		}
		return true;
	}
}