﻿using System.Collections;
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

		//If the game object is an enemy send that enemy damage to take
		if (_enemy.gameObject.CompareTag("Enemy") && !_enemy.isTrigger) {
			enemy.SendMessage("takeDamage", 50);
            AudioManager.Instance.PlayAudio(AudioName.PlayerAttack);
		}

	}
}

