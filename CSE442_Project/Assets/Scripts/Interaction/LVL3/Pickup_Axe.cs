using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Axe : MonoBehaviour
{
    public Cutdown_Dead_Tree tree;
    private GUIStyle guiStyle = new GUIStyle();

    void RunInteraction()
    {
        tree.PickedUpAxe();
        Destroy(gameObject);
    }
}
