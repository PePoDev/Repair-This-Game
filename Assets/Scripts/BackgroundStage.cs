using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackgroundStage : MonoBehaviour
{
    public Sprite[] backgrounds;
    public UnityEvent[] events;

    private int _idx = 0;
    
    public void Next()
    {
        GetComponent<SpriteRenderer>().sprite = backgrounds[_idx];
        events[_idx++].Invoke();
    }
}
