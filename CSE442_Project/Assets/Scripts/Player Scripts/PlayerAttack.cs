using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D _enemy)
	{
		GameObject enemy = _enemy.gameObject;
		if (_enemy.gameObject.CompareTag("Enemy")) {
			enemy.GetComponent<Enemy_movement> ().takeDamage (50);
		}

	}
}

