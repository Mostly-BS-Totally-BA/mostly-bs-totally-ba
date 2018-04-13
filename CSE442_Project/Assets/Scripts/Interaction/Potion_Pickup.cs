using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion_Pickup : MonoBehaviour {

	public Player_Interact player;
	private GameManager _gm = null;

	public void Start()
	{
		_gm = GameManager.Instance;
	}
		
	public void RunInteraction()
	{
		_gm.pickup_potion ();
		Destroy (gameObject);
		Debug.Log ("Potion Count: " + _gm.potionCount);
	}
}
