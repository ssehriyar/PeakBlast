using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct TileAttribute
{
	public int x;
	public int y;
	public Tile[] neighbourTiles;
	public ItemType itemType;
	public MatchType matchType;
}
