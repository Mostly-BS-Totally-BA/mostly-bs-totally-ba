using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platino_Candles : MonoBehaviour
{
    public GameObject[] walls;
    public GameObject[] overlays;
    GameObject candle = null;

    bool showGUI = false;
    int number_pulled = 0;
    int previous_pulled = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platino_Candle"))
        {
            candle = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Platino_Candle_NonInter") && previous_pulled < number_pulled)
        {
            showGUI = false;
            previous_pulled = number_pulled;
            Destroy(collision.GetComponent<CircleCollider2D>());
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interaction") && candle)
        {
            previous_pulled = number_pulled;
            number_pulled++;
            showGUI = true;
            Destroy(candle);
        }

        if(number_pulled == 3)
        {
            for (int i = 0; i < walls.GetLength(0); i++)
                walls[i].SetActive(false);
            for (int i = 0; i < overlays.GetLength(0); i++)
                overlays[i].SetActive(false);
        }
    }

    private void OnGUI()
    {
        if (showGUI == true && number_pulled == 1)
        {
            GUI.Label(new Rect(10, 10, 300, 20), "A tumbler turns..."); 
        }
        else if (showGUI == true && number_pulled == 2)
        {
            GUI.Label(new Rect(10, 10, 300, 20), "Stone grates on stone...");
        }
        else if (showGUI == true && number_pulled == 3)
        {
            GUI.Label(new Rect(10, 10, 300, 20), "A passage opens...");
        }
    }
}
