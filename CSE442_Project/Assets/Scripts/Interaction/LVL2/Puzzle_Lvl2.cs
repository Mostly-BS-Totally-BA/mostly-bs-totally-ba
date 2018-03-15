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
    public GameObject[] plates;

    GameObject square = null;
    string text;
    bool showGUI;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Puzzle_Interact"))
        {
            square = collision.gameObject;

            if (square.name == "Floor_yellow" && pressed_yellow == false)
            {
                pressed_yellow = true;
                text = "The plate clicks...";
                showGUI = true;
            }
            else if (square.name == "Floor_blue" && pressed_blue == false && pressed_yellow == true)
            {
                pressed_blue = true;
                text = "The walls shake...";
                showGUI = true;
            }
            else if (square.name == "Floor_red" && pressed_red == false && pressed_yellow == true && pressed_blue == true)
            {
                pressed_red = true;
                text = "The walls open!";
                showGUI = true;
            }
            else
            {
                pressed_blue = false;
                pressed_yellow = false;
                pressed_red = false;
                text = "It resets!";
                showGUI = true;
            }

            if (pressed_blue == true && pressed_red == true && pressed_yellow == true)
            {
                for (int i = 0; i < walls.GetLength(0); i++)
                {
                    walls[i].SetActive(false);
                }
                for (int i = 0; i < overlays.GetLength(0); i++)
                {
                    overlays[i].SetActive(false);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        showGUI = false;
        if (pressed_blue == true && pressed_red == true && pressed_yellow == true)
        {
            for (int i = 0; i < plates.GetLength(0); i++)
            {
                Destroy(plates[i].GetComponent<BoxCollider2D>());
            }
        }
    }

    private void OnGUI()
    {
        if (showGUI == true)
        {
            GUI.Label(new Rect(10, 10, 500, 20), text);
        }
    }
}
