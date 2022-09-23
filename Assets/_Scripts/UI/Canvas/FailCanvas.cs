using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FailCanvas : CanvasBase
{
	protected override void Start()
	{
		base.Start();
		if (_gameState != GameManager.Instance.GetGameState)
		{
			gameObject.SetActive(false);
		}
	}

	public override void OnGameStateChange(GameState gameState)
	{
		if (gameState == _gameState)
		{
			gameObject.SetActive(true);
		}
	}
}