using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FireBall : MonoBehaviour
{
	public float speed;
	public float time;

	public GameObject vfx;
	private static readonly int Dizzy = Animator.StringToHash("dizzy");

	private void Awake()
	{
		transform.LookAt(FindObjectOfType<PlayerMovement>().gameObject.transform);
		StartCoroutine(Delay());
	}

	private IEnumerator Delay()
	{
		yield return new WaitForSeconds(time);
		Destroy(gameObject);
	}

	private void Update()
	{
		transform.position += transform.forward * (Time.deltaTime * speed);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals("Player"))
		{
			var hpController = FindObjectOfType<HpController>();
			hpController.TakeDamage();
			if (hpController.IsGameOver())
			{
				other.gameObject.GetComponent<PlayerMovement>().GameOver();
			}

			SoundManager.Instance.PlayExplosion();
			Instantiate(vfx, other.transform);

			Destroy(gameObject);
		}

		if (other.gameObject.tag.Equals("enemy"))
		{
			var boss = other.GetComponent<Boss>();
			boss.bossHp--;
			
			other.transform.parent.GetComponent<Animator>().SetTrigger(Dizzy);
			
			Lebug.Log("Hp", boss.bossHp, "Boss Hp");
			if (boss.bossHp == 0)
			{
				GameObject.Find("Player").GetComponent<PlayerMovement>().Win();
			}
			
			SoundManager.Instance.PlayExplosion();
			Instantiate(vfx, other.transform.position, Quaternion.identity, other.transform);

			Destroy(gameObject);
		}
	}

	public void Hit()
	{
		SoundManager.Instance.PlayHit();
		speed *= 3;
		transform.LookAt(GameObject.Find("BossTarget").transform);
	}
}