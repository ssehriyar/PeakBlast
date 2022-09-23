using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Colors", menuName = "Scriptables/Colors")]
public class ColorSC : ScriptableObject
{
	public List<ColorType> colors = new List<ColorType>();

	public Color GetColorByMatchType(MatchType matchType)
	{
		for (int i = 0; i < colors.Count; i++)
		{
			if(colors[i].matchType == matchType)
			{
				return colors[i].color;
			}
		}
		return Color.clear;
	}
}