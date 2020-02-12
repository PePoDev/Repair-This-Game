using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Sword2D : MonoBehaviour
{
    public PlayerAttack2D player;

    public GameObject colorItem;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag.Equals("bat") && player.isAttacking)
        {
            other.gameObject.GetComponent<Bat2D>().Hit();
            player.isAttacking = false;
        }
        
        if (other.transform.tag.Equals("Finish") && player.isAttacking)
        {
            colorItem.SetActive(true);
            colorItem.transform.DOMoveY(-1.23f, 2f);
            player.isAttacking = false;
        }
    }
}
