using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    protected UIManager() { }
    public int livesCount { get; private set; }
    private int livesMax = 10;
    [SerializeField]
    private Sprite[] lives;
    [SerializeField]
    private Image livesImageDisplay;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private int score;
    [SerializeField]
    private GameObject escMenu;

    //public UIManager UIManager;
    private GameManager _gm = null;
    private UIManager _ui = null;


    void Awake()
    {
        _ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gm = GameManager.Instance;
    }

    public void LivesDecrease(int lives){
        _ui.livesCount -= lives;
        UpdateLives();
    }

    public void LivesIncrease(int lives){
        _ui.livesCount += lives;
        UpdateLives();
    }

    private void UpdateLives()
    {
        Debug.Log("Lives: " + _ui.livesCount);

        _ui.livesImageDisplay.sprite = lives[livesCount];
    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }

    //1.0 - real, 0.5 - slow mo
    public void ShowEscMenu()
    {
        Debug.Log("ShowEscMenu");
        _ui.escMenu.SetActive(true);
    }

    public void HideEscMenu()
    {
        Debug.Log("HideEscMenu");
        _ui.escMenu.SetActive(false);
    }
	
}
