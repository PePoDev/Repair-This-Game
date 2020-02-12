using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HpController : MonoBehaviour
{
	public GameObject gameOverUi;
	
	public int totalHp = 3;
	public Image[] hpObjects;

	public void TakeDamage()
	{
		SoundManager.Instance.PlayTakeDamage();
		totalHp -= 1;
		hpObjects[totalHp].enabled = false;
		Lebug.Log("Hp", totalHp, "HpController");
	}

	public bool IsGameOver()
	{
		return totalHp == 0;
	}

	public void GameOverNow()
	{
		SoundManager.Instance.PlayGameOver();
			Time.timeScale = 0f;
			gameOverUi.SetActive(true);
	}
	
	public void RestartNow()
	{
		SoundManager.Instance.PlayRestart();
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		gameOverUi.SetActive(false);
	}
}