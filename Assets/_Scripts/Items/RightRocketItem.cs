using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RightRocketItem : Item
{
	public override void Init(int orderInLayer)
	{
		base.Init(orderInLayer);
		spriteRenderer.sprite = scriptableContainer.sprites.RightRocket;
	}

	public override MatchType GetMatchType()
	{
		return MatchType.Special;
	}

	public override bool CanBeExplodedByTouch()
	{
		return true;
	}

	public override bool CanBeMatchedByTouch()
	{
		return false;
	}

	public override bool CanFall()
	{
		return true;
	}

	public override bool CanBeExplodedByNeighbourMatch()
	{
		return true;
	}

	public override void Explode()
	{
		Destroy(gameObject);
	}

	public override void SpecialAction(Tile tile, ref Stack<Tile> tiles)
	{
		tiles.Push(tile);
		while (tile.neighbourTiles[(int)Direction.Right] != null)
		{
			tiles.Push(tile.neighbourTiles[(int)Direction.Right]);
			tile = tile.neighbourTiles[(int)Direction.Right];
		}
	}
}