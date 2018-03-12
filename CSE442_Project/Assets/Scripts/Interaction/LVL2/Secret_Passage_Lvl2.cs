using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secret_Passage_Lvl2 : MonoBehaviour {

    public GameObject[] walls;
    public GameObject[] overlays;

    public void RunInteraction()
    {
        for (int i = 0; i < walls.GetLength(0); i++)
            walls[i].SetActive(false);
        for (int i = 0; i < overlays.GetLength(0); i++)
            overlays[i].SetActive(false);
    }
}
