using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class GoalUI : MonoBehaviour
{
	private TMP_Text _text;
	private Goal _goal;

	private void Awake()
	{
		_text = GetComponentInChildren<TMP_Text>();
	}

	public void Init(Goal goal, Sprite sprite)
	{
		_goal = goal;
		GetComponent<Image>().sprite = sprite;
		_text.text = goal.count.ToString();
	}

	public void SetValue(Goal goal)
	{
		if (goal.ItemType == _goal.ItemType)
		{
			_text.text = goal.count.ToString();
		}
	}
}