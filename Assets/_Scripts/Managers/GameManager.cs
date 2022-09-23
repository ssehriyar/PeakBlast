using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }
	private GameState _currentGameState;
	public Action<GameState> OnGameStateChanged;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		SetGameState(GameState.Play);
	}

	public GameState GetGameState => _currentGameState;

	public void SetGameState(GameState gameState)
	{
		_currentGameState = gameState;
		OnGameStateChanged?.Invoke(_currentGameState);
	}
}