using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public abstract class Item : MonoBehaviour
{
	public ScriptableContainer scriptableContainer;
	public SpriteRenderer spriteRenderer;

	public virtual void Init(int orderInLayer)
	{
		scriptableContainer = FindObjectOfType<ScriptableContainer>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sortingOrder = orderInLayer;
	}

	public virtual void Init(int orderInLayer, MatchType matchType) { }

	public abstract MatchType GetMatchType();

	public abstract bool CanBeExplodedByTouch();

	public abstract bool CanBeMatchedByTouch();

	public abstract bool CanFall();

	public abstract bool CanBeExplodedByNeighbourMatch();

	public abstract void Explode();

	public virtual void MoveTo(Vector3 pos)
	{
		transform.DOMove(pos, 0.3f);
	}

	public abstract void SpecialAction(Tile tile, ref Stack<Tile> tiles);
}