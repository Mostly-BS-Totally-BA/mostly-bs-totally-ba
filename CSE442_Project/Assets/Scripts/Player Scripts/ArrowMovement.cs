using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour {

	public int damage;
	void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log("Object: " + collider.gameObject);
		if (collider.gameObject.tag == "Player" || collider.gameObject.tag == "Arrow" || collider.gameObject.tag == "Puzzle_Trigger" || collider.isTrigger) {
			
		} else if (collider.gameObject.tag == "Enemy" && !collider.isTrigger) {
			collider.SendMessage ("takeDamage", damage);
			Destroy (gameObject);
		} else {
			Destroy (gameObject);
		}
	}
}
