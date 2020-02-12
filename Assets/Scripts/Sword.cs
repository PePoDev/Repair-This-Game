using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
	public PlayerAttack player;

	private void OnTriggerStay(Collider other)
	{
		if (other.transform.tag.Equals("fire") && player.isAttacking)
		{
			other.gameObject.GetComponent<FireBall>().Hit();
			player.isAttacking = false;
		}

		if (other.transform.tag.Equals("bat") && player.isAttacking)
		{
			other.gameObject.GetComponent<Bat>().Hit();
			player.isAttacking = false;
		}
	}
}