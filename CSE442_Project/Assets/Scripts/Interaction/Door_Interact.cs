using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for interacting with closed doors (used for single doors on level 1)
public class Door_Interact : MonoBehaviour
{                                                               //public variables set in Unity
    public GameObject opened_door;                              //game object is the open door sprite to replace object this is attached to
    public GameObject[] overlay;                                //array of overlays that cover the room this door reveals
    int number_of_Overlays;                                     //number of overlays


    //Called via Player_Interact script when player presses 'e' on closed door
    public void RunInteraction()
    {
        number_of_Overlays = overlay.GetLength(0);

        for (int i = 0; i < number_of_Overlays; i++)            //loop deactivates overlays that black our rooms beyond it
            overlay[i].SetActive(false);

        gameObject.SetActive(false);                            //deactivates door this is attached to
        opened_door.SetActive(true);                            //activates the open door sprite
        AudioManager.Instance.PlayAudio(AudioName.Door);
        Destroy(gameObject.GetComponent("Interact_Text"));      //destroys Interact_Text component on open door, so text no longer appears on screen

    }
}
 