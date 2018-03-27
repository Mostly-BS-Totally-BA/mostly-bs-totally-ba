using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { NullState, Intro, MainMenu, Game, Paused, PlayerDead, GameOver, LevelTransition }
public delegate void OnStateChangeHandler();


public class GameManager : Singleton<GameManager>
{
    private static GameManager _gm = null;
    public event OnStateChangeHandler OnStateChange;
    public GameState gameState { get; private set; }
    protected GameManager() { }
    //public bool gameOver { get; private set; }


    public int LivesCount { get; private set; }
    [SerializeField]
    private int _livesMax = 5;
    public int Score { get; private set; }
    public int Level { get; private set; }

    private float timeCount = 2.0f;

    public UIManager UIManager;
    private UIManager _ui;
    private MainMenu _mm;

    public void SetGameState(GameState gameState){
        this.gameState = gameState;
        if (OnStateChange!=null){
            OnStateChange();
        }
    }

	void Update()
	{
        if (Input.GetKeyDown(KeyCode.Escape)) { _gm.EscPressed(); }
        _gm = GameManager.Instance;
        PlayerDead();
        GameOver();
	}

    public void StartNewGame(){
        //_ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _gm = GameManager.Instance;
        //_gm.SetGameState(GameState.Game);
        _gm.LivesCount = 5;
        _gm.Level = 1;
        _gm.Score = 0;
        timeCount = 2.0f;
        _gm.StartLevel();
    }

    public void StartLevel()
    {
        _gm = GameManager.Instance;
        //if (_gm.Level > 1) { _ui.SetLevelTransition(false); } //if (_gm.gameState == GameState.LevelTransition) { }
        _gm.SetGameState(GameState.Game);
        SceneManager.LoadScene(_gm.Level);
        if (_gm.Level > 1) {
            Debug.Log("StartLevel");
            _ui = GameObject.Find("HUD").GetComponent<UIManager>();
            _ui.UpdateScore();
            _ui.UpdateLives();
            //{ _ui.SetLevelTransition(false); }
        }
    }

    public void SetLevel(int level)
    {
        _gm = GameManager.Instance;
        _gm.Level = level;
    }

    public void NextLevelTransition()
    {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _gm = GameManager.Instance;
        _gm.SetGameState(GameState.LevelTransition);
        SetLevel(_gm.Level += 1);
        _ui.SetLevelTransition(true);
    }


    public void ScoreDecrease(int score)
    {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _gm.Score -= score;
        _ui.UpdateScore();
    }

    public void ScoreIncrease(int score)
    {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _gm.Score += score;
        _ui.UpdateScore();
    }

    public void LivesDecrease(int lives)
    {
        int newLives = _gm.LivesCount - lives;
        if (newLives < 0){
            newLives = 0;
            _gm.SetGameState(GameState.PlayerDead);
            PlayerDead();
        }
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _gm.LivesCount = newLives;
        _ui.UpdateLives();
    }

    public void LivesIncrease(int lives)
    {
        int newLives = _gm.LivesCount + lives;
        if (newLives > _livesMax)
            newLives = _livesMax;
        if (_gm.LivesCount != newLives){
            _ui = GameObject.Find("HUD").GetComponent<UIManager>();
            _gm.LivesCount = newLives;
            _ui.UpdateLives();
        }
    }

    public void endGame()
    {
        _gm.SetGameState(GameState.PlayerDead);
        PlayerDead();
    }

    public void EscPressed(){
        Debug.Log("ESC1");
        if (_gm.gameState == GameState.Game || _gm.gameState == GameState.Paused){
            _ui = GameObject.Find("HUD").GetComponent<UIManager>();
            if (_gm.gameState == GameState.Game)
            {
                Debug.Log("ESC2 " + _gm.gameState);
                _gm.SetGameState(GameState.Paused);
                _ui.ShowEscMenu();
            }
            else if (_gm.gameState == GameState.Paused)
            {
                Debug.Log("ESC3: " + _gm.gameState);
                _gm.SetGameState(GameState.Game);
                _ui.HideEscMenu();
            }
            _gm.PauseGame();
        } else if (_gm.gameState == GameState.MainMenu){
            _mm = GameObject.Find("Canvas").GetComponent<MainMenu>();
            _mm.escPressed();
        }
    }

    public void PauseGame(){
        if (_gm.gameState == GameState.Paused) {
            //Time.timeScale = 0;
        }
        if (_gm.gameState == GameState.Game) {
            //Time.timeScale = 1;
        }
    }

    public void PlayerDead(){
        if (_gm.gameState == GameState.PlayerDead){
            //Time.timeScale = 0;
            //call player dead animation
            timeCount -= Time.deltaTime;

            if (timeCount <= 0){
                timeCount = 2f;
                _gm.gameState = GameState.GameOver;
            }
        }
    }

    public void GameOver()
    {
        if (_gm.gameState == GameState.GameOver)
        {
            _ui = GameObject.Find("HUD").GetComponent<UIManager>();
            _ui.GameOver();
        }
    }
}
