using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
	public static SoundManager Instance { get; private set; }
	[SerializeField] private AudioSource _audioSource;

	private void Awake()
	{
		Instance = this;
	}

	public void PlaySound(AudioClip audioClip)
	{
		_audioSource.PlayOneShot(audioClip);
	}
}