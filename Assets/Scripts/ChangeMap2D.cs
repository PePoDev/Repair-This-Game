using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMap2D : MonoBehaviour
{
	public string mapName;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			SoundManager.Instance.PlayFade();
			Initiate.Fade(mapName, Color.black, 1f);
		}
	}
}