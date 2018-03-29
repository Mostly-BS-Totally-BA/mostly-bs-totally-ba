using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameManager GameManager;
    private GameManager _gm;
    [SerializeField]
    private GameObject mCanvas;
    [SerializeField]
    private GameObject mMenu;
    [SerializeField]
    private GameObject mCredits;
    [SerializeField]
    private GameObject mOptions;
    [SerializeField]
    private GameObject mInstruct;
    [SerializeField]
    private GameObject mStory;

    //Gets GameManager Instance
    //Set game state to mainmenu
    void Awake()
    {
        _gm = GameManager.Instance;
        //_gm.OnStateChange += HandleOnStateChange;
        _gm.SetGameState(GameState.MainMenu);
    }

    //Linked to button to start new game
    public void NewGame()
    {
        Debug.Log("New Game");
        _gm.StartNewGame();
    }

    //Linked to button to quit game
    public void QuitGame()
    {
        Application.Quit();
    }

    //Manual handling of loading main menu while hiding all children
    public void escPressed()
    {
        mMenu.SetActive(true);
        mCredits.SetActive(false);
        mOptions.SetActive(false);
        mInstruct.SetActive(false);
        mStory.SetActive(false);
    }

    public void HandleOnStateChange()
    {
        //Debug.Log("Handling state change to: " + _gm.gameState);

    }
}
