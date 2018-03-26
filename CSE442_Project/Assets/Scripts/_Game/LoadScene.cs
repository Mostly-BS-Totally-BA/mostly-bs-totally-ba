using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour {

    //public UIManager UIManager;
    private UIManager _ui;

	// Use this for initialization
	void Start () {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _ui.UpdateLives();
        _ui.UpdateScore();
	}
}
