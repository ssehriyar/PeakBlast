using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
	[SerializeField] private Grid _grid;
	[SerializeField] private Camera _cam;
	[Space(5)]
	[SerializeField] private Transform _tileParent;
	[SerializeField] private Transform _itemParent;
	[SerializeField] private Transform _borderParent;
	[SerializeField] private GameObject _tilePrefab;
	//[SerializeField] private GameObject _itemPrefab;
	[SerializeField] private GameObject _borderPrefab;
	public Grid GetGrid => _grid;
	public ScriptableContainer scriptableContainer;

	public void GenerateBoard()
	{
		for (int x = 0; x < _grid.width; x++)
		{
			for (int y = 0; y < _grid.height; y++)
			{
				GameObject spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity, _tileParent);
				spawnedTile.name = $"Tile {x} {y}";
				Tile tile = spawnedTile.GetComponent<Tile>();
				tile.item = ItemFactory.CreateItem(tile.itemType, new Vector3(x, y), _itemParent);
			}
		}
		_cam.transform.position = new Vector3(_grid.width * 0.5f - 0.5f, _grid.height * 0.5f - 0.5f, _cam.transform.position.z);

		var border = Instantiate(_borderPrefab, _borderParent);
		border.transform.position = new Vector3(_grid.width * 0.5f - 0.5f, _grid.height * 0.5f - 0.5f, 1);
		border.GetComponent<SpriteRenderer>().size = new Vector2(_grid.width + 0.2f, _grid.height + 0.5f);
	}

	public void ClearBoard()
	{
		if (_tileParent.childCount != 0)
		{
			for (int i = _tileParent.childCount; i > 0; --i)
			{
				DestroyImmediate(_tileParent.GetChild(0).gameObject);
			}
		}

		if (_itemParent.childCount != 0)
		{
			for (int i = _itemParent.childCount; i > 0; --i)
			{
				DestroyImmediate(_itemParent.GetChild(0).gameObject);
			}
		}

		if (_borderParent.childCount != 0)
		{
			for (int i = _borderParent.childCount; i > 0; --i)
			{
				DestroyImmediate(_borderParent.GetChild(0).gameObject);
			}
		}
	}
}