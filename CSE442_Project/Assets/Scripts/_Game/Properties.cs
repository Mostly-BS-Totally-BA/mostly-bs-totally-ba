using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties : MonoBehaviour
{

    private int _myAge;

    public int MyAge
    {
        get
        {
            return _myAge;
        }

        set
        {
            _myAge = value;
        }
    }

    //public int MyAge { get; private set; }


    /*Player script
     * 
     * private Properties myProperties;
     * 
     * void Start()
     * {
     *  myProperties = new Properties();
     *  Debug.Log(myProperties.MyAge);
     * 
     *  myProperties.MyAge = 88;
     *  Debug.Log();
     * }
     * 
     * */

}
