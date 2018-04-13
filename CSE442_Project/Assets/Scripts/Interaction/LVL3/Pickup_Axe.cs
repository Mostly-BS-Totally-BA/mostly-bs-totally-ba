using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Axe : MonoBehaviour
{
    public Cutdown_Dead_Tree tree;

    void RunInteraction()
    {
        tree.PickedUpAxe();
        Destroy(gameObject);
    }
}
