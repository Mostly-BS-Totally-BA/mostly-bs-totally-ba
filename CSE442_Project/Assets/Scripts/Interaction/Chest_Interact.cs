using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_Interact : MonoBehaviour
{
    public GameObject opened_chest;

    public void RunInteraction()
    {
        gameObject.SetActive(false);
        opened_chest.SetActive(true);
    }
}
