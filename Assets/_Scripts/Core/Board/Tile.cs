using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
	//public TileAttribute tileAttribute;
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
	}

	public bool HasItem => item != null;

	public void ApplyItemType()
	{
		Item temp;
		switch (itemType)
		{
			case ItemType.RedCube:
				temp = ItemFactory.CreateCubeItem(item.gameObject, item.spriteRenderer.sortingOrder, MatchType.Red);
				DestroyImmediate(item);
				item = temp;
				break;
			case ItemType.GreenCube:
				temp = ItemFactory.CreateCubeItem(item.gameObject, item.spriteRenderer.sortingOrder, MatchType.Green);
				DestroyImmediate(item);
				item = temp;
				break;
			case ItemType.BlueCube:
				temp = ItemFactory.CreateCubeItem(item.gameObject, item.spriteRenderer.sortingOrder, MatchType.Blue);
				DestroyImmediate(item);
				item = temp;
				break;
			case ItemType.YellowCube:
				temp = ItemFactory.CreateCubeItem(item.gameObject, item.spriteRenderer.sortingOrder, MatchType.Yellow);
				DestroyImmediate(item);
				item = temp;
				break;
			case ItemType.PurpleCube:
				temp = ItemFactory.CreateCubeItem(item.gameObject, item.spriteRenderer.sortingOrder, MatchType.Purple);
				DestroyImmediate(item);
				item = temp;
				break;
			case ItemType.Balloon:
				temp = ItemFactory.CreateBalloonItem(item.gameObject, item.spriteRenderer.sortingOrder);
				DestroyImmediate(item);
				item = temp;
				break;
			case ItemType.Duck:
				temp = ItemFactory.CreateDuckItem(item.gameObject, item.spriteRenderer.sortingOrder);
				DestroyImmediate(item);
				item = temp;
				break;
			case ItemType.LeftRocket:
				temp = ItemFactory.CreateLeftRocketItem(item.gameObject, item.spriteRenderer.sortingOrder);
				DestroyImmediate(item);
				item = temp;
				break;
			case ItemType.RightRocket:
				temp = ItemFactory.CreateRightRocketItem(item.gameObject, item.spriteRenderer.sortingOrder);
				DestroyImmediate(item);
				item = temp;
				break;
		}
	}
}