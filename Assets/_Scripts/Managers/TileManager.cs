using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TileManager : MonoBehaviour
{
	public static TileManager Instance { get; private set; }
	private Stack<Tile> tiles;
	private ActionManager _actionManager;
	[SerializeField] private GameObject _gameObject;

	public Tile[,] map;
	[SerializeField] private GridGenerator level;

	public void Du(Vector3 pos)
	{
		var go = Instantiate(_gameObject, pos, Quaternion.identity, transform);
		go.GetComponent<Tile>().tileAttribute.x = (int)pos.x;
		go.GetComponent<Tile>().tileAttribute.y = (int)pos.y;
		go.name = $"Tile {pos.x} {pos.y}";
		go.GetComponent<Renderer>().sortingOrder = (int)pos.y;
	}

	private void Awake()
	{
		Instance = this;

		map = new Tile[level.GetGrid.width, level.GetGrid.height];
		int counter = 0;
		for (int i = 0; i < level.GetGrid.width; i++)
		{
			for (int j = 0; j < level.GetGrid.height; j++)
			{
				map[i, j] = transform.GetChild(counter).GetComponent<Tile>();
				map[i, j].tileAttribute.x = i;
				map[i, j].tileAttribute.y = j;
				counter++;
			}
		}

		_actionManager = new ActionManager(ref map);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
			if (hit)
			{
				FindTypeAction(hit.transform.GetComponent<Tile>());
				Debug.Log(hit.transform.name);
			}
		}
	}

	public void FindTypeAction(Tile tile)
	{
		switch (tile.tileAttribute.type)
		{
			case TileType.Balloon:
				break;
			case TileType.Duck:
				break;
			case TileType.LeftRocket:
				LeftRowClear(tile);
				break;
			case TileType.RightRocket:
				RightRowClear(tile);
				break;
			default:
				TileSearch(tile);
				break;
		}
	}

	public void TileSearch(Tile tile)
	{
		tiles = new Stack<Tile>();
		MatchSearch.Instance.Search(map, tile, ref tiles);
		if (tiles.Count > 1)
		{
			_actionManager.Fill(tiles);
		}
		switch (tiles.Count)
		{
			case 2:
				break;
			case 3:
				break;
		}
		Debug.Log(tiles.Count);
	}

	public void RightRowClear(Tile tile)
	{
		tiles = new Stack<Tile>();
		for (int i = tile.tileAttribute.x; i < map.GetLength(0); i++)
		{
			tiles.Push(map[i, tile.tileAttribute.y]);
		}
		_actionManager.Fill(tiles);
	}

	public void LeftRowClear(Tile tile)
	{
		tiles = new Stack<Tile>();
		for (int i = tile.tileAttribute.x; i >= 0; i--)
		{
			tiles.Push(map[i, tile.tileAttribute.y]);
		}
		_actionManager.Fill(tiles);
	}
}