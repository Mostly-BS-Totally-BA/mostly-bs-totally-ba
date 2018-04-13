using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl3_Keys : MonoBehaviour
{
    public int has_Keys = 0;                                   //how many keys player current has
    int keys_Gotten;                                           //how many keys player has found total
    public GameObject boss;
    private GUIStyle guiStyle = new GUIStyle();

    bool showGUI = false;                                       //whether or not text appears on screen
    string text;                                               //text that appears when treasure is picked up, set in Unity
    float timer = 5;                                           //timer

    public void PickedUpKey()
    {
        has_Keys++;
        keys_Gotten++;
        if(keys_Gotten == 1)
        {
            text = "The wind blows from the west...";
            showGUI = true;
            StartCoroutine(Wait(timer));
        }
        else if (keys_Gotten == 2)
        {
            text = "The branches bend and creak...";
            showGUI = true;
            StartCoroutine(Wait(timer));
        }
        else if (keys_Gotten == 3)
        {
            text = "The trees sound as if they are trying to speak...";
            showGUI = true;
            StartCoroutine(Wait(timer));
        }
        else if (keys_Gotten == 4)
        {
            text = "The roots grow deep...";
            showGUI = true;
            StartCoroutine(Wait(timer));
        }
        else if (keys_Gotten == 5)
        {
            text = "A monster grows from the earth...";
            showGUI = true;
            StartCoroutine(Wait(timer));
            boss.SetActive(true);
        }
    }

    public void UsedKey()
    {
        has_Keys--;
    }

    //Function to display text
    private void OnGUI()
    {
        if (showGUI == true)
        {
            guiStyle.fontSize = 20;                                            //change the font size
            guiStyle.normal.textColor = Color.red;
            GUI.Label(new Rect(10, 10, 500, 20), text, guiStyle);             //places text on screen      
        }
    }

    //Coroutine that causes script to wait before resuming 
    IEnumerator Wait(float timer)
    {
        yield return new WaitForSecondsRealtime(timer);        //Waits for seconds indicated by timer
        showGUI = false;                                     //removes text from screen
    }
}
