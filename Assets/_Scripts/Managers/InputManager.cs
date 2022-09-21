using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
			if (hit)
			{
				TileManager.Instance.FindTypeAction(hit.transform.GetComponent<Tile>());
				Debug.Log(hit.transform.name);
			}
		}
	}
}