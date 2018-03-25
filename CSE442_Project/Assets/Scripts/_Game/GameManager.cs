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
    private int _livesMax = 10;
    public int Score { get; private set; }
    public int Level { get; private set; }

    private float timeCount = 2.0f;

    //public UIManager UIManager;
    private UIManager _ui;

    public void SetGameState(GameState gameState){
        this.gameState = gameState;
        if (OnStateChange!=null){
            OnStateChange();
        }
    }

	void Update()
	{
        if (Input.GetKeyDown(KeyCode.Escape)) { _gm.EscPressed(); }
        //if (Input.GetKeyDown(KeyCode.E)) { _gm.EscPressed(); }
        //_gm = GameManager.Instance;
        //if (timeCount <= 0){
            PlayerDead();
            GameOver();            
        //}
        Debug.Log("GM UP ");
        //Debug.Log("TimeUp: " + timeCount);
	}

    public void StartNewGame(){
        _ui = GameObject.Find("UIManager").GetComponent<UIManager>();
        _gm = GameManager.Instance;
        _gm.LivesCount = 4;
        _gm.Level = 1;
        _gm.timeCount = 2.0f;
        _gm.StartLevel();
    }

    public void StartLevel()
    {
        _ui = GameObject.Find("UIManager").GetComponent<UIManager>();
        _gm = GameManager.Instance;
        Debug.Log("State1: " + _gm.gameState);
        //Debug.Log("NLA: " + _ui.GetActiveNL());
        if (_gm.Level > 1) { _ui.SetLevelTransition(false); } //if (_gm.gameState == GameState.LevelTransition) { }
        Debug.Log("State2: " + _gm.gameState);
        //Debug.Log("NLB: " + _ui.GetActiveNL());
        _gm.SetGameState(GameState.Game);
        Debug.Log("State3: " + _gm.gameState);
        //Debug.Log("NLC: " + _ui.newLevel.activeSelf);
        SceneManager.LoadScene(_gm.Level);
        //Debug.Log("NLD: " + _ui.newLevel.activeSelf);
        if (_gm.Level > 1) { _ui.SetLevelTransition(false); }
        Debug.Log("StartLevel");
        //Debug.Log("NLE: " + _ui.newLevel.activeSelf);
        //_ui = GameObject.Find("UIManager").GetComponent<UIManager>();
        //Debug.Log("State: " + _gm.gameState);
        //Debug.Log("Lives: " + _gm.LivesCount);
        //Debug.Log("Level: " + _gm.Level);
        //_ui.UpdateScore();
        //Debug.Log("Start2");
        //_ui.UpdateLives();
    }

    public void SetLevel(int level){
        _gm = GameManager.Instance;
        _gm.Level = level;
    }

    public void NextLevelTransition()
    {
        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gm = GameManager.Instance;
        Debug.Log("RIA1: " + _gm.gameState);
        _gm.SetGameState(GameState.LevelTransition);
        Debug.Log("RIA2: " + _gm.gameState);
        SetLevel(_gm.Level += 1);
        Debug.Log("RIA3: " + _gm.gameState);
        //Debug.Log("Level: " + _gm.Level);
        _ui.SetLevelTransition(true);
        Debug.Log("RIA4: " + _gm.gameState);
    }

    public void ScoreDecrease(int score)
    {
        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gm = GameManager.Instance;
        _gm.Score -= score;
        _ui.UpdateScore();
    }

    public void ScoreIncrease(int score)
    {
        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gm = GameManager.Instance;
        _gm.Score += score;
        _ui.UpdateScore();
    }

    public void LivesDecrease(int lives)
    {
        _gm = GameManager.Instance;
        int newLives = _gm.LivesCount - lives;
        if (newLives <= 0){
            _gm.SetGameState(GameState.PlayerDead);
            PlayerDead();
        }
        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gm.LivesCount = newLives;
        _ui.UpdateLives();
    }

    public void LivesIncrease(int lives)
    {
        _gm = GameManager.Instance;
        int newLives = _gm.LivesCount + lives;
        if (newLives > _livesMax)
            newLives = _livesMax;
        if (_gm.LivesCount != newLives){
            _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
            _gm.LivesCount = newLives;
            _ui.UpdateLives();
        }
    }

    public void EscPressed(){
        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gm = GameManager.Instance;
        Debug.Log("StateA: " + _gm.gameState);
        if (_gm.gameState == GameState.Game || _gm.gameState == GameState.Paused)
        {
            if (_gm.gameState == GameState.Game)
            {
                _gm.SetGameState(GameState.Paused);
                _ui.ShowEscMenu();
            }
            else if (_gm.gameState == GameState.Paused)
            {
                _gm.SetGameState(GameState.Game);
                _ui.HideEscMenu();
            }
            _gm.PauseGame();
        }
        else if (_gm.gameState == GameState.LevelTransition)
        {
            _ui.SetLevelTransition(false);
            _gm.StartLevel();
        }
        Debug.Log("StateB: " + _gm.gameState);
    }

    public void PauseGame(){
        _gm = GameManager.Instance;
        if (_gm.gameState == GameState.Paused) {
            //Time.timeScale = 0;
        }
        if (_gm.gameState == GameState.Game) {
            //Time.timeScale = 1;
        }
    }

    public void PlayerDead(){
        _gm = GameManager.Instance;
        if (_gm.gameState == GameState.PlayerDead){
            //Time.timeScale = 0;
            //call player dead animation
            timeCount -= Time.deltaTime;
            Debug.Log("Time2: " + timeCount);

            if (timeCount <= 0){
                timeCount = 2f;
                _gm.SetGameState(GameState.GameOver);
                _gm.GameOver();
            }
        }
    }

    public void GameOver()
    {
        _gm = GameManager.Instance;
        Debug.Log("StateGO1: " + _gm.gameState);
        if (_gm.gameState == GameState.GameOver)
        {
            timeCount -= Time.deltaTime;
            Debug.Log("Time1: " + timeCount);

            if (timeCount <= 0)
            {
                timeCount = 2f;
                Debug.Log("StateGO2: " + _gm.gameState);
                _gm.SetGameState(GameState.MainMenu);
                SceneManager.LoadScene(0);
            }
        }
    }
}
