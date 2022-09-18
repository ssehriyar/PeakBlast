using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class ActionManager
{
	private Tile[,] _map;
	private Dictionary<int, int> _emptySlotCounter;

	public ActionManager(ref Tile[,] map)
	{
		_map = map;
		_emptySlotCounter = new Dictionary<int, int>();
	}

	public void Fall()
	{

	}

	public void Fill(Stack<Tile> tiles)
	{
		foreach (Tile tile in tiles)
		{
			if (!_emptySlotCounter.ContainsKey(tile.tileAttribute.x))
			{
				_emptySlotCounter.Add(tile.tileAttribute.x, 0);
			}
			_emptySlotCounter[tile.tileAttribute.x] += 1;
			Debug.Log(tile.name);
			for (int i = tile.tileAttribute.y + 1; i < _map.GetLength(1); i++)
			{
				if (_map[tile.tileAttribute.x, i] != null)
				{
					Tile temp = _map[tile.tileAttribute.x, i];
					_map[temp.tileAttribute.x, temp.tileAttribute.y] = null;
					temp.tileAttribute.y -= 1;
					_map[temp.tileAttribute.x, temp.tileAttribute.y] = temp;
					if (!tiles.Contains(temp))
					{
						temp.transform.DOMove(new Vector3(temp.tileAttribute.x, temp.tileAttribute.y), 0.3f);
					}
				}
			}
			tile.Explode();
		}

		for (int i = 0; i < _map.GetLength(0); i++)
		{
			if (_emptySlotCounter.ContainsKey(i))
			{
				for (int j = _emptySlotCounter[i]; j > 0; j--)
				{
					TileManager.Instance.Du(new Vector3(i, _map.GetLength(1) - j));
				}
			}
		}
	}
}