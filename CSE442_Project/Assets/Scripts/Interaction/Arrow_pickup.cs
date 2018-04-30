using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_pickup : MonoBehaviour {
	
	public Player_Interact player;
	private GameManager _gm = null;

	public void Start()
	{
		_gm = GameManager.Instance;
	}

	public void RunInteraction()
	{
		_gm.pickup_arrow ();
		Destroy (gameObject);
		Debug.Log ("Arrow Count: " + _gm.arrowCount);
	}
}
