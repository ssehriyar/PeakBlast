using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class DuckItem : Item
{
	public override void Init(Tile tile, MatchType matchType)
	{
		base.Init(tile, matchType);
	}

	public override void SetSprite()
	{
		spriteRenderer.sprite = scriptableContainer.spritesSC.Duck;
	}

	public override bool Execute()
	{
		return false;
	}

	public override void SpecialExecute()
	{

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
		SoundManager.Instance.PlaySound(scriptableContainer.audioSC.GetAudioClip(AudioType.Duck));
		DestroyObject();
	}

	public override void GoalExplode(Vector3 pos)
	{
		tweener = transform.DOMove(pos, moveSpeedToUI).OnComplete(() => OnMoveCompleted());
	}

	public void OnMoveCompleted()
	{
		SoundManager.Instance.PlaySound(scriptableContainer.audioSC.GetAudioClip(AudioType.Duck));
		DestroyObject();
	}

	public override void FallToPos(Vector3 pos)
	{
		tweener = transform.DOMove(pos, fallSpeed).OnComplete(() => LastGrid());
	}

	private void LastGrid()
	{
		if (tile.y == 0)
		{
			command.DestroyOneTile(tile);
		}
	}

	public void DestroyObject()
	{
		if (tweener.IsActive())
		{
			tweener.Kill(true);
		}
		Destroy(gameObject);
	}
}