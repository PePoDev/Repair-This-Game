using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Menu : MonoBehaviour
{

    public GameObject player;
    public GameObject ui;
    
    public void NewGame()
    {
        player.SetActive(true);
        ui.SetActive(false);
    }
}
