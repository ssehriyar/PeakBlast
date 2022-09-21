using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class ItemFactory
{
	private static GameObject _itemPrefab;

	public static Item CreateItem(ItemType itemType, Vector3 pos, Transform parent)
	{
		if (_itemPrefab == null)
		{
			_itemPrefab = Resources.Load("Item") as GameObject;
		}

		GameObject newGo = GameObject.Instantiate(_itemPrefab, pos, Quaternion.identity, parent);

		switch (itemType)
		{
			case ItemType.RedCube:
				return CreateCubeItem(newGo, (int)pos.y, MatchType.Red);
			case ItemType.GreenCube:
				return CreateCubeItem(newGo, (int)pos.y, MatchType.Green);
			case ItemType.BlueCube:
				return CreateCubeItem(newGo, (int)pos.y, MatchType.Blue);
			case ItemType.YellowCube:
				return CreateCubeItem(newGo, (int)pos.y, MatchType.Yellow);
			case ItemType.PurpleCube:
				return CreateCubeItem(newGo, (int)pos.y, MatchType.Purple);
			case ItemType.Balloon:
				return CreateBalloonItem(newGo, (int)pos.y);
			case ItemType.Duck:
				return CreateDuckItem(newGo, (int)pos.y);
			case ItemType.LeftRocket:
				return CreateLeftRocketItem(newGo, (int)pos.y);
			case ItemType.RightRocket:
				return CreateRightRocketItem(newGo, (int)pos.y);
		}
		return null;
	}

	public static Item CreateRandomItem(Vector3 pos, Transform parent)
	{
		ItemType itemYTpe = (ItemType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(ItemType)).Length - 1);
		return CreateItem(itemYTpe, pos, parent);
	}

	public static Item CreateCubeItem(GameObject go, int orderInLayer, MatchType matchType)
	{
		var cubeItem = go.AddComponent<CubeItem>();
		cubeItem.Init(orderInLayer, matchType);
		return cubeItem;
	}

	public static Item CreateDuckItem(GameObject go, int orderInLayer)
	{
		var duckItem = go.AddComponent<DuckItem>();
		duckItem.Init(orderInLayer);
		return duckItem;
	}

	public static Item CreateBalloonItem(GameObject go, int orderInLayer)
	{
		var balloonItem = go.AddComponent<BalloonItem>();
		balloonItem.Init(orderInLayer);
		return balloonItem;
	}

	public static Item CreateLeftRocketItem(GameObject go, int orderInLayer)
	{
		var leftRocketItem = go.AddComponent<LeftRocketItem>();
		leftRocketItem.Init(orderInLayer);
		return leftRocketItem;
	}

	public static Item CreateRightRocketItem(GameObject go, int orderInLayer)
	{
		var rightRocketItem = go.AddComponent<RightRocketItem>();
		rightRocketItem.Init(orderInLayer);
		return rightRocketItem;
	}
}