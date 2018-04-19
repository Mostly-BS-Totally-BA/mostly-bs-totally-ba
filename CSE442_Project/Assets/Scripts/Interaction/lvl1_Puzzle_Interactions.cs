using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script that allows player to complete lvl 1 puzzle by pulling wall sconces (torches) in the right order and amount (pull torch 3 once, torch 4 twice, torch 2 three times, torch 1 once) (torches are number from left to right as the appear in game)
public class lvl1_Puzzle_Interactions : MonoBehaviour
{
    private GUIStyle guiStyle = new GUIStyle();

    int torch1_pulls = 0;                                         //variables for number of times each torch has been pulled
    int torch2_pulls = 0;
    int torch3_pulls = 0;
    int torch4_pulls = 0;
        
    public GameObject[] walls;                                    //array of walls blocking treasure room, set in Unity
    public GameObject[] overlays;                                 //array of black overlays covering treasure room, set in Unity
    public GameObject[] torches;                                  //array of game objects for the torches that are interacted with

    GameObject torch = null;                                      //torch currently being interacted with
    string text;                                                  //string of text to display on screen
    bool showGUI;                                                 //whether text is on screen or not
    bool solved = false;                                          //if the puzzle is solved or not

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Puzzle_Interact"))              //if collider is on a wall sconce
        {
            torch = collision.gameObject;                         //set torch to the torch being interacted with
            text = "Press 'e' to pull";                           //set text to display
            showGUI = true;                                       //display text on screen
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        showGUI = false;                                          //remove text from screen
        torch = null;                                             //set torch being interacted with to null
        if (solved == true)                                       //if puzzle is solved
        {
            for (int i = 0; i < torches.GetLength(0); i++)        //remove interactable torches, leaving non interactable copies behind
            {
                Destroy(torches[i]);
            }
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interaction"))    //if the player presses the interaction key ('e')
        {
            //AudioManager.Instance.PlayAudio(AudioName.Plate);

            if (torch.name == "Torch_3" && torch3_pulls != 1 && (torch2_pulls == 0 && torch1_pulls == 0 && torch4_pulls == 0))              //if interacting with torch3 and no torches have been pulled
            {
                AudioManager.Instance.PlayAudio(AudioName.Plate);
                torch3_pulls++;
                text = "The sconce clicks into position...";
                showGUI = true;
            }

            else if (torch.name == "Torch_4" && torch4_pulls != 2 && (torch3_pulls == 1 && torch1_pulls == 0 && torch2_pulls == 0))         //if interacting with torch4 and torch4 hasn't been pulled twice, torch3 has been pulled once, and the other two haven't been pulled at all
            {
                AudioManager.Instance.PlayAudio(AudioName.Plate);
                torch4_pulls++;
                if (torch4_pulls == 1)
                {

                    text = "The sconce clicks into position...";
                    showGUI = true;
                }
                else if (torch4_pulls == 2)
                {
                    text = "The sconce clicks further...";
                    showGUI = true;
                }
            }

            else if (torch.name == "Torch_2" && torch2_pulls != 3 && (torch3_pulls == 1 && torch1_pulls == 0 && torch4_pulls == 2))         //if interacting with 2 and 2 hasn't been pulled three times and 3 has been pulled once, 4 pulled twice and 1 hasnce been pulled at all
            {
                AudioManager.Instance.PlayAudio(AudioName.Plate);
                torch2_pulls++;
                if (torch2_pulls == 1)
                {
                    text = "The sconce clicks into position...";
                    showGUI = true;
                }
                else if (torch2_pulls == 2)
                {
                    text = "The sconce clicks further...";
                    showGUI = true;
                }
                else if (torch2_pulls == 3)
                {
                    text = "The sconce clicks even further...";
                    showGUI = true;
                }
            }

            else if (torch.name == "Torch_1" && torch1_pulls != 1 && (torch2_pulls == 3 && torch3_pulls == 1 && torch4_pulls == 2))     //if interacting with torch1 and all other torches have been pulled the correct amount
            {
                AudioManager.Instance.PlayAudio(AudioName.Plate);
                torch1_pulls++;
                text = "The sconce clicks into position...";
                showGUI = true;
            }

            else                                                                                                                        //any incorrect pull of a torch
            {
                AudioManager.Instance.PlayAudio(AudioName.Plate);
                torch1_pulls = 0;           //puzzle resets
                torch2_pulls = 0;
                torch3_pulls = 0;
                torch4_pulls = 0;

                text = "The sconces snap back into place. It reset!";
                showGUI = true;
            }

            if (torch1_pulls == 1 && torch2_pulls == 3 && torch3_pulls == 1 && torch4_pulls == 2)           //if puzzle has been solved
            {
                for (int i = 0; i < walls.GetLength(0); i++)                               //loops remove walls and overlays to reveal treasure room
                {
                    walls[i].SetActive(false);
                }
                for (int i = 0; i < overlays.GetLength(0); i++)
                {
                    overlays[i].SetActive(false);
                }
                solved = true;                                                              //set solved to true
            }
        }
    }

    //Controls displaying text on screen
    private void OnGUI()
    {
        if (showGUI == true)
        {
            guiStyle.fontSize = 20;                                            //change the font size
            guiStyle.normal.textColor = Color.white;
            GUI.Label(new Rect(10, 10, 500, 20), text, guiStyle);             //places text on screen
        }
    }
}
