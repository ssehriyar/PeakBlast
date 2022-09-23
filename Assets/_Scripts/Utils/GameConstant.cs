using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameConstant : MonoBehaviour
{
	public static GameConstant Instance { get; private set; }
	public float FallSpeed = 0.3f;
	public float MovingToUI = 0.5f;

	private void Awake()
	{
		Instance = this;
	}
}