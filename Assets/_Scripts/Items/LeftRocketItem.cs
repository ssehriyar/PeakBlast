using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeftRocketItem : Item
{
	public override void Init(int orderInLayer)
	{
		base.Init(orderInLayer);
		spriteRenderer.sprite = scriptableContainer.sprites.LeftRocket;
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
		return false;
	}

	public override void Explode()
	{
		Destroy(gameObject);
	}

	public override void SpecialAction(Tile tile, ref Stack<Tile> tiles)
	{
		tiles.Push(tile);
		while (tile.neighbourTiles[(int)Direction.Left] != null)
		{
			tiles.Push(tile.neighbourTiles[(int)Direction.Left]);
			tile = tile.neighbourTiles[(int)Direction.Left];
		}
	}
}