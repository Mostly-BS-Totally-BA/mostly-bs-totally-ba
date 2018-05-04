using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script pushes text to screen when player is within the collider of the object this is a component of
public class Interact_Text : MonoBehaviour
{
    public string text;                             //text that is displayed, can be set in Unity
    public Player_Interact player;                  //Links script to the player sprite, can be set in Unity

    //activates when something enters the object's trigger collider
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))                     //if the object that enters the collider is the player, displays text on screen
            textManager.Instance.enableText(text);

        if(gameObject.CompareTag("Door_Inter_Locked"))          //if the object this is attached to is the locked door to level2
        {
            if (player.has_lvl1_Key == false)    //and if the player does not have the key to proceed, alters text that is displayed
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
        if (collision.CompareTag("Player"))
        {
            textManager.Instance.disableText(text);
        }
    }
}