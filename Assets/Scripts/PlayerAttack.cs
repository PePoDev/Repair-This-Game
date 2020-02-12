using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Animator))]
public class PlayerAttack : MonoBehaviour
{
    public bool isAttacking = false;
    
    private Animator _animator;

    private static readonly int Slash = Animator.StringToHash("slash");
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
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
