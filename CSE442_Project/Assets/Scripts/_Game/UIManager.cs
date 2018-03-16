using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
    public Sprite[] lives;
    public Image livesImageDisplay;
    public Text scoreText;
    public int score;
    public GameObject escMenu;

    public void UpdateLives(int currentLives)
    {
        livesImageDisplay.sprite = lives[currentLives];
    }

    public void UpdateScore()
    {
        score += 10;

        scoreText.text = "Score: " + score;
    }

    //1.0 - real, 0.5 - slow mo
    public void ShowEscMenu()
    {
        Time.timeScale = 0;
        escMenu.SetActive(true);
    }

    public void HideEscMenu()
    {
        Time.timeScale = 1;
        escMenu.SetActive(false);
    }
	
}
