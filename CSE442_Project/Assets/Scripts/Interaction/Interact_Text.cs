using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Text : MonoBehaviour
{
    [SerializeField]
    private bool showGUI = false;
    public string text;
    public Player_Interact player;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            showGUI = true;
        if(gameObject.CompareTag("Door_Inter_Locked"))
        {
            if (player.has_lvl1_Key == false)
            {
                text = "You need a key...";
                showGUI = true;
            }
            else
            {
                text = "Press 'e' to unlock";
                showGUI = true;
            }
        }
    }
    public bool getShowGUI(){
        return showGUI;
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
