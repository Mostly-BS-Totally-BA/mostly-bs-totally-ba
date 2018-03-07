using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interact : MonoBehaviour
{

    public GameObject interactingObj = null;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door_Interactable"))  
        {
            interactingObj = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Door_Interactable"))
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


