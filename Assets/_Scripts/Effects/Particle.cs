using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Particle : MonoBehaviour
{
	// Animation event
	public void AnimationFinished()
	{
		Destroy(gameObject);
	}

	public void SetParticleColor(Color color)
	{
		foreach (Transform t in transform)
		{
			t.GetComponent<SpriteRenderer>().color = color;
		}
	}
}