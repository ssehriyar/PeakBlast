using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class ItemFactory
{
	private static GameObject _itemPrefab;

	public static Item CreateItem(Tile tile, ItemType itemType, Vector3 pos, Transform parent)
	{
		if (_itemPrefab == null)
		{
			_itemPrefab = Resources.Load("Item") as GameObject;
		}

		GameObject newGo = GameObject.Instantiate(_itemPrefab, pos, Quaternion.identity, parent);

		switch (itemType)
		{
			case ItemType.RedCube:
				return CreateCubeItem(tile, newGo, MatchType.Red);
			case ItemType.GreenCube:
				return CreateCubeItem(tile, newGo, MatchType.Green);
			case ItemType.BlueCube:
				return CreateCubeItem(tile, newGo, MatchType.Blue);
			case ItemType.YellowCube:
				return CreateCubeItem(tile, newGo, MatchType.Yellow);
			case ItemType.PurpleCube:
				return CreateCubeItem(tile, newGo, MatchType.Purple);
			case ItemType.Balloon:
				return CreateBalloonItem(tile, newGo, MatchType.None);
			case ItemType.Duck:
				return CreateDuckItem(tile, newGo, MatchType.None);
			case ItemType.LeftRocket:
				return CreateLeftRocketItem(tile, newGo, MatchType.Special);
			case ItemType.RightRocket:
				return CreateRightRocketItem(tile, newGo, MatchType.Special);
		}
		return null;
	}

	public static Item CreateRandomItem(Tile tile, Vector3 pos, Transform parent)
	{
		ItemType itemYTpe = (ItemType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(ItemType)).Length - 1);
		tile.itemType = itemYTpe;
		return CreateItem(tile, itemYTpe, pos, parent);
	}

	public static Item CreateCubeItem(Tile tile, GameObject go, MatchType matchType)
	{
		var cubeItem = go.AddComponent<CubeItem>();
		cubeItem.Init(tile, matchType);
		return cubeItem;
	}

	public static Item CreateDuckItem(Tile tile, GameObject go, MatchType matchType)
	{
		var duckItem = go.AddComponent<DuckItem>();
		duckItem.Init(tile, matchType);
		return duckItem;
	}

	public static Item CreateBalloonItem(Tile tile, GameObject go, MatchType matchType)
	{
		var balloonItem = go.AddComponent<BalloonItem>();
		balloonItem.Init(tile, matchType);
		return balloonItem;
	}

	public static Item CreateLeftRocketItem(Tile tile, GameObject go, MatchType matchType)
	{
		var leftRocketItem = go.AddComponent<LeftRocketItem>();
		leftRocketItem.Init(tile, matchType);
		return leftRocketItem;
	}

	public static Item CreateRightRocketItem(Tile tile, GameObject go, MatchType matchType)
	{
		var rightRocketItem = go.AddComponent<RightRocketItem>();
		rightRocketItem.Init(tile, matchType);
		return rightRocketItem;
	}
}