using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
	public TileAttribute tileAttribute;

	public void Explode()
	{
		Destroy(gameObject);
	}
}