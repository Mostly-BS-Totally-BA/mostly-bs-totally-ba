using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interact : MonoBehaviour
{

    public GameObject interactingObj = null;
    public bool has_lvl1_Key = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door_Interactable") || collision.CompareTag("Interactable") || collision.CompareTag("Chest_Interactable") || collision.CompareTag("Door_Inter_Locked"))  
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
        if (collision.CompareTag("Door_Interactable") || collision.CompareTag("Interactable") || collision.CompareTag("Interactable") || collision.CompareTag("Door_Inter_Locked"))
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


