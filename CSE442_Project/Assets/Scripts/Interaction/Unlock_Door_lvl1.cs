using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock_Door_lvl1 : MonoBehaviour
{
    public GameObject unlocked_door;
    public Player_Interact player;

    public void RunInteraction()
    {
        if(player.has_lvl1_Key == true)
        {
            gameObject.SetActive(false);
            unlocked_door.SetActive(true);
        }
    }
}
