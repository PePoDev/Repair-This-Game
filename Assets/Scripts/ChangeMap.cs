using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMap : MonoBehaviour
{
	public string mapName;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			SoundManager.Instance.PlayFade();
			Initiate.Fade(mapName, Color.black, 1f);
		}
	}
}