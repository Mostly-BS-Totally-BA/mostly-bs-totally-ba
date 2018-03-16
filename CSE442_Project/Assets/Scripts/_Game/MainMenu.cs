using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
    public GameManager GameManager;
    private GameManager _gameManager;

    void Awake(){
        _gameManager = GameManager.Instance;
        _gameManager.OnStateChange += HandleOnStateChange;

        Debug.Log("Current game state when Awakes: " + _gameManager.gameState);

        _gameManager.SetGameState(GameState.MainMenu);
    }

    void Start() {
        Debug.Log("Current game state when Starts: " + _gameManager.gameState);
    }
    
    public void NewGame()
    {
        _gameManager.SetGameState(GameState.Game);
        SceneManager.LoadScene(1);
        Debug.Log("Current game state when NewGame: " + _gameManager.gameState);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    public void HandleOnStateChange(){
        Debug.Log("Handling state change to: " + _gameManager.gameState);
        
    }


}
