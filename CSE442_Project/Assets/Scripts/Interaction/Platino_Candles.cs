using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script handles the activation of the three white candles on map, and opening of secret room when all active
public class Platino_Candles : MonoBehaviour
{
    public GameObject[] walls;                                              //array of game objects for walls to secret room, set in Unity
    public GameObject[] overlays;                                           //array of game objects for black overlays blocking secret room,set in Unity
    GameObject candle = null;                                               //game object for what candle is being interacted with

    string text;

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
            textManager.Instance.disableText(text);
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

            if (number_pulled == 1)
            {
                text = "A tumbler turns...";
            }
            else if (number_pulled == 2)
            {
                text = "Stone grates on stone...";
            }
            else if (number_pulled == 3)
            {
                text = "A passage opens...";
            }
            textManager.Instance.enableText(text);
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
}
