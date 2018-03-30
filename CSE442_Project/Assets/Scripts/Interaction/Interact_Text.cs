using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script pushes text to screen when player is within the collider of the object this is a component of
public class Interact_Text : MonoBehaviour
{
    bool showGUI = false;                           //variable that determines if text is on screen
    public string text;                             //text that is displayed, can be set in Unity
    public Player_Interact player;                  //Links script to the player sprite, can be set in Unity
    private GUIStyle guiStyle = new GUIStyle();

    //activates when something enters the object's trigger collider
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))                     //if the object that enters the collider is the player, displays text on screen
            showGUI = true;
        if(gameObject.CompareTag("Door_Inter_Locked"))          //if the object this is attached to is the locked door to level2
        {
            if (player.has_lvl1_Key == false)    //and if the player does not have the key to proceed, alters text that is displayed
            {
                text = "You need a key...";
                showGUI = true;
            }
            else                                                //if the player has the key, alters text that is displayed
            {
                text = "Press 'e' to unlock";
                showGUI = true;
            }
        }
    }

    //Activates when something exits the trigger collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))                         //if the exiting object was the player, removes the text from screen
            showGUI = false;

        if (gameObject.CompareTag("Chest_Open"))                    //if the object that this is attached to is an open chest, removes trigger collider
            Destroy(gameObject.GetComponent("BoxCollider2D"));      //so text no longer appears when you approach
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
}