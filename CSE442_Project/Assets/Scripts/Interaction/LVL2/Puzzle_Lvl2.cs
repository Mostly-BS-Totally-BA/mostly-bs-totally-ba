using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script that allows the player to complete lvl2 puzzle by stepping on pressure plates in the right order (yellow, blue, red)
public class Puzzle_Lvl2 : MonoBehaviour
{
    bool pressed_yellow = false;                    //variables for if the pressure plate has been activated yet
    bool pressed_blue = false;
    bool pressed_red = false;

    public GameObject[] walls;                      //array of walls blocking treasure room, set in Unity
    public GameObject[] overlays;                   //array of black overlays covering treasure room, set in Unity
    public GameObject[] plates;                     //array of game objects for the different pressure plates, set in Unity

    GameObject square = null;                       //plate currently being interacted with
    private GUIStyle guiStyle = new GUIStyle();

    string text;                                    //string of text to display on screen
    bool showGUI;                                   //whether text is on screen or not

    //Activates when player enter trigger collider of one of the plates
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Puzzle_Interact"))                                                    //if the collider was on a puzzle pressure plate
        {
            square = collision.gameObject;                                                              //sets square to pressure plate object being collided with
            AudioManager.Instance.PlayAudio(AudioName.Plate);
            if (square.name == "Floor_yellow" && pressed_yellow == false)                               //if it is the yellow plate and the yellow plate hasn't been pressed
            {
                pressed_yellow = true;  
                text = "The plate clicks...";                                                           //sets text for display
                showGUI = true;                                                                         //displays text on screen
            }
            else if (square.name == "Floor_blue" && pressed_blue == false && pressed_yellow == true)    //if it is the blue plate and the blue plate hasn't been pressed and yellow has
            {
                pressed_blue = true;
                text = "The walls shake...";
                showGUI = true;
            }
            else if (square.name == "Floor_red" && pressed_red == false && pressed_yellow == true && pressed_blue == true)  //if it is the red plate and red hasn't been pressed and blue and yellow have
            {
                pressed_red = true;
                text = "The walls open!";
                showGUI = true;
            }
            else                             //plates not pressed in right order, resets all values
            {
                pressed_blue = false;
                pressed_yellow = false;
                pressed_red = false;
                text = "It resets!";
                showGUI = true;
            }

            if (pressed_blue == true && pressed_red == true && pressed_yellow == true)  //if the puzzle has been solved by all plates baving been pressed
            {
                for (int i = 0; i < walls.GetLength(0); i++)                            //loops reveal treasure rooms by deactivating walls and overlays in array
                {
                    walls[i].SetActive(false);
                }
                for (int i = 0; i < overlays.GetLength(0); i++)
                {
                    overlays[i].SetActive(false);
                }
            }
        }
    }

    //Activates when player leaves the collider of a pressure plate
    private void OnTriggerExit2D(Collider2D collision)
    {
        showGUI = false;                                                                //remove text from screen
        if (pressed_blue == true && pressed_red == true && pressed_yellow == true)      //if the puzzle is solved
        {
            for (int i = 0; i < plates.GetLength(0); i++)                               //removes trigger collider on plates so they can no longer be interacted with
            {
                Destroy(plates[i].GetComponent<BoxCollider2D>());
            }
        }
    }

    //Controls displaying text on screen
    private void OnGUI()
    {
        if (showGUI == true)
        {
            guiStyle.fontSize = 20;                                              //change the font size
            guiStyle.normal.textColor = Color.white;
            GUI.Label(new Rect(10, 10, 500, 20), text, guiStyle);
        }
    }
}
