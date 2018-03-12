using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_key : MonoBehaviour
{
    public Player_Interact player;
    public void RunInteraction()
    {
        player.has_lvl1_Key = true;

        Destroy(gameObject);
    }
}
