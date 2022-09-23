using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour
{
	private Tile[,] _map;
	private Stack<Tile> _tiles;
	[SerializeField] private GoalManager _goalManager;
	[SerializeField] private Transform _itemParent;
	[SerializeField] private int _minMatchNumber = 2;

	private void Start()
	{
		_tiles = new Stack<Tile>();
		_map = TileManager.Instance.Map;
	}

	public void Fall()
	{
		for (int x = 0; x < _map.GetLength(0); x++)
		{
			for (int y = 0; y < _map.GetLength(1); y++)
			{
				if (_map[x, y].item == null)
				{
					_map[x, y].item = ItemFactory.CreateRandomItem(_map[x, y], new Vector3(x, y + _map.GetLength(1)), _itemParent);
				}
			}
		}
	}

	public void Fill()
	{
		for (int x = 0; x < _map.GetLength(0); x++)
		{
			for (int y = 0; y < _map.GetLength(1); y++)
			{
				if (_map[x, y].item == null)
				{
					for (int i = y + 1; i < _map.GetLength(1); i++)
					{
						if (_map[x, i].item != null)
						{
							_map[x, y].item = _map[x, i].item;
							_map[x, y].itemType = _map[x, i].itemType;
							_map[x, i].item = null;
							_map[x, i].itemType = ItemType.None;
							_map[x, y].item.SetTile(_map[x, y]);
							_map[x, y].item.FallToPos(new Vector3(x, y));
							break;
						}
					}
				}
			}
		}
		_tiles.Clear();
	}

	public bool MathcSearch(Tile tile)
	{
		bool[,] visited = new bool[_map.GetLength(0), _map.GetLength(1)];
		FindMatch(tile, tile.item.matchType, visited);
		if (_tiles.Count >= _minMatchNumber)
		{
			DestroyMatchedTiles(_tiles);
			return true;
		}
		else
		{
			return false;
		}
	}

	private void FindMatch(Tile tile, MatchType matchType, bool[,] visited)
	{
		if (tile == null || visited[tile.x, tile.y] || matchType == MatchType.None) return;

		visited[tile.x, tile.y] = true;

		if (tile.item.matchType == matchType) // Cube
		{
			for (int i = 0; i < tile.neighbourTiles.Length; i++)
			{
				FindMatch(tile.neighbourTiles[i], matchType, visited);
			}
			_tiles.Push(tile);
		}
	}

	public void ClearLeftRow(Tile tile)
	{
		JustPickLeftRow(tile);
		foreach (Tile t in _tiles)
		{
			Destroy(t);
			t.item = null;
		}
		Fill();
		Fall();
	}

	public void JustPickLeftRow(Tile tile)
	{
		if (!_tiles.Contains(tile))
		{
			_tiles.Push(tile);
		}
		while (tile.neighbourTiles[(int)Direction.Left] != null)
		{
			tile = tile.neighbourTiles[(int)Direction.Left];
			if (tile.HasItem && !_tiles.Contains(tile))
			{
				_tiles.Push(tile);
				tile.item.SpecialExecute();
			}
		}
	}

	public void ClearRightRow(Tile tile)
	{
		JustPickRightRow(tile);
		foreach (Tile t in _tiles)
		{
			Destroy(t);
			t.item = null;
		}
		Fill();
		Fall();
	}

	public void JustPickRightRow(Tile tile)
	{
		if (!_tiles.Contains(tile))
		{
			_tiles.Push(tile);
		}
		while (tile.neighbourTiles[(int)Direction.Right] != null)
		{
			tile = tile.neighbourTiles[(int)Direction.Right];
			if (tile.HasItem && !_tiles.Contains(tile))
			{
				_tiles.Push(tile);
				tile.item.SpecialExecute();
			}
		}
	}

	public void DestroyMatchedTiles(Stack<Tile> tiles)
	{
		foreach (var tile in tiles)
		{
			Destroy(tile);
			for (int i = 0; i < tile.neighbourTiles.Length; i++)
			{
				if (tile.neighbourTiles[i] != null &&
					tile.neighbourTiles[i].HasItem &&
					tile.neighbourTiles[i].item.ExplodeNeighbourmatch())
				{
					tile.neighbourTiles[i].item.Explode();
					tile.neighbourTiles[i].item = null;
				}
			}
			tile.item = null;
		}
		Fill();
		Fall();
	}

	public void Destroy(Tile tile)
	{
		if (_goalManager.CheckGoalType(tile.itemType).Item1)
		{
			tile.item.GoalExplode(_goalManager.CheckGoalType(tile.itemType).Item2);
		}
		else
		{
			tile.item.Explode();
		}
	}

	public void DestroyOneTile(Tile tile)
	{
		Destroy(tile);
		tile.item = null;
		Fill();
		Fall();
	}
}