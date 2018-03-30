using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    private GameManager _gm;
    private UIManager _ui;

    //Linked to return to game button
    public void ReturnToGame()
    {
        Debug.Log("Esc Pressed");
        _gm = GameManager.Instance;
        _gm.EscPressed();
        Debug.Log("State: " + _gm.gameState);
    }

    //Linked to quit game button
    public void QuitGame()
    {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _gm = GameManager.Instance;
        _gm.SetGameState(GameState.GameOver);
        _ui.ExitGame();
    }

    public void SaveGame(){
        SaveLoad.SaveGame();
        _gm = GameManager.Instance;
        _gm.EscPressed();
    }
}
