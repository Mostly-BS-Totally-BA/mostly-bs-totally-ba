using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
    public GameManager GameManager;
    private GameManager _gm;

    void Awake(){


        //Debug.Log("Current game state when Awakes: " + _gm.gameState);


    }

    void Start() {
        _gm = GameManager.Instance;
        _gm.OnStateChange += HandleOnStateChange;

        //Debug.Log("Current game state when Starts: " + _gm.gameState);

        //Debug.Log("StateAA: " + _gm.gameState);
        if (_gm.gameState == GameState.NullState)
            _gm.SetGameState(GameState.MainMenu);
        //Debug.Log("StateAB: " + _gm.gameState);
    }
    
    public void NewGame()
    {
        //Debug.Log("New Game");
        _gm.StartNewGame();
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    public void HandleOnStateChange(){
        //Debug.Log("Handling state change to: " + _gm.gameState);
        
    }

    public void StartLevel()
    {
        //Debug.Log("Next Level");
        _gm.StartLevel();
    }
}
