using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Double_Door_Interact : MonoBehaviour {

    public GameObject opened_door1;
    public GameObject opened_door2;
    public GameObject other_door;
    public GameObject [] overlay;
    int number_of_Overlays;

    public void RunInteraction()
    {
        number_of_Overlays = overlay.GetLength(0);
        for (int i = 0; i < number_of_Overlays; i++)
            overlay[i].SetActive(false);

        gameObject.SetActive(false);
        other_door.SetActive(false);
        opened_door1.SetActive(true);
        opened_door2.SetActive(true);
    }
}
