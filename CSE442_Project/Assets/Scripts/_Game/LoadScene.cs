using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{

    private UIManager _ui;

    //Refreshes HUD for current level
    void Start()
    {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _ui.UpdateLives();
        _ui.UpdateScore();
    }
}
