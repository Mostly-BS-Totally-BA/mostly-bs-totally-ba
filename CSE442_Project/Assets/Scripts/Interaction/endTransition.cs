using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endTransition : MonoBehaviour
{
    public GameObject endScreen;
    GameObject player = null;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject;
        }
    }

    private void Update()
    {
        if(Input.GetButtonDown("Interaction") && player)
        {
            endScreen.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = null;
        }
    }
}
