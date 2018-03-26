using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour //Singleton<UIManager> //
{
    protected UIManager() { }

    [SerializeField]
    private Sprite[] lives;
    [SerializeField]
    private Image livesImageDisplay;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameObject escMenu;

    //public UIManager UIManager;
    private GameManager _gm = null;
    private UIManager _ui;


    void Awake()
    {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        //_ui = UIManager.Instance;
        _gm = GameManager.Instance;
    }

    public void UpdateLives()
    {
        _ui = GameObject.Find("HUD").GetComponent<UIManager>();
        Debug.Log("Lives: ");
        Debug.Log("Lives: " + _gm.LivesCount);

        _ui.livesImageDisplay.sprite = lives[_gm.LivesCount];
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + _gm.Score;
    }

    //1.0 - real, 0.5 - slow mo
    public void ShowEscMenu() {
        activateEscMenu("MainMenu");
    }

    public void HideEscMenu() {
        _ui.escMenu.SetActive(false);
    }


    public void GameOver()
    {
        activateEscMenu("GameOver");
    }

    public void ExitGame()
    {
        _gm.SetGameState(GameState.MainMenu);
        SceneManager.LoadScene(0);
    }

    private void activateEscMenu(string menu){
        _ui.escMenu.SetActive(true);
        foreach (Transform escChild in _ui.escMenu.transform)
        {
            if (escChild.name == menu)
                escChild.gameObject.SetActive(true);
            else
                escChild.gameObject.SetActive(false);
        }
    }
}
