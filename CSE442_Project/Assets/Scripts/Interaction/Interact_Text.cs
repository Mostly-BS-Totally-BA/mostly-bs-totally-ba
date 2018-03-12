using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Text : MonoBehaviour
{
    bool showGUI = false;
    public string text;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            showGUI = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            showGUI = false;

        if (gameObject.CompareTag("Chest_Open"))
            Destroy(gameObject.GetComponent("BoxCollider2D"));
    }

    private void OnGUI()
    {
        if (showGUI == true)
        {
            GUI.Label(new Rect(10, 10, 500, 20), text);
        }
    }
}
