﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script allows player to open double doors on level two and future levels
public class Double_Door_Interact : MonoBehaviour
{                                                                  //Public variables set in Unity
    public GameObject opened_door1;                                //game objects are the open door sprites to replace object this is attached to
    public GameObject opened_door2;
    public GameObject other_door;                                  //closed door that is paired with this door
    
    public GameObject [] overlay;                                  //array of overlays that cover the room this door reveals
    int number_of_Overlays;                                        //number of overlays

    //Called via Player_Interact script when player presses 'e' on closed door
    public void RunInteraction()
    {
        number_of_Overlays = overlay.GetLength(0);

        for (int i = 0; i < number_of_Overlays; i++)                //loop deactivates overlays that black our rooms beyond it
            overlay[i].SetActive(false);

        gameObject.SetActive(false);                                //deactivates door/paired door this is attached to
        other_door.SetActive(false);

        opened_door1.SetActive(true);                              //activates the open door sprites
        opened_door2.SetActive(true);
        AudioManager.Instance.PlayAudio(AudioName.Door);
        Destroy(gameObject.GetComponent("Interact_Text"));         //destroys Interact_Text component on open door, so text no longer appears on screen
    }
}
