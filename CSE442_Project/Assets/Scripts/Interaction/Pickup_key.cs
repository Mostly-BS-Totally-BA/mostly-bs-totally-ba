using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script allows player to interact with key sprite on level 1
public class Pickup_key : MonoBehaviour
{
    public Player_Interact player;          //links script to player object
    public Lvl3_Keys keys = null;

    //called by Player_Interact script
    public void RunInteraction()
    {
        AudioManager.Instance.PlayAudio(AudioName.Key);

        if (keys == null)                      //not on lvl3
        {
            player.has_lvl1_Key = true;        //sets value of variable in Player_Interact script to true, player has picked up key

            Destroy(gameObject);               //removes key sprite from map
        }
        else
        {
            keys.PickedUpKey();
            Destroy(gameObject);
        }
    }
}
