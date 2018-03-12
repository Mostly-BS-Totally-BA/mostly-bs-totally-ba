using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Interact : MonoBehaviour
{
    public GameObject opened_door;
    public GameObject[] overlay;
    int number_of_Overlays;

    public void RunInteraction()
    {
        number_of_Overlays = overlay.GetLength(0);
        for (int i = 0; i < number_of_Overlays; i++)
            overlay[i].SetActive(false);

        gameObject.SetActive(false);
        opened_door.SetActive(true);
        Destroy(gameObject.GetComponent("Interact_Text"));
    }
}
 