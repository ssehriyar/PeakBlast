using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class MovesUI : MonoBehaviour
{
	private TMP_Text _text;

	private void Awake()
	{
		_text = GetComponent<TMP_Text>();
	}

	public void SetValue(int value)
	{
		_text.text = value.ToString();
	}
}