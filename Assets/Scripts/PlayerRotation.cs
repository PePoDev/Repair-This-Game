using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerRotation : MonoBehaviour
{
	public float turnSpeed;
	
	private CharacterController _characterController;

	private void Start()
	{
		_characterController = GetComponent<CharacterController>();
	}

	private void Update()
	{
		var vertical = Input.GetAxis("RotateY");
		var horizontal = Input.GetAxis("RotateX");

		if (Math.Abs(vertical) < .1f && Math.Abs(horizontal) < .1f)
		{
			return;
		}
		
		var angle = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg;

		Lebug.Log("rotate y", vertical, "Player Rotation");
		Lebug.Log("rotate x", horizontal, "Player Rotation");
		Lebug.Log("rotate angle", angle, "Player Rotation");

		transform.rotation =  Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle + 90f, Vector3.up), turnSpeed);
	}
}