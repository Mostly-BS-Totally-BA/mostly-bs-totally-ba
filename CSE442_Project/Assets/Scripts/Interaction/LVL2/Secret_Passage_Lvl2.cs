using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script handles opening the secret passage on level 2
public class Secret_Passage_Lvl2 : MonoBehaviour {

    public GameObject[] walls;                              //array of gameObjects for walls blocking secret passage, set in Unity
    public GameObject[] overlays;                           //array for black overlays covering secret passage, set in Unity

    //called by Player_Interact script
    public void RunInteraction()
    {
        for (int i = 0; i < walls.GetLength(0); i++)        //loops remove the walls and overlays, revealing the secret passage when the player interacts with it
            walls[i].SetActive(false);
        for (int i = 0; i < overlays.GetLength(0); i++)
            overlays[i].SetActive(false);
    }
}
