using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Lvl2 : MonoBehaviour
{
    bool pressed_yellow = false;
    bool pressed_blue = false;
    bool pressed_red = false;
    public GameObject[] walls;
    public GameObject[] overlays;
    GameObject square = null;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Puzzle_Interact"))
        {
            square = collision.gameObject;

            if (square.name == "Floor_yellow" && pressed_yellow == false)
            {
                pressed_yellow = true;
            }
            else if (square.name == "Floor_blue" && pressed_blue == false && pressed_yellow == true)
            {
                pressed_blue = true;
            }
            else if (square.name == "Floor_red" && pressed_red == false && pressed_yellow == true && pressed_blue == true)
            {
                pressed_red = true;
            }
            else
            {
                pressed_blue = false;
                pressed_yellow = false;
                pressed_red = false;
            }

            if (pressed_blue == true && pressed_red == true && pressed_yellow == true)
            {
                for (int i = 0; i < walls.GetLength(0); i++)
                    walls[i].SetActive(false);
                for (int i = 0; i < overlays.GetLength(0); i++)
                    overlays[i].SetActive(false);
            }


        }
    }
}
