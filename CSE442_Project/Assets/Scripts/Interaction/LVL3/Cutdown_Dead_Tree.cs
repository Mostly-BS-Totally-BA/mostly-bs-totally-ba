using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutdown_Dead_Tree : MonoBehaviour
{
    public bool has_axe = false;
    string text;
    private GUIStyle guiStyle = new GUIStyle();
    bool showGUI = false;
    float timer = 5;                                           //timer


    public GameObject key;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(has_axe)
        {
            text = "Press 'e' to chop down...";
            showGUI = true;
        }
        else
        {
            text = "You need an axe...";
            showGUI = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        showGUI = false;
    }

    void RunInteraction()
    {
        if(has_axe)
        {
            key.SetActive(true);
            Destroy(gameObject);
        }
    }

    public void PickedUpAxe()
    {
        has_axe = true;
        text = "You picked up the Woodsman's Axe!";
        showGUI = true;
        StartCoroutine(Wait(timer));
    }

    //Checks if showGUI is true
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
        showGUI = false;                                     //removes text from screen
    }
}
