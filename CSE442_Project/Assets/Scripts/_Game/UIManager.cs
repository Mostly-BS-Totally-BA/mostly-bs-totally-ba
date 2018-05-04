
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

/* Te UI Manager is mostly used for the HUD updates, though also handles some 
 * menu functions.
 */


public class UIManager : MonoBehaviour //Singleton<UIManager> //
{
    protected UIManager() { }

    [SerializeField]
    public Sprite[] lives;
    [SerializeField]
    private GameObject livesImg;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text potText;
    [SerializeField]
	private Text arrowText;
	[SerializeField]
    private GameObject runImg;
    [SerializeField]
    private GameObject attackImg;
    [SerializeField]
    private GameObject escMenu;
    [SerializeField]
    private GameObject statBoost;
    [SerializeField]
    private GameObject newLevel;
    [SerializeField]
    private GameObject endGame;



    private GameManager _gm = null;
    private UIManager _ui;
    private MusicManager _mmgr;
    private Volume _vol;

    //Grabs GameManager instance and UIManager component
    void Awake()
    {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _gm = GameManager.Instance;
    }

    //Refresh HUD
    private void Start()
    {
        //_vol = GameObject.Find("OptionsMenu").GetComponent<Volume>();
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _ui.UpdateLives();
        _ui.UpdateScore();
        _ui.UpdateHPPots();
		_ui.UpdateArrows();
        _ui.UpdateHUDAttackSpeed();
        _ui.UpdateHUDRunSpeed();
        _mmgr = MusicManager.Instance;

    }

    //Set lives sprites to match current LivesCount value
    public void UpdateLives()
    {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        int livesCount = _gm.LivesCount;
        if (livesCount > 44)
            livesCount = 44;
        activateLives(livesCount, _gm.livesMax);
    }

    //Update text to match current Score value
    public void UpdateScore()
    {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _ui.scoreText.text = "Score: " + _gm.Score;
    }


    //Update text to match current Score value
    public void UpdateHPPots()
    {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _ui.potText.text = "" + _gm.potionCount;
    }

	public void UpdateArrows()
	{
		_ui = GameObject.Find("HUD").GetComponent<UIManager>();
		_ui.arrowText.text = "" + _gm.arrowCount;
	}

    //Update text to match current Score value
    public void UpdateHUDAttackSpeed()
    {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        //_ui.attackText.text = "Attack Speed: " + _gm.playerAttackSpeed;
        Debug.Log("Attack Speed: " + _gm.playerAttackSpeed);
        if (_gm.playerAttackSpeed > 1.5f)
            _ui.attackImg.SetActive(true);
        else
            _ui.attackImg.SetActive(false);
    }

    //Update text to match current Score value
    public void UpdateHUDRunSpeed()
    {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        //_ui.runText.text = "Run Speed: " + _gm.playerSpeed;
        Debug.Log("Run Speed: " + _gm.playerSpeed);
        if (_gm.playerSpeed > 2.25f)
            _ui.runImg.SetActive(true);
        else
            _ui.runImg.SetActive(false);
    }

    //Loads pause menu
    public void ShowEscMenu()
    {
        
        //Debug.Log("Show Esc");
        activateEscMenu("MainMenu");
        //_vol = GameObject.Find("OptionsMenu").GetComponent<Volume>();
        //_vol.SetSliders();
    }

    //Hides pause menu
    public void HideEscMenu()
    {
        //Debug.Log("Hide Esc");
        _ui.escMenu.SetActive(false);
    }

    //Displays dialog for tranistion between levels
    public void LoadStatBoost(bool show)
    {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _ui.statBoost.SetActive(show);
    }

    //Displays dialog for tranistion between levels
    public void LoadLevelTransition(bool show)
    {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _ui.newLevel.SetActive(show);
    }

    //Displays dialog for tranistion between levels
    public void LoadEndGame(bool show)
    {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _ui.endGame.SetActive(show);
    }

    //Selection of health for stat boost
    public void StatBoostPickHealth()
    {
        _gm.StatBoostHealthInc();
        LoadStatBoost(false);
        LoadLevelTransition(true); 
    }

    //Selection of run speed for stat boost
    public void StatBoostPickRun()
    {
        _gm.StatBoostRunInc();
        LoadStatBoost(false);
        LoadLevelTransition(true);
    }

    //Selection of attack speed for stat boost
    public void StatBoostPickAttack()
    {
        _gm.StatBoostAttackInc();
        LoadStatBoost(false);
        LoadLevelTransition(true); 
    }

    //Calls to begin currently set level
    public void StartLevel()
    {
        _gm.StartLevel();
    }

    //Loads gameover menu
    public void GameOver()
    {
        _mmgr.StopAudio();
        MusicManager.Instance.PlayAudio(MusicName.End);
        activateEscMenu("GameOver");
    }

    //Handles transition back to main menu
    public void ExitGame()
    {
        _gm.SetGameState(GameState.MainMenu);
        SceneManager.LoadScene(0);
    }

    //Takes in given menu name as menu
    //Sets escMenu to active, and makes sure all children are hidden
    //except for menu value
    private void activateEscMenu(string menu)
    {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _ui.escMenu.SetActive(true);
        foreach (Transform escChild in _ui.escMenu.transform)
        {
            if (escChild.name == menu)
                escChild.gameObject.SetActive(true);
            else
                escChild.gameObject.SetActive(false);
        }
    }

    //To be used for swapping out tranisition stories
    private void activateStory(string menu)
    {
        //_ui.escMenu.SetActive(true);
        //_ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _ui = GameObject.FindWithTag("HUD").GetComponent<UIManager>();
        _ui.newLevel.SetActive(true);
        foreach (Transform escChild in _ui.newLevel.transform)
        {
            //Debug.Log("Tag: " + escChild.tag);
            if (escChild.name == menu && escChild.tag == "NewLevel")
                escChild.gameObject.SetActive(true);
            else
                escChild.gameObject.SetActive(false);
        }
    }

    //To be used for swapping out tranisition stories
    private void activateLives(int livesCount, int livesMax)
    {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();

        double dblMaxShow = livesMax / 4;
        int intMaxShow = (int)Math.Floor(dblMaxShow);
        if (livesMax % 4 != 0){
            intMaxShow += 1;
        }

        double dblHearts = livesCount / 4;
        int hearts = (int)Math.Floor(dblHearts);

        int halflife = livesCount % 4;
        //Debug.Log("Lives: " + livesCount + " - dblHearts: " + dblHearts + " - h: " + hearts +" - dblMaxS: " + dblMaxShow + " - intMaxS: " + intMaxShow + " - hl; " + halflife);

        for (int i = 0; i < 9; i++){
            GameObject kidd = _ui.livesImg.transform.GetChild(i).gameObject;
            if (i < intMaxShow){
                kidd.SetActive(true);
                kidd.GetComponent<Image>().sprite = lives[0];

                if (i < hearts){
                    kidd.GetComponent<Image>().sprite = lives[4];
                } else if (i == hearts){
                    kidd.GetComponent<Image>().sprite = lives[halflife];
                }
            } else {
                kidd.SetActive(false);
            }
        }
    }
}
