using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endCredits : MonoBehaviour
{
    public GameObject next;
    public void nextSlide()
    {
        gameObject.SetActive(false);
        next.SetActive(true);
    }
}
