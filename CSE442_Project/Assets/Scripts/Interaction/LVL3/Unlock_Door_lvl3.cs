using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock_Door_lvl3 : MonoBehaviour
{
    public GameObject unlocked_door;                //variable for sprite of unlocked door, set in Unity
    public Lvl3_Keys keys;                          //links to lvl2 keys to access values and functions

    public string text;                             //text that is displayed, can be set in Unity


    //Called via Player_Interact script when player presses 'e' on locked door
    public void RunInteraction()
    {
        if (keys.has_Keys > 0)                   //If player has a key to unlock the door, sets locked door to inactive and activates unlocked_door
        {
            gameObject.SetActive(false);
            unlocked_door.SetActive(true);
            keys.UsedKey();
        }
    }

    //activates when something enters the object's trigger collider
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))          //if the object this is attached to is the locked door to level2
        {
            if (keys.has_Keys == 0)    //and if the player does not have the key to proceed, alters text that is displayed
            {
                text = "You need a key...";
                textManager.Instance.enableText(text);
            }
            else                                                //if the player has the key, alters text that is displayed
            {
                text = "Press 'e' to unlock";
                textManager.Instance.enableText(text);
            }
        }
    }

    //Activates when something exits the trigger collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))                         //if the exiting object was the player, removes the text from screen
            textManager.Instance.disableText(text);
    }
}

