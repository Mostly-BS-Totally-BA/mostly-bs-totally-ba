using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platino_speech_lvl1 : MonoBehaviour
{
    public TextBoxManageLVL1 textBox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Wait(1));
            textBox.EnableText();
        }
    }

    public void Disapper()
    {
        Destroy(gameObject);
    }

    IEnumerator Wait(float timer)
    {
        yield return new WaitForSecondsRealtime(timer);
    }
}
