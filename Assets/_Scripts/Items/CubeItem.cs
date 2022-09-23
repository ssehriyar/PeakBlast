using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class CubeItem : Item
{
	public override void SetSprite()
	{
		switch (matchType)
		{
			case MatchType.Red:
				spriteRenderer.sprite = scriptableContainer.spritesSC.RedCube;
				break;
			case MatchType.Green:
				spriteRenderer.sprite = scriptableContainer.spritesSC.GreenCube;
				break;
			case MatchType.Blue:
				spriteRenderer.sprite = scriptableContainer.spritesSC.BlueCube;
				break;
			case MatchType.Yellow:
				spriteRenderer.sprite = scriptableContainer.spritesSC.YellowCube;
				break;
			case MatchType.Purple:
				spriteRenderer.sprite = scriptableContainer.spritesSC.PurpleCube;
				break;
		}
	}

	public override bool Execute()
	{
		return command.MathcSearch(tile);
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
		SoundManager.Instance.PlaySound(scriptableContainer.audioSC.GetAudioClip(AudioType.CubeExplode));
		CreateParticle();
		DestroyObject();
	}

	public override void GoalExplode(Vector3 pos)
	{
		SoundManager.Instance.PlaySound(scriptableContainer.audioSC.GetAudioClip(AudioType.CubeExplode));
		CreateParticle();
		tweener = transform.DOMove(pos, moveSpeedToUI).OnComplete(() => OnMoveCompleted());
	}

	public void OnMoveCompleted()
	{
		SoundManager.Instance.PlaySound(scriptableContainer.audioSC.GetAudioClip(AudioType.CubeCollect));
		CreateParticle();
		DestroyObject();
	}

	public void CreateParticle()
	{
		Particle p = Instantiate(scriptableContainer.particleSC.particle, transform.position, Quaternion.identity).GetComponent<Particle>();
		p.SetParticleColor(scriptableContainer.colorSC.GetColorByMatchType(matchType));
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