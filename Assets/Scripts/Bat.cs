using System;
using UnityEngine;


public class Bat : MonoBehaviour
{
	private float speed = 2f;
	public int hp = 3;

	private GameObject _player;
	private Rigidbody _rigidbody;
	private HpController _hpController;

	private void Start()
	{
		_hpController = FindObjectOfType<HpController>();
		_player = GameObject.Find("Player");
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		Transform transform1;
		(transform1 = transform).LookAt(_player.transform);
		
		var dis = Vector3.Distance(transform.position, _player.transform.position);
		if (dis < 1.5f)
		{
			transform1.position -= transform1.forward * 5;
			_hpController.TakeDamage();
			return;
		}

		transform1.position += transform1.forward * (Time.deltaTime * speed);
	}

	public void Hit()
	{
		hp--;
		if (hp == 0)
		{
			Destroy(gameObject);
		}
		
		SoundManager.Instance.PlayHit();

		var transform1 = transform;
		transform1.position -= transform1.forward * 5;
	}
}