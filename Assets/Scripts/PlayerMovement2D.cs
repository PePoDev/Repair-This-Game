using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement2D : MonoBehaviour
{
	public float speed = 5f;
	private static readonly int Speed = Animator.StringToHash("speed");
	private Animator _animator;

	private void Start()
	{
		_animator = GetComponent<Animator>();
	}

	private void Update()
	{
		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");

		_animator.SetFloat(Speed, Mathf.Abs(vertical) + Mathf.Abs(horizontal));

		if (Mathf.Abs(horizontal) > 0)
		{
			transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * (horizontal > 0 ? -1 : 1),
				transform.localScale.y,
				transform.localScale.z);
		}

		transform.Translate(new Vector3(horizontal, vertical) * (speed * Time.deltaTime));


		if (Input.GetButtonDown("Menu"))
		{
			Initiate.Fade(SceneManager.GetActiveScene().name,Color.black, 2f);
		}
	}
}