using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script determines what objects player can interact with and how interaction is started
public class Player_Interact : MonoBehaviour
{

    public GameObject interactingObj = null;                    //The object to interact with
    public bool has_lvl1_Key = false;                           //variable for if player has key to unlock level 1 door


    //Activates when player enters a trigger collider on an object
    void OnTriggerEnter2D(Collider2D collision)
    {
        //If the trigger collider's object is a door, an interactable item (requiring 'e' to interact), a chest, or locked door, sets varable to that object
        if (collision.CompareTag("Door_Interactable") || collision.CompareTag("Interactable") || collision.CompareTag("Chest_Interactable") || collision.CompareTag("Door_Inter_Locked"))  
        {
            interactingObj = collision.gameObject;
        }
        else if (collision.CompareTag("Treasure_Inter") || collision.CompareTag("Platino"))     //else if object is tagged as treasure or platino sprite, runs interaction immediately
        {
            collision.SendMessage("RunInteraction");                                            //sends message to triggering object to RunInteraction (calls RunInteraction function on object)
        }   
    }

    //Activates whe player leaves the trigger collider of an object
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Door_Interactable") || collision.CompareTag("Interactable") || collision.CompareTag("Chest_Interactable") || collision.CompareTag("Door_Inter_Locked"))
        {
            if (collision.gameObject == interactingObj)             //if the game object is the same as the value of the variable, sets variable to null
            {
                interactingObj = null;
            }
        }
    }

    //Activates every frame
    private void Update()
    {
        if (Input.GetButtonDown("Interaction") && interactingObj)           //If player has pressed interaction button ('e') and there is an object to interact with
        {
            interactingObj.SendMessage("RunInteraction");                   //sends message to interacting object to RunInteraction (calls object's RunInteraction function)
        }
    }
}


