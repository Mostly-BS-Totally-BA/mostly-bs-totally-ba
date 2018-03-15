using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl1_puzzle_tip : MonoBehaviour
{
    public GameObject textBox;
    public Player_Movement player;

    public void RunInteraction()
    {
        player.canMove = false;
        textBox.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            player.canMove = true;
            textBox.SetActive(false);
        }
    }
}
