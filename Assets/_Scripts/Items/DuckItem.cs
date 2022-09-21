using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DuckItem : Item
{
	public override void Init(int orderInLayer)
	{
		base.Init(orderInLayer);
		spriteRenderer.sprite = scriptableContainer.sprites.Duck;
	}

	public override MatchType GetMatchType()
	{
		return MatchType.None;
	}

	public override bool CanBeExplodedByTouch()
	{
		return false;
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
		
	}
}