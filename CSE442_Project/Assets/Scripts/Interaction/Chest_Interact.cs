using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for player to interact with chests
public class Chest_Interact : MonoBehaviour
{
    public GameObject opened_chest;             //game object of open chest sprite, set in Unity
    public int score_increase;
    GameManager _gm = null;

    //called by Player_Interact script
    public void RunInteraction()
    {
        AudioManager.Instance.PlayAudio(AudioName.Chest);
        gameObject.SetActive(false);            //deactivates object this script is attached to
        opened_chest.SetActive(true);           //activates opened chest object

        _gm = GameManager.Instance;             //access game manager   
        _gm.UpdateScore(score_increase);        //update score
    }
}
