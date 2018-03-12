using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure_pickup : MonoBehaviour
{
    bool showGUI = false;
    public string text;
    float timer = .35F;

    public void RunInteraction()
    {
        showGUI = true;
        StartCoroutine(Wait(timer));
    }

    private void OnGUI()
    {
        if (showGUI == true)
        {
            GUI.Label(new Rect(10, 10, 500, 20), text);
        }
    }

    IEnumerator Wait(float timer)
    {
        yield return new WaitForSecondsRealtime(timer);
        Destroy(gameObject);
    }
}
