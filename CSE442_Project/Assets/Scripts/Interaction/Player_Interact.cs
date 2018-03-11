using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interact : MonoBehaviour
{

    public GameObject interactingObj = null;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door_Interactable") || collision.CompareTag("Interactable") || collision.CompareTag("Chest_Interactable"))  
        {
            interactingObj = collision.gameObject;
        }
        else if (collision.CompareTag("Treasure_Inter") || collision.CompareTag("Platino"))
        {
            collision.SendMessage("RunInteraction");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Door_Interactable") || collision.CompareTag("Interactable") || collision.CompareTag("Interactable"))
        {
            if (collision.gameObject == interactingObj)
            {
                interactingObj = null;
            }
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interaction") && interactingObj)
        {
            interactingObj.SendMessage("RunInteraction");
        }
    }
}


