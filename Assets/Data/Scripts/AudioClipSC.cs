using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "AudioClip", menuName = "Scriptables/AudioClip")]
public class AudioClipSC : ScriptableObject
{
	public List<Audio> audios;

	public AudioClip GetAudioClip(AudioType audioType)
	{
		for (int i = 0; i < audios.Count; i++)
		{
			if (audios[i].audioType == audioType)
			{
				return audios[i].audioClip;
			}
		}
		return null;
	}
}