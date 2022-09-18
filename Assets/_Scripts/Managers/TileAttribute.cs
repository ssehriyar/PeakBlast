using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct TileAttribute
{
	public int x;
	public int y;
	public TileType type;
}

public enum TileType
{
	Red,
	Green,
	Blue,
	Yellow,
	Purple,
	Balloon,
	Duck,
	LeftRocket,
	RightRocket,
}