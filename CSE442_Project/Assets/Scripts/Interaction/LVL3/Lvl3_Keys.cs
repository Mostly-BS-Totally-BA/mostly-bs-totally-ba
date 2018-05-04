using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl3_Keys : MonoBehaviour
{
    public int has_Keys = 0;                                   //how many keys player current has
    int keys_Gotten;                                           //how many keys player has found total
    public GameObject boss;

    string text;                                               //text that appears when treasure is picked up, set in Unity
    float timer = 5;                                           //timer

    public void PickedUpKey()
    {
        has_Keys++;
        keys_Gotten++;
        if(keys_Gotten == 1)
        {
            text = "The wind blows from the west...";
            textManager.Instance.enableTextRed(text);
            StartCoroutine(Wait(timer));
        }
        else if (keys_Gotten == 2)
        {
            text = "The branches bend and creak...";
            textManager.Instance.enableTextRed(text);
            StartCoroutine(Wait(timer));
        }
        else if (keys_Gotten == 3)
        {
            text = "The trees sound as if they are trying to speak...";
            textManager.Instance.enableTextRed(text);
            StartCoroutine(Wait(timer));
        }
        else if (keys_Gotten == 4)
        {
            text = "The roots grow deep...";
            textManager.Instance.enableTextRed(text);
            StartCoroutine(Wait(timer));
        }
        else if (keys_Gotten == 5)
        {
            text = "A monster grows from the earth...";
            textManager.Instance.enableTextRed(text);
            StartCoroutine(Wait(timer));
            boss.SetActive(true);
        }
    }

    public void UsedKey()
    {
        has_Keys--;
    }

    //Coroutine that causes script to wait before resuming 
    IEnumerator Wait(float timer)
    {
        yield return new WaitForSecondsRealtime(timer);        //Waits for seconds indicated by timer
        textManager.Instance.disableText(text);
    }
}
