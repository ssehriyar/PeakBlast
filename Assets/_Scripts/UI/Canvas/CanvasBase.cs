using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class CanvasBase : MonoBehaviour
{
	[SerializeField] protected GameState _gameState;

	protected virtual void Start()
	{
		GameManager.Instance.OnGameStateChanged += OnGameStateChange;
	}

	public abstract void OnGameStateChange(GameState gameState);

	protected virtual void OnDestroy()
	{
		GameManager.Instance.OnGameStateChanged -= OnGameStateChange;
	}
}