using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GridGenerator : MonoBehaviour
{
	[SerializeField] private Grid _grid;
	[SerializeField] private GameObject _tilePrefab;
	[SerializeField] private GameObject _borderPrefab;
	private GridCanvas _gridCanvas;
	private BorderCanvas _borderCanvas;
	private Camera _cam;
	//private GridLayoutGroup _gridLayout;

	public Grid GetGrid => _grid;

	public void SetParameters()
	{
		_gridCanvas = FindObjectOfType<GridCanvas>();
		//_gridLayout = _gridCanvas.GetComponent<GridLayoutGroup>();
		_borderCanvas = FindObjectOfType<BorderCanvas>();
		_cam = Camera.main;
	}

	public void GenerateGrid()
	{
		//_gridLayout.constraintCount = _grid.width;
		for (int x = 0; x < _grid.width; x++)
		{
			for (int y = 0; y < _grid.height; y++)
			{
				//GameObject spawnedTile = Instantiate(_tilePrefab, _gridCanvas.transform);
				GameObject spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity, _gridCanvas.transform);
				spawnedTile.name = $"Tile {x} {y}";
				spawnedTile.GetComponent<Renderer>().sortingOrder = y;
			}
		}
		_cam.transform.position = new Vector3(_grid.width * 0.5f - 0.5f, _grid.height * 0.5f - 0.5f, _cam.transform.position.z);

		var border = Instantiate(_borderPrefab, _borderCanvas.transform);
		border.transform.position = new Vector3(_grid.width * 0.5f - 0.5f, _grid.height * 0.5f - 0.5f, 1);
		border.transform.localScale = new Vector3(_grid.width, _grid.height, 1);
	}

	public void ClearGrid()
	{
		if (_gridCanvas.transform.childCount == 0) return;

		for (int i = _gridCanvas.transform.childCount; i > 0; --i)
		{
			DestroyImmediate(_gridCanvas.transform.GetChild(0).gameObject);
		}

		if (_borderCanvas.transform.childCount == 0) return;

		for (int i = _borderCanvas.transform.childCount; i > 0; --i)
		{
			DestroyImmediate(_borderCanvas.transform.GetChild(0).gameObject);
		}
	}
}