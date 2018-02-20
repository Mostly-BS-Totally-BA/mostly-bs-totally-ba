using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.color = Color.blue;
	}
	
    void OnMouseEnter(){
        GetComponent<Renderer>().material.color = Color.red;
    }

    void OnMouseExit(){
        GetComponent<Renderer>().material.color = Color.blue;
    }
}
