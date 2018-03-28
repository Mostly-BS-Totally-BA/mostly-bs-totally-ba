using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script allows player to use key to unlock locked door on level 1
public class Unlock_Door_lvl1 : MonoBehaviour
{
    public GameObject unlocked_door;                //variable for sprite of unlocked door, set in Unity
    public Player_Interact player;                  //links to the player for access to variables within Player_Interact script

    //Called via Player_Interact script when player presses 'e' on locked door
    public void RunInteraction()
    {
        if(player.has_lvl1_Key == true)             //If player has the key to unlock the door, sets locked door to inactive and activates unlocked_door
        {
            gameObject.SetActive(false);
            unlocked_door.SetActive(true);
        }
    }
}
