using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2D : MonoBehaviour
{
	private static int _totalTrigger = 0;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player") || other.CompareTag("item-condition"))
		{
			_totalTrigger++;
			Lebug.Log("Total Trigger", _totalTrigger, "Trigger 2D");
			
			if (_totalTrigger >= 4)
			{
				SoundManager.Instance.PlayFade();
				GameObject.Find("Background").GetComponent<BackgroundStage>().Next();
			}
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player") || other.CompareTag("item-condition"))
		{
			_totalTrigger--;
		}
	}
}