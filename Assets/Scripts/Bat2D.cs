using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Bat2D : MonoBehaviour
{
	public float speed = 4;
	public float distance = 4;
	public int hp = 3;
	
	private GameObject _player;
	
	private void Start()
	{
		_player = GameObject.Find("Player");
	}

	private void Update()
	{
		var dis = Vector2.Distance(transform.position, _player.transform.position);
		if (dis < distance)
		{
			return;
		}
		
		transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, speed * Time.deltaTime);
	}
	
	public void Hit()
	{
		hp--;
		if (hp == 0)
		{
			Destroy(gameObject);
		}

		transform.position -= transform.forward * 5;
	}
}