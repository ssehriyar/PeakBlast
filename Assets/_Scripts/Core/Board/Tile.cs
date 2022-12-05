using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
	public int x;
	public int y;
	public Tile[] neighbourTiles;
	public ItemType itemType;
	[HideInInspector] public Item item;

	public void Init(Tile[] neigbours, int x, int y)
	{
		this.x = x;
		this.y = y;
		neighbourTiles = neigbours;
		item.SetTile(this);
	}

	public bool HasItem => item != null;

	public void ApplyItemType()
	{
		Item temp = ItemFactory.CreateItem(this, itemType, item.transform.position, item.transform.parent);
		DestroyImmediate(item.gameObject);
		item = temp;
	}

	// Editor function
	public void ApplyItemType2()
	{
		Item temp;
		switch (itemType)
		{
			case ItemType.RedCube:
				temp = ItemFactory.CreateCubeItem(this, item.gameObject, MatchType.Red);
				DestroyImmediate(item);
				item = temp;
				break;
			case ItemType.GreenCube:
				temp = ItemFactory.CreateCubeItem(this, item.gameObject, MatchType.Green);
				DestroyImmediate(item);
				item = temp;
				break;
			case ItemType.BlueCube:
				temp = ItemFactory.CreateCubeItem(this, item.gameObject, MatchType.Blue);
				DestroyImmediate(item);
				item = temp;
				break;
			case ItemType.YellowCube:
				temp = ItemFactory.CreateCubeItem(this, item.gameObject, MatchType.Yellow);
				DestroyImmediate(item);
				item = temp;
				break;
			case ItemType.PurpleCube:
				temp = ItemFactory.CreateCubeItem(this, item.gameObject, MatchType.Purple);
				DestroyImmediate(item);
				item = temp;
				break;
			case ItemType.Balloon:
				temp = ItemFactory.CreateBalloonItem(this, item.gameObject, MatchType.None);
				DestroyImmediate(item);
				item = temp;
				break;
			case ItemType.Duck:
				temp = ItemFactory.CreateDuckItem(this, item.gameObject, MatchType.None);
				DestroyImmediate(item);
				item = temp;
				break;
			case ItemType.LeftRocket:
				temp = ItemFactory.CreateLeftRocketItem(this, item.gameObject, MatchType.Special);
				DestroyImmediate(item);
				item = temp;
				break;
			case ItemType.RightRocket:
				temp = ItemFactory.CreateRightRocketItem(this, item.gameObject, MatchType.Special);
				DestroyImmediate(item);
				item = temp;
				break;
		}
	}
}