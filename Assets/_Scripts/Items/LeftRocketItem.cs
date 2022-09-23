using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class LeftRocketItem : Item
{
	public override void SetSprite()
	{
		spriteRenderer.sprite = scriptableContainer.spritesSC.LeftRocket;
	}

	public override bool Execute()
	{
		command.ClearLeftRow(tile);
		return true;
	}

	public override void SpecialExecute()
	{
		command.JustPickLeftRow(tile);
	}

	public override bool CanFall()
	{
		return true;
	}

	public override bool ExplodeNeighbourmatch()
	{
		return false;
	}

	public override void Explode()
	{
		if (tweener.IsActive())
		{
			tweener.Kill(true);
		}
		Destroy(gameObject);
	}

	public override void GoalExplode(Vector3 pos)
	{
		tweener = transform.DOMove(pos, moveSpeedToUI)/*.OnComplete(() => Sound)*/;
	}
}