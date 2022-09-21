using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TileManager : MonoBehaviour
{
	public static TileManager Instance { get; private set; }
	private Tile[,] map;
	private Stack<Tile> tiles;
	private ActionManager _actionManager;
	private MatchSearch _matchManager;
	[SerializeField] private Board board;
	[SerializeField] private Transform _tileParent;
	[SerializeField] private int _minMatchNumber = 2;

	private void Awake()
	{
		Instance = this;
		GetBoardInfo();
		InitTiles();

		tiles = new Stack<Tile>();
		_actionManager = new ActionManager(ref map);
		_matchManager = new MatchSearch(ref map);
	}

	private void GetBoardInfo()
	{
		map = new Tile[board.GetGrid.width, board.GetGrid.height];
		int counter = 0;
		for (int i = 0; i < board.GetGrid.width; i++)
		{
			for (int j = 0; j < board.GetGrid.height; j++)
			{
				Tile tile = _tileParent.GetChild(counter).GetComponent<Tile>();
				map[i, j] = tile;
				counter++;
			}
		}
	}

	private void InitTiles()
	{
		for (int i = 0; i < board.GetGrid.width; i++)
		{
			for (int j = 0; j < board.GetGrid.height; j++)
			{
				map[i, j].Init(TileNeighbours(i, j), i, j);
			}
		}
	}

	public Tile[] TileNeighbours(int x, int y)
	{
		Tile[] neig = new Tile[4];
		neig[(int)Direction.Left] = GetNeighbourWithDirection(x, y, Direction.Left);
		neig[(int)Direction.Up] = GetNeighbourWithDirection(x, y, Direction.Up);
		neig[(int)Direction.Right] = GetNeighbourWithDirection(x, y, Direction.Right);
		neig[(int)Direction.Down] = GetNeighbourWithDirection(x, y, Direction.Down);
		return neig;
	}

	public Tile GetNeighbourWithDirection(int x, int y, Direction direction)
	{
		switch (direction)
		{
			case Direction.Left:
				x -= 1;
				break;
			case Direction.Up:
				y += 1;
				break;
			case Direction.Right:
				x += 1;
				break;
			case Direction.Down:
				y -= 1;
				break;
		}

		if (x >= map.GetLength(0) || x < 0 || y >= map.GetLength(1) || y < 0) return null;

		return map[x, y];
	}

	public void FindTypeAction(Tile tile)
	{
		if (tile == null || !tile.HasItem) return;

		tiles.Clear();

		if (tile.item.CanBeMatchedByTouch())
		{
			TileSearch(tile);
		}
		else if (tile.item.CanBeExplodedByTouch())
		{
			tile.item.SpecialAction(tile, ref tiles);
			_actionManager.Fill(tiles);
			_actionManager.Fall();
		}
	}

	public void TileSearch(Tile tile)
	{
		int matchCounter = _matchManager.Search(tile, ref tiles);
		if (matchCounter >= _minMatchNumber)
		{
			_actionManager.Fill(tiles);
			_actionManager.Fall();
		}
		Debug.Log(tiles.Count);
	}

	public void LastTileControl()
	{
		for (int x = 0; x < map.GetLength(0); x++)
		{
			if (map[x, 0].item)
			{
				_actionManager.FreeDuck(map[x, 0]);
			}
		}
	}
}