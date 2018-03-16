using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { NullState, Intro, MainMenu, Game }
public delegate void OnStateChangeHandler();


public class GameManager
{
    private static GameManager _instance = null;
    public event OnStateChangeHandler OnStateChange;
    public GameState gameState { get; private set; }
    protected GameManager() { }

    private UIManager _uiManager;
    private bool _gameRunning = false;
    private bool _gamePaused = false;

    public int playerLives = 5;

    public static GameManager Instance{
        get{
            if (_instance == null){
                _instance = new GameManager();
            }
            return _instance;
        }
    }

    public void SetGameState(GameState gameState){
        this.gameState = gameState;
        if (OnStateChange!=null){
            OnStateChange();
        }
    }


    //check/set in Player script
    //GameManager.Instance.isDead = false;
    //GameManager.Instance.Score;
    public int Score { get; set; }
    public bool IsDead { get; set; }

	void Awake()
	{       
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager != null)
        {
            _uiManager.UpdateLives(playerLives);
        }
	}

	void Start()
	{
        Score = 10;
	}

	void Update()
	{
        if (_gameRunning == true )
        {
            if (Input.GetKeyDown(KeyCode.Escape)){
                if (_gamePaused == false){
                    _gamePaused = true;
                    _uiManager.HideEscMenu();
                }
                else{
                    _gamePaused = false;
                    _uiManager.ShowEscMenu();
                }
                    
            }

        }
	}



}
