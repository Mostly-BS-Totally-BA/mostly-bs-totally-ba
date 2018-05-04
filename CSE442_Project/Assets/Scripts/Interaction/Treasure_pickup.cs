using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script allows player to pickup treasure by running over it
public class Treasure_pickup : MonoBehaviour
{
    public string text;                                         //text that appears when treasure is picked up, set in Unity
    float timer = .35F;                                         //timer (seconds) that text appears for

    public int score_increase;                                  //score increase variable
    GameManager _gm = null;                                     //variable to access game manager
     

    //called by Player_Interact script when player enters collider of object tagged as Treasure_Inter
    public void RunInteraction()
    {
        AudioManager.Instance.PlayAudio(AudioName.Treasure);
        textManager.Instance.enableText(text);
        StartCoroutine(Wait(timer));                            //calls timer function
    }

    //Coroutine that causes script to wait before resuming 
    IEnumerator Wait(float timer)
    {
        yield return new WaitForSecondsRealtime(timer);        //Waits for seconds indicated by timer
        _gm = GameManager.Instance;                            //access game manager   
        _gm.UpdateScore(score_increase);                       //update score
        textManager.Instance.disableText(text);
        Destroy(gameObject);                                   //removes treasure object from the map
    }
}
