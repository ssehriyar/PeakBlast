using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class TileManager : MonoBehaviour
{
	public static TileManager Instance { get; private set; }
	[SerializeField] private Board board;
	[SerializeField] private Transform _tileParent;

	public Tile[,] Map { get; private set; }

	private void Awake()
	{
		Instance = this;
		GetBoardInfo();
		InitTiles();
		DOTween.SetTweensCapacity(500, 100);
	}

	private void GetBoardInfo()
	{
		Map = new Tile[board.GetGrid.width, board.GetGrid.height];
		int counter = 0;
		for (int i = 0; i < board.GetGrid.width; i++)
		{
			for (int j = 0; j < board.GetGrid.height; j++)
			{
				Tile tile = _tileParent.GetChild(counter).GetComponent<Tile>();
				Map[i, j] = tile;
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
				Map[i, j].Init(TileNeighbours(i, j), i, j);
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

		if (x >= Map.GetLength(0) || x < 0 || y >= Map.GetLength(1) || y < 0) return null;

		return Map[x, y];
	}
}