using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class BossStory : MonoBehaviour
{
	public GameObject gameOverUi;
	public GameObject winUi;
	public TextMeshProUGUI textbox;

	public Animator boss;
	public Boss bossScript;

	private static readonly int Dead = Animator.StringToHash("die");

	private bool _canNext = false;

	private IEnumerator Start()
	{
		yield return new WaitForSeconds(2f);
		textbox.text = "ภารกิจกำจัดบอส !!";
		winUi.SetActive(true);
		StartCoroutine(delayClick(2f));
		yield return new WaitUntil(() => Input.anyKeyDown && _canNext);
		bossScript.enabled = true;
		winUi.SetActive(false);
		textbox.text = "สำเร็จ คุณกำจัดบอสได้แล้ว !!";
	}

	private IEnumerator delayClick(float delay)
	{
		_canNext = false;
		yield return new WaitForSeconds(delay);
		_canNext = true;
	}

	public IEnumerator FirstWin()
	{
		boss.SetTrigger(Dead);
		yield return new WaitForSeconds(3f);
		winUi.SetActive(true);
		bossScript.enabled = false;

		StartCoroutine(delayClick(1f));
		yield return new WaitUntil(() => Input.anyKeyDown && _canNext);
		textbox.text = "เดี๋ยวก่อน !, บอสยังขยับได้อยู่ !";

		StartCoroutine(delayClick(1f));
		yield return new WaitUntil(() => Input.anyKeyDown && _canNext);
		textbox.text = "มันกำลังใช้พลังขั้นสุดท้ายทำลายทุกอย่าง ! หนีเร็ว !";

		StartCoroutine(delayClick(1f));
		yield return new WaitUntil(() => Input.anyKeyDown && _canNext);
		textbox.text = "ไม่นะ ไม่ทันแล้วววว, อ๊ากกกกก ก.ไก่ล้านตัว";

		yield return new WaitForSeconds(1f);
		StartCoroutine(delayClick(1f));
		yield return new WaitUntil(() => Input.anyKeyDown && _canNext);
		Initiate.Fade("2D-L5", Color.black, 2f);
		gameOverUi.SetActive(false);
	}

	public IEnumerator Win()
	{
		boss.SetTrigger(Dead);
		yield return new WaitForSeconds(1f);
		winUi.SetActive(true);
		bossScript.enabled = false;

		StartCoroutine(delayClick(1f));
		yield return new WaitUntil(() => Input.anyKeyDown && _canNext);
		textbox.text = "ดูเหมือนบอสจะยังขยับได้อยู่ คุณจะทำยังไงดี\nA.อัดซ้ำให้ตายสนิท B.ปล่อยไป มันคงสำนึกผิดแล้ว";

		yield return new WaitForSeconds(2f);
		
		while (true)
		{
			if (Input.GetButtonDown("Fire2"))
			{
				StartCoroutine(delayClick(1f));
				yield return new WaitUntil(() => Input.anyKeyDown && _canNext);
				textbox.text = "บอสซึ้งใจในตัวเรา จึงจากไปแล้วอยู่อย่างสงบ";

				StartCoroutine(delayClick(1f));
				yield return new WaitUntil(() => Input.anyKeyDown && _canNext);
				textbox.text = "... แฮปปี้ แอนดิ้ง ...";

				yield return new WaitForSeconds(1f);
				StartCoroutine(delayClick(1f));
				yield return new WaitUntil(() => Input.anyKeyDown && _canNext);
				Initiate.Fade("end", Color.white, 2f);
				gameOverUi.SetActive(false);
				yield break;
			}
			else if (Input.GetButtonDown("Fire1"))
			{
				StartCoroutine(delayClick(1f));
				yield return new WaitUntil(() => Input.anyKeyDown && _canNext);
				textbox.text = "ระหว่างที่เรากำลังคุยกัน บอสได้ใช้พลังขั้นสุดท้ายทำลายทุกอย่างแล้ว ! หนีเร็ว !";

				StartCoroutine(delayClick(1f));
				yield return new WaitUntil(() => Input.anyKeyDown && _canNext);
				textbox.text = "ไม่นะ ไม่ทันแล้ว, อ๊ากกกกก ก.ไก่ล้านตัว";

				yield return new WaitForSeconds(1f);
				StartCoroutine(delayClick(1f));
				yield return new WaitUntil(() => Input.anyKeyDown && _canNext);
				Initiate.Fade("2D-L5", Color.black, 2f);
				gameOverUi.SetActive(false);

				yield break;
			}

			yield return null;
		}
	}
}