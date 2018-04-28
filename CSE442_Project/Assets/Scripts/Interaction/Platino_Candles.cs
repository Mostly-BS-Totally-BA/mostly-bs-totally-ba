using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script handles the activation of the three white candles on map, and opening of secret room when all active
public class Platino_Candles : MonoBehaviour
{
    public GameObject[] walls;                                              //array of game objects for walls to secret room, set in Unity
    public GameObject[] overlays;                                           //array of game objects for black overlays blocking secret room,set in Unity
    GameObject candle = null;                                               //game object for what candle is being interacted with

    bool showGUI = false;                                                   //controls whether text appears on screen
    private GUIStyle guiStyle = new GUIStyle();

    int number_pulled = 0;
    int previous_pulled = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platino_Candle"))                         //object that contains collider if a candle
        {
            candle = collision.gameObject;                                  //sets candle to that object
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Platino_Candle_NonInter") && previous_pulled < number_pulled)     //if player exits nonInteractable candle (replaces interactable one when it is destroyed below)
        {
            showGUI = false;                                                                        //Removes text from screen
            previous_pulled = number_pulled;                                                        //sets previous_pulled to number_pulled
            Destroy(collision.GetComponent<CircleCollider2D>());                                    //destroys trigger collider on candle so text doesn't appear anymore
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interaction") && candle)               //if player presses interaction key ('e') and they are in the trigger collider of a candle
        {
            AudioManager.Instance.PlayAudio(AudioName.Candles);
            previous_pulled = number_pulled;                            //saves number pulled
            number_pulled++;                                            //increments number of candles pulled
            showGUI = true;                                             //activates on screen text
            Destroy(candle);                                            //removes candle from screen to prevent pulling the same one multiple times
        }

        if(number_pulled == 3)                                          //if all three have been pulled, removes walls and black overlays blocking secret room
        {
            AudioManager.Instance.PlayAudio(AudioName.Candles);


            for (int i = 0; i < walls.GetLength(0); i++)
                walls[i].SetActive(false);
            for (int i = 0; i < overlays.GetLength(0); i++)
                overlays[i].SetActive(false);
        }
    }

    //Function to display text on screen
    private void OnGUI()
    {
        if (showGUI == true && number_pulled == 1)                                  //If statements print different message to screen based on the number
        {                                                                           //of candles pulled thus far
            guiStyle.fontSize = 20;                                                //change the font size
            guiStyle.normal.textColor = Color.white;
            GUI.Label(new Rect(10, 10, 300, 20), "A tumbler turns...", guiStyle);
        }
        else if (showGUI == true && number_pulled == 2)
        {
            guiStyle.fontSize = 20;                                               //change the font size
            guiStyle.normal.textColor = Color.white;
            GUI.Label(new Rect(10, 10, 300, 20), "Stone grates on stone...", guiStyle);
        }
        else if (showGUI == true && number_pulled == 3)
        {
            guiStyle.fontSize = 20;                                              //change the font size
            guiStyle.normal.textColor = Color.white;
            GUI.Label(new Rect(10, 10, 300, 20), "A passage opens...", guiStyle);
        }
    }
}
