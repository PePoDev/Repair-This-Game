using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack2D : MonoBehaviour
{
    public bool isAttacking = false;
    
    private Animator _animator;

    private static readonly int Slash = Animator.StringToHash("attack");
    private static readonly int Sword = Animator.StringToHash("sword");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool(Sword, true);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            SoundManager.Instance.PlaySlash();
            isAttacking = true;
            StartCoroutine(WaitAttack());
            _animator.SetTrigger(Slash);
        }
    }
    
    private IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(.6f);
        isAttacking = false;
    }
}
