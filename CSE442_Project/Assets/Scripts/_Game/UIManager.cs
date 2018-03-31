
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* Te UI Manager is mostly used for the HUD updates, though also handles some 
 * menu functions.
 */


public class UIManager : MonoBehaviour //Singleton<UIManager> //
{
    protected UIManager() { }

    [SerializeField]
    public Sprite[] lives;
    [SerializeField]
    private Image livesImageDisplay;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameObject escMenu;
    [SerializeField]
    private GameObject newLevel;

    private GameManager _gm = null;
    private UIManager _ui;

    //Grabs GameManager instance and UIManager component
    void Awake()
    {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _gm = GameManager.Instance;
    }

    //Refresh HUD
    private void Start()
    {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _ui.UpdateLives();
        _ui.UpdateScore();
    }

    //Set lives sprites to match current LivesCount value
    public void UpdateLives()
    {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        int livesCount = _gm.LivesCount;
        if (livesCount > 4)
            livesCount = 4;
        Debug.Log("lives: " + livesCount);
        _ui.livesImageDisplay.sprite = lives[livesCount];
    }

    //Update text to match current Score value
    public void UpdateScore()
    {
        Debug.Log("Score: " + _gm.Score);
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _ui.scoreText.text = "Score: " + _gm.Score;
    }

    //Loads pause menu
    public void ShowEscMenu()
    {
        activateEscMenu("MainMenu");
    }

    //Hides pause menu
    public void HideEscMenu()
    {
        _ui.escMenu.SetActive(false);
    }

    //Displays dialog for tranistion between levels
    public void SetLevelTransition(bool show)
    {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _ui.newLevel.SetActive(show);
    }

    public void StatBoostPickHealth()
    {
        _gm.StatBoostHealthInc();
        StartLevel();
    }

    public void StatBoostPickRun()
    {
        _gm.StatBoostRunInc();
        StartLevel();
    }

    public void StatBoostPickAttack()
    {
        _gm.StatBoostAttackInc();
        StartLevel();
    }

    //Calls to begin currently set level
    public void StartLevel()
    {
        _gm.StartLevel();
    }

    //Loads gameover menu
    public void GameOver()
    {
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
        _ui.escMenu.SetActive(true);
        foreach (Transform escChild in _ui.escMenu.transform)
        {
            if (escChild.name == menu)
                escChild.gameObject.SetActive(true);
            else
                escChild.gameObject.SetActive(false);
        }
    }

    private void activateStory(string menu)
    {
        //_ui.escMenu.SetActive(true);
        //_ui = GameObject.Find("HUD").GetComponent<UIManager>();
        _ui = GameObject.FindWithTag("HUD").GetComponent<UIManager>();
        _ui.newLevel.SetActive(true);
        foreach (Transform escChild in _ui.newLevel.transform)
        {
            Debug.Log("Tag: " + escChild.tag);
            if (escChild.name == menu && escChild.tag == "NewLevel")
                escChild.gameObject.SetActive(true);
            else
                escChild.gameObject.SetActive(false);
        }
    }
}
