using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Enables the monologue of Platino on each level
public class Platino_Speech : MonoBehaviour
{
    public TextBoxManager textBox;                          //text box that contains monologue, set in Unity (text box must have TextBoxManager component)

    //Activates when something enters the trigger collider of the object this is attached to
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))                 //if the object that entered is the player
        {
            StartCoroutine(Wait(1));                        //waits for 1 second
            textBox.EnableText();                           //calls EnableText() function in TextBoxManager component of textBox
        }
    }

    //Activated by function call within TextBoxManager
    public void Disapper()
    {
        Destroy(gameObject);                                //removes Platino sprite from map
    }

    //Coroutine that causes script to wait before resuming 
    IEnumerator Wait(float timer)
    {
        yield return new WaitForSecondsRealtime(timer);     //Waits for seconds indicated by timer
    }
}
