using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public float speed = 20.0f;
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.D)) {

			transform.Translate (new Vector3(speed * Time.deltaTime, 0, 0));

		}

		if (Input.GetKey (KeyCode.A)) {

			transform.Translate (new Vector3(-speed * Time.deltaTime, 0, 0));
		}

		if (Input.GetKey (KeyCode.S)) {

			transform.Translate (new Vector3(0,-speed * Time.deltaTime, 0));
		}

		if (Input.GetKey (KeyCode.W)) {

			transform.Translate (new Vector3(0,speed * Time.deltaTime, 0));
		}

	}
}
