using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SoundManager: MonoBehaviour
{
    public AudioClip slash;
    public AudioClip explosion;
    public AudioClip itemPickup;
    public AudioClip itemUse;
    public AudioClip trap;
    public AudioClip gameOver;
    public AudioClip equired;
    public AudioClip push;
    public AudioClip hit;
    public AudioClip fireSpawn;
    public AudioClip fade;
    public AudioClip restart;
    public AudioClip takeDamage;
    
    public static SoundManager Instance;

    private void Start()
    {
        Instance = this;
    }

    public void PlaySlash()
    {
        AudioSource.PlayClipAtPoint(slash, Camera.main.transform.position);
    }
    
    public void PlayExplosion()
    {
        AudioSource.PlayClipAtPoint(explosion, Camera.main.transform.position);
    }
    
    public void PlayItemPickup()
    {
        AudioSource.PlayClipAtPoint(itemPickup, Camera.main.transform.position);
    }
    
    public void PlayItemUse()
    {
        AudioSource.PlayClipAtPoint(itemUse, Camera.main.transform.position);
    }
    
    public void PlayTrap()
    {
        AudioSource.PlayClipAtPoint(trap, Camera.main.transform.position);
    }

    public void PlayGameOver()
    {
        AudioSource.PlayClipAtPoint(gameOver, Camera.main.transform.position);
    }

    public void PlayEquired()
    {
        AudioSource.PlayClipAtPoint(equired, Camera.main.transform.position);
    }

    public void PlayPush()
    {
        AudioSource.PlayClipAtPoint(push, Camera.main.transform.position);;
    }

    public void PlayHit()
    {
        AudioSource.PlayClipAtPoint(hit, Camera.main.transform.position);
    }

    public void PlayFireSpawn()
    {
        AudioSource.PlayClipAtPoint(fireSpawn, Camera.main.transform.position);
    }

    public void PlayFade()
    {
        AudioSource.PlayClipAtPoint(fade, Camera.main.transform.position);
    }

    public void PlayRestart()
    {
        AudioSource.PlayClipAtPoint(restart, Camera.main.transform.position);
    }

    public void PlayTakeDamage()
    {
        AudioSource.PlayClipAtPoint(takeDamage, Camera.main.transform.position);
    }
}
