using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager> //MonoBehaviour //
{
    protected UIManager() { }

    [SerializeField]
    private Sprite[] lives;
    [SerializeField]
    private Image livesImageDisplay;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameObject curCanvas;
    [SerializeField]
    private GameObject escMenu;
    [SerializeField]
    private GameObject newLevel;
    private GameObject hud;

    //public UIManager UIManager;
    private GameManager _gm = null;
    private UIManager _ui;


    void Awake()
    {
        Debug.Log("UI Awake ");
        _gm = GameManager.Instance;
        Debug.Log("UIM1: " + _gm.gameState);
        if (_gm.gameState != GameState.MainMenu && _gm.gameState != GameState.NullState)
        {
            Debug.Log("UIM2: " + _gm.gameState);
            //curCanvas = GameObject.Find("Canvas");
            _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
            //_ui.escMenu = GameObject.Find("Canvas").transform.Find("PauseMenu").gameObject;
            //_ui.newLevel = curCanvas.transform.Find("NewLevel").gameObject;
            //_ui.escMenu = curCanvas.transform.GetChild("NewLevel").gameObject;
            //_ui = Canvas.Instance;
        }

    }

	private void Update()
	{
        //UpdateScore();
        //UpdateLives();
	}

	private void Start()
	{
        Debug.Log("UI Start ");
        _gm = GameManager.Instance;
        Debug.Log("UIM3: " + _gm.gameState);
        if (_gm.gameState != GameState.MainMenu && _gm.gameState != GameState.NullState)
        {
            Debug.Log("UIM4: " + _gm.gameState);
            //curCanvas = GameObject.Find("Canvas");
            _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
            //_ui.hud = GameObject.Find("Canvas").transform.Find("HUD").gameObject;
            //_ui.escMenu = GameObject.Find("Canvas").transform.Find("PauseMenu").gameObject;
            //_ui.newLevel = GameObject.Find("Canvas").transform.Find("NewLevel").gameObject;
            //_ui.newLevel = curCanvas.transform.Find("NewLevel").gameObject;
            //_ui.escMenu = curCanvas.transform.GetChild("NewLevel").gameObject;
            //_ui = UIManager.Instance;
        }
        Debug.Log("UI Start Sore: " + _gm.Score);
        UpdateScore();
        UpdateLives();
	}

	public void UpdateLives()
    {
        //_ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        //_gm = GameManager.Instance;
        //Debug.Log("Lives: " + _gm.LivesCount);

        if (_gm.gameState == GameState.Game)
            _ui.livesImageDisplay.sprite = lives[_gm.LivesCount];
    }

    public void UpdateScore()
    {
        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gm = GameManager.Instance;
        Debug.Log("Score1");
        if (_gm.gameState == GameState.Game){
            Debug.Log("Score2: " + _gm.Score);
            //_ui.hud = GameObject.Find("Canvas").transform.Find("HUD").gameObject;
            //_ui.hud.transform.Find("Score_text").GetComponent<Text>.scoreText = "Score: " + _gm.Score;
            //GameObject st = GameObject.Find("HUD").transform.Find("Score_text").gameObject;
            //GameObject st = _ui.hud.transform.Find("Score_text").gameObject;
            //st.GetComponent<TextMesh>().text = "Score: " + _gm.Score;;
            //st.guiText = "Score: " + _gm.Score;
            //Text scoreT = st.GetComponent<Text>;
            _ui.scoreText.text = "Score: " + _gm.Score;
        }
    }

    //1.0 - real, 0.5 - slow mo
    public void ShowEscMenu() {
        //curCanvas.SetActive(true);

        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        _ui.newLevel = GameObject.Find("Canvas").transform.Find("NewLevel").gameObject;
        _ui.escMenu.SetActive(true);
    }

    public void HideEscMenu() {
        //curCanvas.SetActive(false);
        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        _ui.newLevel = GameObject.Find("Canvas").transform.Find("NewLevel").gameObject;
        _ui.escMenu.SetActive(false);
    }

    public void SetLevelTransition(bool show)
    {
        //_ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        //Debug.Log("NL1: " + _ui.newLevel.activeSelf);
        //curCanvas.SetActive(show);
        Debug.Log("SLT1: " + show);
        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        Debug.Log("SLT2: " + show);
        _ui.newLevel = GameObject.Find("Canvas").transform.Find("NewLevel").gameObject;
        Debug.Log("SLT3: " + show);
        _ui.newLevel.SetActive(show);
        //Debug.Log("NL2: " + _ui.newLevel.activeSelf);
    }

    public bool GetActiveNL(){
        //_ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        return _ui.newLevel.activeSelf;
    }
}
