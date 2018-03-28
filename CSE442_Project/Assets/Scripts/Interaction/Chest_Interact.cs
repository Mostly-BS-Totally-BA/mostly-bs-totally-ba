using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for player to interact with chests
public class Chest_Interact : MonoBehaviour
{
    public GameObject opened_chest;             //game object of open chest sprite, set in Unity

    //called by Player_Interact script
    public void RunInteraction()
    {
        gameObject.SetActive(false);            //deactivates object this script is attached to
        opened_chest.SetActive(true);           //activates opened chest object
    }
}
