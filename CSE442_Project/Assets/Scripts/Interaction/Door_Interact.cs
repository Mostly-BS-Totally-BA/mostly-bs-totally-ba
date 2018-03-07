using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Interact : MonoBehaviour
{
    public GameObject opened_door;
    public void RunInteraction()
    {
        gameObject.SetActive(false);
        if (opened_door != null)
        {
            opened_door.SetActive(true);
        }
    }
}
 