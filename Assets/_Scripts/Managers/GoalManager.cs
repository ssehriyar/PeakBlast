using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class GoalManager : MonoBehaviour
{
	public int MovesCount { get; private set; }
	public Goal[] Goals { get; private set; }
	public Transform[] GoalUITransforms { get; private set; }
	[SerializeField] private Transform _goalsParent;
	[SerializeField] private GameObject _imgGoalPrefab;
	[SerializeField] private ScriptableContainer _scriptableContainer;

	public UnityEvent<int> OnMovesCountUpdate;
	public UnityEvent<Goal> OnGoalUpdate;

	private void Awake()
	{
		InitGoals();
	}

	private void Start()
	{
		OnMovesCountUpdate.AddListener(GameEndingControl);
		OnMovesCountUpdate?.Invoke(MovesCount);
	}

	public void InitGoals()
	{
		Goals = new Goal[_scriptableContainer.goalSC.goals.Count];
		GoalUITransforms = new Transform[_scriptableContainer.goalSC.goals.Count];
		MovesCount = _scriptableContainer.goalSC.moveCount;
		GoalUI goUI;
		Goal goal;
		for (int i = 0; i < Goals.Length; i++)
		{
			goal = _scriptableContainer.goalSC.goals[i];
			goUI = Instantiate(_imgGoalPrefab, _goalsParent).GetComponent<GoalUI>();
			goUI.Init(goal, GetSprite(goal.ItemType));
			OnGoalUpdate.AddListener(goUI.SetValue);
			Goals[i] = goal;
			GoalUITransforms[i] = goUI.transform;
		}
	}

	public void DecreaseMoveCount()
	{
		MovesCount -= 1;
		if (MovesCount < 0)
		{
			MovesCount = 0;
		}
		OnMovesCountUpdate?.Invoke(MovesCount);
	}

	public (bool, Vector3) CheckGoalType(ItemType itemType)
	{
		for (int i = 0; i < Goals.Length; i++)
		{
			if (Goals[i].ItemType == itemType)
			{
				Goals[i].count--;
				if (Goals[i].count <= 0)
				{
					Goals[i].count = 0;
				}
				OnGoalUpdate?.Invoke(Goals[i]);
				return (true, GoalUITransforms[i].position);
			}
		}
		return (false, Vector3.zero);
	}

	public void GameEndingControl(int count)
	{
		int totalCount = 0;
		for (int i = 0; i < Goals.Length; i++)
		{
			totalCount += Goals[i].count;
		}
		if (totalCount == 0)
		{
			GameManager.Instance.SetGameState(GameState.Win);
		}
		else if (count <= 0 && totalCount > 0)
		{
			GameManager.Instance.SetGameState(GameState.Fail);
		}
	}

	public Sprite GetSprite(ItemType itemType)
	{
		switch (itemType)
		{
			case ItemType.RedCube:
				return _scriptableContainer.spritesSC.RedCube;
			case ItemType.GreenCube:
				return _scriptableContainer.spritesSC.GreenCube;
			case ItemType.BlueCube:
				return _scriptableContainer.spritesSC.BlueCube;
			case ItemType.YellowCube:
				return _scriptableContainer.spritesSC.YellowCube;
			case ItemType.PurpleCube:
				return _scriptableContainer.spritesSC.PurpleCube;
			case ItemType.Balloon:
				return _scriptableContainer.spritesSC.Balloon;
			case ItemType.Duck:
				return _scriptableContainer.spritesSC.Duck;
			case ItemType.LeftRocket:
				return _scriptableContainer.spritesSC.LeftRocket;
			case ItemType.RightRocket:
				return _scriptableContainer.spritesSC.RightRocket;
			default:
				return null;
		}
	}

	private void OnDestroy()
	{
		OnMovesCountUpdate.RemoveAllListeners();
		OnGoalUpdate.RemoveAllListeners();
	}
}