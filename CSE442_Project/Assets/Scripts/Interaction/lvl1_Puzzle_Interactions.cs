using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl1_Puzzle_Interactions : MonoBehaviour
{

    int torch1_pulls = 0;
    int torch2_pulls = 0;
    int torch3_pulls = 0;
    int torch4_pulls = 0;

    public GameObject[] walls;
    public GameObject[] overlays;
    public GameObject[] torches;

    GameObject torch = null;
    string text;
    bool showGUI;
    bool solved = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Puzzle_Interact"))
        {
            torch = collision.gameObject;
            text = "Press 'e' to pull";
            showGUI = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        showGUI = false;
        if (solved == true)
        {
            for (int i = 0; i < torches.GetLength(0); i++)
            {
                Destroy(torches[i]);
            }
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interaction"))
        {

            if (torch.name == "Torch_3" && torch3_pulls != 1 && (torch2_pulls == 0 && torch1_pulls == 0 && torch4_pulls == 0))
            {
                torch3_pulls++;
                text = "The sconce clicks into position...";
                showGUI = true;
            }

            else if (torch.name == "Torch_4" && torch4_pulls != 2 && (torch3_pulls == 1 && torch1_pulls == 0 && torch2_pulls == 0))
            {
                torch4_pulls++;
                if (torch4_pulls == 1)
                {
                    text = "The sconce clicks into position...";
                    showGUI = true;
                }
                else if (torch4_pulls == 2)
                {
                    text = "The sconce clicks further...";
                    showGUI = true;
                }
            }

            else if (torch.name == "Torch_2" && torch2_pulls != 3 && (torch3_pulls == 1 && torch1_pulls == 0 && torch4_pulls == 2))
            {
                torch2_pulls++;
                if (torch2_pulls == 1)
                {
                    text = "The sconce clicks into position...";
                    showGUI = true;
                }
                else if (torch2_pulls == 2)
                {
                    text = "The sconce clicks further...";
                    showGUI = true;
                }
                else if (torch2_pulls == 3)
                {
                    text = "The sconce clicks even further...";
                    showGUI = true;
                }
            }

            else if (torch.name == "Torch_1" && torch1_pulls != 1 && (torch2_pulls == 3 && torch3_pulls == 1 && torch4_pulls == 2))
            {
                torch1_pulls++;
                text = "The sconce clicks into position...";
                showGUI = true;
            }

            else
            {
                torch1_pulls = 0;
                torch2_pulls = 0;
                torch3_pulls = 0;
                torch4_pulls = 0;

                text = "The sconces snap back into place. It reset!";
                showGUI = true;
            }

            if (torch1_pulls == 1 && torch2_pulls == 3 && torch3_pulls == 1 && torch4_pulls == 2)
            {
                for (int i = 0; i < walls.GetLength(0); i++)
                {
                    walls[i].SetActive(false);
                }
                for (int i = 0; i < overlays.GetLength(0); i++)
                {
                    overlays[i].SetActive(false);
                }
                solved = true;
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
