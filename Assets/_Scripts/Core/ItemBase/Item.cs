using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public abstract class Item : MonoBehaviour
{
	public Tile tile;
	public MatchType matchType;
	public Command command;
	public SpriteRenderer spriteRenderer;
	public ScriptableContainer scriptableContainer;
	protected Tweener tweener;
	protected float fallSpeed;
	protected float moveSpeedToUI;

	public virtual void Init(Tile tile, MatchType matchType)
	{
		this.tile = tile;
		this.matchType = matchType;
		command = FindObjectOfType<Command>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		scriptableContainer = FindObjectOfType<ScriptableContainer>();
		spriteRenderer.sortingOrder = tile.y;
		tweener = null;
		if (Application.isPlaying)
		{
			fallSpeed = GameConstant.Instance.FallSpeed;
			moveSpeedToUI = GameConstant.Instance.MovingToUI;
		}
		SetSprite();
		SetTile(tile);
		FallToPos(new Vector3(tile.x, tile.y));
	}

	protected virtual void Start()
	{
		fallSpeed = GameConstant.Instance.FallSpeed;
		moveSpeedToUI = GameConstant.Instance.MovingToUI;
	}

	public abstract void SetSprite();
	public abstract bool Execute();
	public abstract void SpecialExecute();
	public abstract bool CanFall();
	public abstract bool ExplodeNeighbourmatch();
	public abstract void Explode();
	public abstract void GoalExplode(Vector3 pos);

	public virtual void SetTile(Tile tile)
	{
		this.tile = tile;
		spriteRenderer.sortingOrder = tile.y;
	}

	public virtual void FallToPos(Vector3 pos)
	{
		transform.DOMove(pos, fallSpeed);
	}
}