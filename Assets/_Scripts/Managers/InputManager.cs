using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
	[SerializeField] private GoalManager _goalManager;

	private void Start()
	{
		GameManager.Instance.OnGameStateChanged += OnGameStateChange;
	}

	private void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
			if (hit && hit.transform.GetComponent<Tile>().item.Execute())
			{
				_goalManager.DecreaseMoveCount();
			}
		}
	}

	private void OnGameStateChange(GameState gameState)
	{
		if (gameState != GameState.Play)
		{
			enabled = false;
		}
		else
		{
			enabled = true;
		}
	}

	private void OnDestroy()
	{
		GameManager.Instance.OnGameStateChanged -= OnGameStateChange;
	}
}