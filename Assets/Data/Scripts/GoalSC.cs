using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Goal", menuName = "Scriptables/Goal")]
public class GoalSC : ScriptableObject
{
	public int moveCount;
	public List<Goal> goals;
}