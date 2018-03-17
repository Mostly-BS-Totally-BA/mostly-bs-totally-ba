using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { NullState, Intro, MainMenu, Game, Paused }
public delegate void OnStateChangeHandler();


public class GameManager : Singleton<GameManager>
{
    private static GameManager _gm = null;
    public event OnStateChangeHandler OnStateChange;
    public GameState gameState { get; private set; }
    protected GameManager() { }
    public bool gamePaused { get; private set; }
    public int playerLives = 5;

    public UIManager UIManager;
    private UIManager _ui = null;

    public void SetGameState(GameState gameState){
        this.gameState = gameState;
        if (OnStateChange!=null){
            OnStateChange();
        }
    }

    public int Score { get; set; }
    public bool IsDead { get; set; }

	void Awake()
	{
        _gm = GameManager.Instance;
	}

	void Update()
	{
        if (Input.GetKeyDown(KeyCode.Escape)) { _gm.EscPressed(); }
	}

    public void EscPressed(){
        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        Debug.Log("Escape Key - state: " + _gm.gameState);
        if (_gm.gameState == GameState.Game) {
            Debug.Log("Escape Key0");
            _gm.SetGameState(GameState.Paused);
            _ui.ShowEscMenu();
        }
        else {
            Debug.Log("Escape Key1");
            _gm.SetGameState(GameState.Game);
            _ui.HideEscMenu();
        }
        _gm.PauseGame();
    }

    public void PauseGame(){
        Debug.Log("PauseGame - state: " + _gm.gameState);
        if (_gm.gameState == GameState.Paused) {
            Debug.Log("Paused0");
            Time.timeScale = 0;
        }
        if (_gm.gameState == GameState.Game) {
            Debug.Log("Paused1");
            Time.timeScale = 1;
        }
    }
}
