using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_Hidden_Enemies : MonoBehaviour
{
    public GameObject[] deactivate;
    public GameObject[] hiddenEnemies;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < deactivate.Length; i++)
        {
            Destroy(deactivate[i]);
        }

        for (int i = 0; i < hiddenEnemies.Length; i++)
        {
            hiddenEnemies[i].SetActive(true);
        }
    }

}
