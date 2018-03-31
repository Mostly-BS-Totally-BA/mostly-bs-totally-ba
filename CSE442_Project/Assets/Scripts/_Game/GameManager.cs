using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { NullState, Intro, MainMenu, Game, Paused, PlayerDead, GameOver, LevelTransition }
public delegate void OnStateChangeHandler();

/* Purpose of the GameManager is to act as a central hub and maintain the states the 
 * game is in at all time. This hub connects attacks and kills to the HUD elements, 
 * while also connecting to the main and pause menus. The maintaining of the game state
 * is needed to keep certain actions from occur during unintended parts of the running 
 * game. 
 * The GameManager is called from the loading of the MainMenu, and is maintained as a
 * Singletone rather than a MonoBehavior. This is to keep a single instance of the code
 * running at all times which is then called rather than using GameObject.Find.
 */

public class GameManager : Singleton<GameManager>
{
    private static GameManager _gm = null;
    public event OnStateChangeHandler OnStateChange;
    public GameState gameState { get; private set; }
    protected GameManager() { }

    public int Level { get; private set; }
    public int livesMax { get; private set; }
    public int LivesCount { get; private set; }
    public int Score { get; private set; }
    public float playerSpeedNorm { get; private set; }
    public float playerSpeed { get; private set; }
    public float playerAttackSpeedNorm { get; private set; }
    public float playerAttackSpeed { get; private set; }

    private float timeCount = 2.0f;

    //public UIManager UIManager;
    private UIManager _ui;
    private MainMenu _mm;
    private Player_Movement _pm;

    //Changes the current Game State
    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        if (OnStateChange != null)
        {
            OnStateChange();
        }
    }

    //Repeated checks of Escape being called. Also checks if player dead or game over
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { _gm.EscPressed(); }
        _gm = GameManager.Instance;
        PlayerDead();
        GameOver();
    }

    //Initializes default properties for starting a new game
    public void StartNewGame()
    {
        _gm = GameManager.Instance;
        _gm.livesMax = 4;
        _gm.playerSpeedNorm = 2.25f;
        _gm.playerAttackSpeedNorm = 1.0f;

        _gm.LivesCount = _gm.livesMax;
        _gm.playerSpeed = _gm.playerSpeedNorm;
        _gm.playerAttackSpeed = _gm.playerAttackSpeedNorm;

        _gm.Level = 1;
        _gm.Score = 0;
        timeCount = 2.0f;
        _gm.StartLevel();
    }

    //Called from SaveLoad.cs to set game values
    public void LoadGame(Save save){
        _gm.playerSpeedNorm = save.playerSpeedNorm;
        _gm.playerSpeed = save.playerSpeed;
        _gm.playerAttackSpeedNorm = save.playerAttackSpeedNorm;
        _gm.playerAttackSpeed = save.playerAttackSpeed;
        _gm.Level = save.level;
        _gm.livesMax = save.livesmax;
        _gm.LivesCount = save.lives;
        _gm.Score = save.score;
    }

    //Used to begin currently set level, including for new game or for next level
    //Loads scene found in Level. If not new game, makes sure HUD updates
    public void StartLevel()
    {
        _gm = GameManager.Instance;
        _gm.SetGameState(GameState.Game);
        SceneManager.LoadScene(_gm.Level);
/*        if (_gm.Level > 1)
        {
            Debug.Log("StartLevel");
            _ui = GameObject.Find("HUD").GetComponent<UIManager>();
            _ui.UpdateScore();
            _ui.UpdateLives();
        }*/
    }

    //Sets value for Level
    public void SetLevel(int level)
    {
        _gm = GameManager.Instance;
        _gm.Level = level;
    }

    //Triggers transition phase that brings up dialog for next level
    public void NextLevelTransition()
    {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _gm = GameManager.Instance;
        _gm.SetGameState(GameState.LevelTransition);
        SetLevel(_gm.Level += 1);
        _ui.SetLevelTransition(true); //_ui.StartLevelTransition();
    }

    //Stat boost for health
    public void StatBoostHealthInc()
    {
        _gm = GameManager.Instance;
        _gm.livesMax += 5;
        _gm.LivesCount = _gm.livesMax;
    }

    //Stat boost for run speed
    public void StatBoostRunInc()
    {
        _gm = GameManager.Instance;
        _gm.playerSpeedNorm += 1f;
        _gm.playerSpeed = _gm.playerSpeedNorm;
    }

    //Stat boost for attack speed
    public void StatBoostAttackInc()
    {
        _gm = GameManager.Instance;
        _gm.playerAttackSpeedNorm += 0.75f;
        _gm.playerAttackSpeed = _gm.playerAttackSpeedNorm;
    }

    //Updates Score with positive or negative value
    public void UpdateScore(int score)
    {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _gm.Score += score;
        _ui.UpdateScore();
    }

    //Decreases LivesCount
    //If new level < 0, PlayerDead is triggered
    public void LivesDecrease(int lives)
    {
        int newLives = _gm.LivesCount - lives;
        if (newLives < 0)
        {
            newLives = 0;
            _gm.KillPlayer();
        }
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _gm.LivesCount = newLives;
        _ui.UpdateLives();
    }

    //Lives Increase
    //Limits to currently set livesMax value
    public void LivesIncrease(int lives)
    {
        int newLives = _gm.LivesCount + lives;
        if (newLives > livesMax)
            newLives = livesMax;
        if (_gm.LivesCount != newLives)
        {
            _ui = GameObject.Find("HUD").GetComponent<UIManager>();
            _gm.LivesCount = newLives;
            _ui.UpdateLives();
        }
    }

    //Handles action when escape key pressed during different game states
    //During Game or Paused states, will swap states to pause or resume
    //Used in mainmenu to return to main menu
    public void EscPressed()
    {
        Debug.Log("ESC1");
        if (_gm.gameState == GameState.Game || _gm.gameState == GameState.Paused)
        {
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
        }
        else if (_gm.gameState == GameState.MainMenu)
        {
            _mm = GameObject.Find("Canvas").GetComponent<MainMenu>();
            _mm.escPressed();
        }
    }

    public void KillPlayer()
    {
        _gm.SetGameState(GameState.PlayerDead);
        //_pm = GameObject.Find("PlayerSprite").GetComponent<Player_Movement>();
        //_pm.death();
        PlayerDead();
    }

    //Switches to PlayerDead state
    //Currently just freezes game for 2 seconds before triggering gameover
    public void PlayerDead()
    {
        _gm = GameManager.Instance;
        if (_gm.gameState == GameState.PlayerDead)
        {
            _gm.timeCount -= Time.deltaTime;
            if (_gm.timeCount <= 0)
            {
                _gm.timeCount = 2f;
                _gm.gameState = GameState.GameOver;
            }
        }
    }

    //Switches to GameOver state
    //Calls UI process for GameOver state
    public void GameOver()
    {
        _gm = GameManager.Instance;
        if (_gm.gameState == GameState.GameOver)
        {
            _ui = GameObject.Find("HUD").GetComponent<UIManager>();
            _ui.GameOver();
        }
    }

}
