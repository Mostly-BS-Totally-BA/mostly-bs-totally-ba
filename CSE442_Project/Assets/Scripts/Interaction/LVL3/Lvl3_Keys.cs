using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl3_Keys : MonoBehaviour
{
    public int has_Keys = 0;
    
    public void PickedUpKey()
    {
        has_Keys++;
    }

    public void UsedKey()
    {
        has_Keys--;
    }

}
