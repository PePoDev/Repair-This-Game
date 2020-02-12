using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public Image item;
    public Sprite defaultItem;
    
    public void ChangeImage(Sprite newItem)
    {
        SoundManager.Instance.PlayItemPickup();
        item.overrideSprite = newItem;
    }

    public void UseItem()
    {
        SoundManager.Instance.PlayItemUse();
        item.overrideSprite = defaultItem;
    }
}
