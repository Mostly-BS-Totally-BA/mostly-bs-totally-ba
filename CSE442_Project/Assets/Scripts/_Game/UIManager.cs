using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        //_ui = UIManager.Instance;
        _gm = GameManager.Instance;
    }

    public void UpdateLives()
    {
        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
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
        _ui.escMenu.SetActive(true);
    }

    public void HideEscMenu() {
        _ui.escMenu.SetActive(false);
    }
}
