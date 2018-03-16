using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    private static GameManager _instance;
    private UIManager _uiManager;
    private bool _gameRunning = false;
    private bool _gamePaused = false;

    public int playerLives = 5;

    public static GameManager Instance 
    { 
        get
        {
            //create logic to create the instance
            if (_instance == null){
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    //check/set in Player script
    //GameManager.Instance.isDead = false;
    //GameManager.Instance.Score;
    public int Score { get; set; }
    public bool IsDead { get; set; }

	void Awake()
	{
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(gameObject);
        
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
