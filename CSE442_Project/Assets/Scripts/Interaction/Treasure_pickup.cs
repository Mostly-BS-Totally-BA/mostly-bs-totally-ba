using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script allows player to pickup treasure by running over it
public class Treasure_pickup : MonoBehaviour
{
    bool showGUI = false;                                       //whether or not text appears on screen
    public string text;                                         //text that appears when treasure is picked up, set in Unity
    float timer = .35F;                                         //timer (seconds) that text appears for
    private GUIStyle guiStyle = new GUIStyle();                 //adjusts font size

    public int score_increase;                                  //score increase variable
    GameManager _gm = null;                                     //variable to access game manager
     

    //called by Player_Interact script when player enters collider of object tagged as Treasure_Inter
    public void RunInteraction()
    {
        showGUI = true;                                         //display text on screen
        StartCoroutine(Wait(timer));                            //calls timer function
    }

    //Function to display text
    private void OnGUI()
    {
        if (showGUI == true)
        {
            guiStyle.fontSize = 20;                                            //change the font size
            guiStyle.normal.textColor = Color.white;
            GUI.Label(new Rect(10, 10, 500, 20), text, guiStyle);             //places text on screen
        }
    }

    //Coroutine that causes script to wait before resuming 
    IEnumerator Wait(float timer)
    {
        yield return new WaitForSecondsRealtime(timer);        //Waits for seconds indicated by timer
        _gm = GameManager.Instance;                            //access game manager   
        _gm.UpdateScore(score_increase);                       //update score
        Destroy(gameObject);                                   //removes treasure object from the map
    }
}
