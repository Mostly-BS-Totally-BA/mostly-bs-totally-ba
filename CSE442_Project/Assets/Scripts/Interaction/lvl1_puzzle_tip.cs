using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script opens text box giving the player a hint for the puzzle on level 1 when the open it
public class lvl1_puzzle_tip : MonoBehaviour
{
    public GameObject textBox;                          //text box object, set in Unity
    public Player_Movement player;                      //player game object, gives access to variables in Player_Movement, set in Unity

    //called by Player_Interact script
    public void RunInteraction()
    {
        AudioManager.Instance.PlayAudio(AudioName.Book);
        player.canMove = false;                         //disables player's ability to move, alters variable in Player_Movement script of player object
        textBox.SetActive(true);                        //activates textBox so that tip appears on screen
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))           //if player presses return key ('enter')
        {
            AudioManager.Instance.PlayAudio(AudioName.Book);
            player.canMove = true;                      //allows the player to move again, alters variable in Player_Movement script of player object
            textBox.SetActive(false);                   //deactivates textBox so that tip disappears from screen
        }
    }
}
