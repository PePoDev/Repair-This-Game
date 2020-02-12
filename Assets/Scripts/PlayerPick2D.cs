using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerPick2D : MonoBehaviour
{
	public PlayerMovement2D playerMovement2D;
	public GameObject tooltip;

	public Sprite leg;
	public Sprite head;

	private bool _fullBody = false;

	private Collider2D _collider2D;
	private SpriteRenderer _spriteRenderer;
	private GameObject _door;
	private GameObject _background;
	private BackgroundStage _backgroundStage;
	private Animator _animator;
	private static readonly int Sword = Animator.StringToHash("sword");
	private PlayerAttack2D _playerAttack2D;

	private bool _hasColor = false;
	private bool _hasStick = false;
	private bool _hasGpu = false;

	public Sprite stick;
	public Sprite color;
	public Sprite gpu;

	public GameObject switchFull;
	public GameObject gameUi;
	public GameObject gpuGo;
	private ItemController _itemController;
	private ItemController _itemController1;
	private ItemController _itemController2;
	private ItemController _itemController3;
	private ItemController _itemController4;
	private ItemController _itemController5;

	private void Start()
	{
		_itemController5 = FindObjectOfType<ItemController>();
		_itemController4 = FindObjectOfType<ItemController>();
		_itemController3 = FindObjectOfType<ItemController>();
		_itemController2 = FindObjectOfType<ItemController>();
		_itemController1 = FindObjectOfType<ItemController>();
		_itemController = FindObjectOfType<ItemController>();
		_playerAttack2D = playerMovement2D.GetComponent<PlayerAttack2D>();
		_animator = playerMovement2D.gameObject.GetComponent<Animator>();
		_background = GameObject.Find("Background");
		_backgroundStage = _background.GetComponent<BackgroundStage>();
		_door = GameObject.Find("Door");
		_spriteRenderer = playerMovement2D.gameObject.GetComponent<SpriteRenderer>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("item"))
		{
			tooltip.SetActive(true);
			_collider2D = other;
		}
		else if (other.CompareTag("item-condition"))
		{
			if (other.name.Equals("Box") && _fullBody)
			{
				tooltip.SetActive(true);
				_collider2D = other;
			}

			if (other.name.Equals("slot") && _hasColor)
			{
				tooltip.SetActive(true);
				_collider2D = other;
			}
			
			if (other.name.Equals("switch") && _hasStick)
			{
				tooltip.SetActive(true);
				_collider2D = other;
			}
			
			if (other.name.Equals("last-slot") && _hasGpu)
			{
				tooltip.SetActive(true);
				_collider2D = other;
			}
		}
	}


	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("item") || other.CompareTag("item-condition"))
		{
			tooltip.SetActive(false);
			_collider2D = null;
		}
	}

	private void Update()
	{
		if (Input.GetButtonDown("Fire2") && _collider2D != null)
		{
			if (_collider2D.name.Equals("leg"))
			{
				playerMovement2D.enabled = true;
				_spriteRenderer.sprite = leg;
				Destroy(_collider2D.gameObject);
				SoundManager.Instance.PlayEquired();
			}
			else if (_collider2D.name.Equals("head"))
			{
				_animator.enabled = true;
				_spriteRenderer.sprite = head;
				Destroy(_collider2D.gameObject);
				_fullBody = true;
				SoundManager.Instance.PlayEquired();

			}
			else if (_collider2D.name.Equals("Box"))
			{
				var go = _collider2D;
				go.gameObject.transform.DOMoveX(7.02f, 1f);
				StartCoroutine(routine: Wait());
				SoundManager.Instance.PlayPush();


				IEnumerator Wait()
				{
					yield return new WaitForSeconds(1f);
					Destroy(go.gameObject);
					Destroy(_door);
					_backgroundStage.Next();
					SoundManager.Instance.PlayHit();

				}
			}
			else if (_collider2D.name.Equals("sword"))
			{
				_playerAttack2D.enabled = true;
				_animator.SetBool(Sword, true);
				Destroy(_collider2D.gameObject);
				SoundManager.Instance.PlayEquired();
			}
			else if (_collider2D.name.Equals("color") && _collider2D.tag.Equals("item"))
			{
				_hasColor = true;
				_playerAttack2D.enabled = true;
				_itemController5.ChangeImage(color);
				_animator.SetBool(Sword, true);
				Destroy(_collider2D.gameObject);
			}
			else if (_collider2D.name.Equals("slot"))
			{
				Initiate.Fade("2D-L3-Color", Color.white, 1f);
				_itemController4.UseItem();

			}
			else if (_collider2D.name.Equals("stick"))
			{
				_hasStick = true;
				_itemController3.ChangeImage(stick);
				Destroy(_collider2D.gameObject);
			}
			else if (_collider2D.name.Equals("switch"))
			{
				_itemController.UseItem();
				switchFull.SetActive(true);
				_collider2D.GetComponent<CircleCollider2D>().enabled = false;
				gameUi.GetComponent<RectTransform>().DOAnchorPosY(0f,3f);
				gpuGo.transform.DOMoveY(-0.73f,2f);
			}
			else if (_collider2D.name.Equals("gpu"))
			{
				_hasGpu = true;
				_itemController2.ChangeImage(gpu);
				Destroy(_collider2D.gameObject);
			}
			else if (_collider2D.name.Equals("last-slot") && _hasGpu)
			{
				_itemController1.UseItem();
				Destroy(_collider2D.gameObject);
				Initiate.Fade("3D-L1",Color.white, .5f);
			}
		}
	}
}