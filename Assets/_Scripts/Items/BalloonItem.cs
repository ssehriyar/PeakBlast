using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class BalloonItem : Item
{
	public override void SetSprite()
	{
		spriteRenderer.sprite = scriptableContainer.spritesSC.Balloon;
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
		return true;
	}

	public override void Explode()
	{
		SoundManager.Instance.PlaySound(scriptableContainer.audioSC.GetAudioClip(AudioType.Balloon));
		DestroyObject();
	}

	public override void GoalExplode(Vector3 pos)
	{
		tweener = transform.DOMove(pos, moveSpeedToUI).OnComplete(() => OnMoveCompleted());
	}

	public void OnMoveCompleted()
	{
		SoundManager.Instance.PlaySound(scriptableContainer.audioSC.GetAudioClip(AudioType.Balloon));
		DestroyObject();
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