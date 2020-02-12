using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
	public Sprite[] backgrounds;

	private bool attack = false;

	private IEnumerator Start()
	{
		var collider = GetComponent<BoxCollider2D>();
		var spriteRenderer = GetComponent<SpriteRenderer>();
		while (true)
		{
			spriteRenderer.sprite = attack ? backgrounds[1] : backgrounds[0];
			collider.enabled = attack;
			attack = !attack;
			SoundManager.Instance.PlayTrap();
			yield return new WaitForSeconds(2f);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			SoundManager.Instance.PlayGameOver();
			FindObjectOfType<HpController>().GameOverNow();
		}
	}
}