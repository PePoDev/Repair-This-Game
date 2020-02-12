using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour
{
	public int bossHp = 7;
	public Animator boss;

	public Transform[] point;
	public FireBall fireBall;

	private float _time;
	private static readonly int Attack01 = Animator.StringToHash("attack_02");

	private float _delayTime = 3f;
	private float _speedBall = 1f;

	private void Start()
	{
		if (PlayerPrefs.HasKey("win"))
		{
			bossHp = 12;
		}
		else
		{
			bossHp = 4;
		}
	}

	private void Update()	
	{
		if (bossHp <= 0)
		{
			return;
		}

		_time += Time.deltaTime;
		while (_time > _delayTime)
		{
			boss.SetTrigger(Attack01);
			_time -= _delayTime;

			_delayTime -= .1f;

			SoundManager.Instance.PlayFireSpawn();
			var fireball = Instantiate(fireBall, point[Random.Range(0, point.Length)]);
			fireball.speed += _speedBall;
		}
	}
}