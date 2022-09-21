using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubeItem : Item
{
	[SerializeField] private MatchType _matchType;

	public override void Init(int orderInLayer, MatchType matchType)
	{
		base.Init(orderInLayer);
		_matchType = matchType;
		SetSprite();
	}

	private void SetSprite()
	{
		switch (_matchType)
		{
			case MatchType.Red:
				spriteRenderer.sprite = scriptableContainer.sprites.RedCube;
				break;
			case MatchType.Green:
				spriteRenderer.sprite = scriptableContainer.sprites.GreenCube;
				break;
			case MatchType.Blue:
				spriteRenderer.sprite = scriptableContainer.sprites.BlueCube;
				break;
			case MatchType.Yellow:
				spriteRenderer.sprite = scriptableContainer.sprites.YellowCube;
				break;
			case MatchType.Purple:
				spriteRenderer.sprite = scriptableContainer.sprites.PurpleCube;
				break;
		}
	}

	public override MatchType GetMatchType()
	{
		return _matchType;
	}

	public override bool CanBeExplodedByTouch()
	{
		return false;
	}

	public override bool CanBeMatchedByTouch()
	{
		return true;
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