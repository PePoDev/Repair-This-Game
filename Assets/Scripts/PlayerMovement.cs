using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
	[Header("Player Movement Attributes")] public float movementSpeed;

	private CharacterController _characterController;
	private Animator _animator;

	public GameObject dieVfx;

	private static readonly int Speed = Animator.StringToHash("speed");

	private void Start()
	{
		_characterController = GetComponent<CharacterController>();
		_animator = GetComponent<Animator>();
		
	}

	private void Update()
	{
		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");
		_animator.SetFloat(Speed, Mathf.Abs(vertical) + Mathf.Abs(horizontal));

		Lebug.Log("vertical speed", vertical, "Player Movement");
		Lebug.Log("horizontal speed", horizontal, "Player Movement");

		_characterController.Move(new Vector3(vertical * -1, 0, horizontal) * (movementSpeed * Time.deltaTime));
	}

	public void Restart()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		gameOverUi.SetActive(false);
	}

	public GameObject gameOverUi;

	public void GameOver()
	{
		Time.timeScale = 0f;
		gameOverUi.SetActive(true);
	}

	public GameObject winUi;

	public void Win()
	{
		dieVfx.SetActive(true);
		StartCoroutine(!PlayerPrefs.HasKey("win")
			? GameObject.Find("Story").GetComponent<BossStory>().FirstWin()
			: GameObject.Find("Story").GetComponent<BossStory>().Win());
		PlayerPrefs.SetString("win","some value");
	}
}