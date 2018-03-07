using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock_Door_lvl1 : MonoBehaviour
{
    public GameObject unlocked_door;
    public void RunInteraction()
    {
        gameObject.SetActive(false);
        unlocked_door.SetActive(true);
    }
}
