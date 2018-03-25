using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    private GameManager _gm;

    public void ReturnToGame(){
        //Debug.Log("Esc Pressed");
        _gm = GameManager.Instance;
        _gm.EscPressed();
        //Debug.Log("State: " + _gm.gameState);
    }

    public void QuitGame(){
        _gm = GameManager.Instance;
        _gm.SetGameState(GameState.GameOver);
        _gm.GameOver();
    }
}
