using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl3_Puzzle : MonoBehaviour
{
    bool solved = false;                            //if the puzzle is solved
    public bool canInteract = true;

    public GameObject[] pressurePlates;             //array of game objects for the different pressure plates, set in Unity
    public GameObject[] bridgeSections;             //array of game objects for the bridge sections
    public GameObject[] pitSections;                //array of game objects for the pit sections

    GameObject plate = null;                       //plate currently being interacted with

    public void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Puzzle_Trigger"))                               //if it is a puzzle collider
       {
            plate = gameObject;                                          //set plate to current game object

            if (plate.name == "plate1")                                  //if it is the first plate (activates sections 1,3,5)
            {
                if (bridgeSections[0].activeInHierarchy)                 //check if bridge section 1 is active or not                 
                {
                    bridgeSections[0].SetActive(false);                 //if it is, deactivate section
                    bridgeSections[1].SetActive(false);
                    pitSections[0].SetActive(true);                     //activate pit so player cannot cross
                    pitSections[1].SetActive(true);
                }
                else                                                    //if it isn't active
                {
                    bridgeSections[0].SetActive(true);                  //activate section 1 of bridge
                    bridgeSections[1].SetActive(true);
                    pitSections[0].SetActive(false);                    //deactivate pit so player can cross section
                    pitSections[1].SetActive(false);
                }

                if (bridgeSections[4].activeInHierarchy)                 //check if bridge section 3 is active or not                 
                {
                    bridgeSections[4].SetActive(false);                 //if it is, deactivate section
                    bridgeSections[5].SetActive(false);
                    pitSections[4].SetActive(true);                     //activate pit so player cannot cross
                    pitSections[5].SetActive(true);
                }
                else                                                    //if it isn't active
                {
                    bridgeSections[4].SetActive(true);                  //activate section 3 of bridge
                    bridgeSections[5].SetActive(true);
                    pitSections[4].SetActive(false);                    //deactivate pit so player can cross section
                    pitSections[5].SetActive(false);
                }

                if (bridgeSections[8].activeInHierarchy)                 //check if bridge section 5 is active or not                 
                {
                    bridgeSections[8].SetActive(false);                 //if it is, deactivate section
                    bridgeSections[9].SetActive(false);
                    pitSections[8].SetActive(true);                     //activate pit so player cannot cross
                    pitSections[9].SetActive(true);
                }
                else                                                    //if it isn't active
                {
                    bridgeSections[8].SetActive(true);                  //activate section 5 of bridge
                    bridgeSections[9].SetActive(true);
                    pitSections[8].SetActive(false);                    //deactivate pit so player can cross section
                    pitSections[9].SetActive(false);
                }

                //all sections active then puzzle is solved
                if (bridgeSections[0].activeInHierarchy && bridgeSections[2].activeInHierarchy && bridgeSections[4].activeInHierarchy && bridgeSections[6].activeInHierarchy && bridgeSections[8].activeInHierarchy)
                {
                    solved = true;
                    for (int i = 0; i < 6; i++)
                    {
                        Destroy(pressurePlates[i].GetComponent<Lvl3_Puzzle>());
                    }
                }
            }

            if (plate.name == "plate2")                                  //if it is the 2nd plate (activates sections 1,2,4)
            {
                if (bridgeSections[0].activeInHierarchy)                 //check if bridge section 1 is active or not                 
                {
                    bridgeSections[0].SetActive(false);                 //if it is, deactivate section
                    bridgeSections[1].SetActive(false);
                    pitSections[0].SetActive(true);                     //activate pit so player cannot cross
                    pitSections[1].SetActive(true);
                }
                else                                                    //if it isn't active
                {
                    bridgeSections[0].SetActive(true);                  //activate section 1 of bridge
                    bridgeSections[1].SetActive(true);
                    pitSections[0].SetActive(false);                    //deactivate pit so player can cross section
                    pitSections[1].SetActive(false);
                }

                if (bridgeSections[2].activeInHierarchy)                 //check if bridge section 2 is active or not                 
                {
                    bridgeSections[2].SetActive(false);                 //if it is, deactivate section
                    bridgeSections[3].SetActive(false);
                    pitSections[2].SetActive(true);                     //activate pit so player cannot cross
                    pitSections[3].SetActive(true);
                }
                else                                                    //if it isn't active
                {
                    bridgeSections[2].SetActive(true);                  //activate section 2 of bridge
                    bridgeSections[3].SetActive(true);
                    pitSections[2].SetActive(false);                    //deactivate pit so player can cross section
                    pitSections[3].SetActive(false);
                }

                if (bridgeSections[6].activeInHierarchy)                 //check if bridge section 4 is active or not                 
                {
                    bridgeSections[6].SetActive(false);                 //if it is, deactivate section
                    bridgeSections[7].SetActive(false);
                    pitSections[6].SetActive(true);                     //activate pit so player cannot cross
                    pitSections[7].SetActive(true);
                }
                else                                                    //if it isn't active
                {
                    bridgeSections[6].SetActive(true);                  //activate section 4 of bridge
                    bridgeSections[7].SetActive(true);
                    pitSections[6].SetActive(false);                    //deactivate pit so player can cross section
                    pitSections[7].SetActive(false);
                }


                //all sections active then puzzle is solved
                if (bridgeSections[0].activeInHierarchy && bridgeSections[2].activeInHierarchy && bridgeSections[4].activeInHierarchy && bridgeSections[6].activeInHierarchy && bridgeSections[8].activeInHierarchy)
                {
                    solved = true;
                    for (int i = 0; i < 6; i++)
                    {
                        Destroy(pressurePlates[i].GetComponent<Lvl3_Puzzle>());
                    }
                }
            }

            if (plate.name == "plate3")                                  //if it is the 3rd plate (activates sections 3,4,5)
            {
                if (bridgeSections[4].activeInHierarchy)                 //check if bridge section 3 is active or not                 
                {
                    bridgeSections[4].SetActive(false);                 //if it is, deactivate section
                    bridgeSections[5].SetActive(false);
                    pitSections[4].SetActive(true);                     //activate pit so player cannot cross
                    pitSections[5].SetActive(true);
                }
                else                                                    //if it isn't active
                {
                    bridgeSections[4].SetActive(true);                  //activate section 3 of bridge
                    bridgeSections[5].SetActive(true);
                    pitSections[4].SetActive(false);                    //deactivate pit so player can cross section
                    pitSections[5].SetActive(false);
                }

                if (bridgeSections[6].activeInHierarchy)                 //check if bridge section 4 is active or not                 
                {
                    bridgeSections[6].SetActive(false);                 //if it is, deactivate section
                    bridgeSections[7].SetActive(false);
                    pitSections[6].SetActive(true);                     //activate pit so player cannot cross
                    pitSections[7].SetActive(true);
                }
                else                                                    //if it isn't active
                {
                    bridgeSections[6].SetActive(true);                  //activate section 4 of bridge
                    bridgeSections[7].SetActive(true);
                    pitSections[6].SetActive(false);                    //deactivate pit so player can cross section
                    pitSections[7].SetActive(false);
                }

                if (bridgeSections[8].activeInHierarchy)                 //check if bridge section 5 is active or not                 
                {
                    bridgeSections[8].SetActive(false);                 //if it is, deactivate section
                    bridgeSections[9].SetActive(false);
                    pitSections[8].SetActive(true);                     //activate pit so player cannot cross
                    pitSections[9].SetActive(true);
                }
                else                                                    //if it isn't active
                {
                    bridgeSections[8].SetActive(true);                  //activate section 5 of bridge
                    bridgeSections[9].SetActive(true);
                    pitSections[8].SetActive(false);                    //deactivate pit so player can cross section
                    pitSections[9].SetActive(false);
                }


                //all sections active then puzzle is solved
                if (bridgeSections[0].activeInHierarchy && bridgeSections[2].activeInHierarchy && bridgeSections[4].activeInHierarchy && bridgeSections[6].activeInHierarchy && bridgeSections[8].activeInHierarchy)
                {
                    solved = true;
                    for (int i = 0; i < 6; i++)
                    {
                        Destroy(pressurePlates[i].GetComponent<Lvl3_Puzzle>());
                    }
                }
            }

            if (plate.name == "plate4")                                  //if it is the 4th plate (activates sections 2,3,4)
            {
                if (bridgeSections[2].activeInHierarchy)                 //check if bridge section 2 is active or not                 
                {
                    bridgeSections[2].SetActive(false);                 //if it is, deactivate section
                    bridgeSections[3].SetActive(false);
                    pitSections[2].SetActive(true);                     //activate pit so player cannot cross
                    pitSections[3].SetActive(true);
                }
                else                                                    //if it isn't active
                {
                    bridgeSections[2].SetActive(true);                  //activate section 2 of bridge
                    bridgeSections[3].SetActive(true);
                    pitSections[2].SetActive(false);                    //deactivate pit so player can cross section
                    pitSections[3].SetActive(false);
                }

                if (bridgeSections[4].activeInHierarchy)                 //check if bridge section 3 is active or not                 
                {
                    bridgeSections[4].SetActive(false);                 //if it is, deactivate section
                    bridgeSections[5].SetActive(false);
                    pitSections[4].SetActive(true);                     //activate pit so player cannot cross
                    pitSections[5].SetActive(true);
                }
                else                                                    //if it isn't active
                {
                    bridgeSections[4].SetActive(true);                  //activate section 3 of bridge
                    bridgeSections[5].SetActive(true);
                    pitSections[4].SetActive(false);                    //deactivate pit so player can cross section
                    pitSections[5].SetActive(false);
                }

                if (bridgeSections[6].activeInHierarchy)                 //check if bridge section 4 is active or not                 
                {
                    bridgeSections[6].SetActive(false);                 //if it is, deactivate section
                    bridgeSections[7].SetActive(false);
                    pitSections[6].SetActive(true);                     //activate pit so player cannot cross
                    pitSections[7].SetActive(true);
                }
                else                                                    //if it isn't activeDestroy(pressurePlates[i].GetComponent<Lvl3_Puzzle>());
                {
                    bridgeSections[6].SetActive(true);                  //activate section 4 of bridge
                    bridgeSections[7].SetActive(true);
                    pitSections[6].SetActive(false);                    //deactivate pit so player can cross section
                    pitSections[7].SetActive(false);
                }


                //all sections active then puzzle is solved
                if (bridgeSections[0].activeInHierarchy && bridgeSections[2].activeInHierarchy && bridgeSections[4].activeInHierarchy && bridgeSections[6].activeInHierarchy && bridgeSections[8].activeInHierarchy)
                {
                    solved = true;
                    for (int i = 0; i < 6; i++)
                    {
                        Destroy(pressurePlates[i].GetComponent<Lvl3_Puzzle>());
                    }
                }
            }

            if (plate.name == "plate5")                                  //if it is the 5th plate (activates sections 1,2,3)
            {
                if (bridgeSections[0].activeInHierarchy)                 //check if bridge section 1 is active or not                 
                {
                    bridgeSections[0].SetActive(false);                 //if it is, deactivate section
                    bridgeSections[1].SetActive(false);
                    pitSections[0].SetActive(true);                     //activate pit so player cannot cross
                    pitSections[1].SetActive(true);

                }
                else                                                    //if it isn't active
                {
                    bridgeSections[0].SetActive(true);                  //activate section 1 of bridge
                    bridgeSections[1].SetActive(true);
                    pitSections[0].SetActive(false);                    //deactivate pit so player can cross section
                    pitSections[1].SetActive(false);
                }

                if (bridgeSections[2].activeInHierarchy)                 //check if bridge section 2 is active or not                 
                {
                    bridgeSections[2].SetActive(false);                 //if it is, deactivate section
                    bridgeSections[3].SetActive(false);
                    pitSections[2].SetActive(true);                     //activate pit so player cannot cross
                    pitSections[3].SetActive(true);
                }
                else                                                    //if it isn't active
                {
                    bridgeSections[2].SetActive(true);                  //activate section 2 of bridge
                    bridgeSections[3].SetActive(true);
                    pitSections[2].SetActive(false);                    //deactivate pit so player can cross section
                    pitSections[3].SetActive(false);
                }

                if (bridgeSections[4].activeInHierarchy)                 //check if bridge section 3 is active or not                 
                {
                    bridgeSections[4].SetActive(false);                 //if it is, deactivate section
                    bridgeSections[5].SetActive(false);
                    pitSections[4].SetActive(true);                     //activate pit so player cannot cross
                    pitSections[5].SetActive(true);
                }
                else                                                    //if it isn't active
                {
                    bridgeSections[4].SetActive(true);                  //activate section 3 of bridge
                    bridgeSections[5].SetActive(true);
                    pitSections[4].SetActive(false);                    //deactivate pit so player can cross section
                    pitSections[5].SetActive(false);
                }


                //all sections active then puzzle is solved
                if (bridgeSections[0].activeInHierarchy && bridgeSections[2].activeInHierarchy && bridgeSections[4].activeInHierarchy && bridgeSections[6].activeInHierarchy && bridgeSections[8].activeInHierarchy)
                {
                    solved = true;
                    for (int i = 0; i < 6; i++)
                    {
                        Destroy(pressurePlates[i].GetComponent<Lvl3_Puzzle>());
                    }
                }
            }

            if (plate.name == "plate6")                                  //if it is the 6th plate (activates sections 2,4,5)
            {
                if (bridgeSections[2].activeInHierarchy)                 //check if bridge section 2 is active or not                 
                {
                    bridgeSections[2].SetActive(false);                 //if it is, deactivate section
                    bridgeSections[3].SetActive(false);
                    pitSections[2].SetActive(true);                     //activate pit so player cannot cross
                    pitSections[3].SetActive(true);
                }
                else                                                    //if it isn't active
                {
                    bridgeSections[2].SetActive(true);                  //activate section 2 of bridge
                    bridgeSections[3].SetActive(true);
                    pitSections[2].SetActive(false);                    //deactivate pit so player can cross section
                    pitSections[3].SetActive(false);
                }

                if (bridgeSections[6].activeInHierarchy)                 //check if bridge section 4 is active or not                 
                {
                    bridgeSections[6].SetActive(false);                 //if it is, deactivate section
                    bridgeSections[7].SetActive(false);
                    pitSections[6].SetActive(true);                     //activate pit so player cannot cross
                    pitSections[7].SetActive(true);
                }
                else                                                    //if it isn't active
                {
                    bridgeSections[6].SetActive(true);                  //activate section 4 of bridge
                    bridgeSections[7].SetActive(true);
                    pitSections[6].SetActive(false);                    //deactivate pit so player can cross section
                    pitSections[7].SetActive(false);
                }

                if (bridgeSections[8].activeInHierarchy)                 //check if bridge section 5 is active or not                 
                {
                    bridgeSections[8].SetActive(false);                 //if it is, deactivate section
                    bridgeSections[9].SetActive(false);
                    pitSections[8].SetActive(true);                     //activate pit so player cannot cross
                    pitSections[9].SetActive(true);
                }
                else                                                    //if it isn't active
                {
                    bridgeSections[8].SetActive(true);                  //activate section 5 of bridge
                    bridgeSections[9].SetActive(true);
                    pitSections[8].SetActive(false);                    //deactivate pit so player can cross section
                    pitSections[9].SetActive(false);
                }


                //all sections active then puzzle is solved
                if (bridgeSections[0].activeInHierarchy && bridgeSections[2].activeInHierarchy && bridgeSections[4].activeInHierarchy && bridgeSections[6].activeInHierarchy && bridgeSections[8].activeInHierarchy)
                {
                    solved = true;
                    for (int i = 0; i < 6; i++)
                    {
                        Destroy(pressurePlates[i].GetComponent<Lvl3_Puzzle>());
                    }
                }
            }
        }
      else
      {
      }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        plate = null;
    }
}
