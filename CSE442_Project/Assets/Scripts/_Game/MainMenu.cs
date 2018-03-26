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

    void Awake(){
        _gm = GameManager.Instance;
        _gm.OnStateChange += HandleOnStateChange;

        //Debug.Log("Current game state when Awakes: " + _gm.gameState);

        _gm.SetGameState(GameState.MainMenu);
    }

    void Start() {
        //Debug.Log("Current game state when Starts: " + _gm.gameState);
    }
    
    public void NewGame()
    {
        Debug.Log("New Game");
        _gm.StartNewGame();
        //_gm.SetGameState(GameState.Game);
        //SceneManager.LoadScene(1);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    public void escPressed(){
        mMenu.SetActive(true);
        mCredits.SetActive(false);
        mOptions.SetActive(false);
        mInstruct.SetActive(false);
        mStory.SetActive(false);

        //_ui.escMenu.SetActive(true);
        /*
        foreach (Transform escChild in mCanvas.transform)
        {
            if (escChild.name == "MainMenu" || escChild.name == "BG")
                escChild.gameObject.SetActive(true);
            else
                escChild.gameObject.SetActive(false);
        }
        */
    }

    public void HandleOnStateChange(){
        //Debug.Log("Handling state change to: " + _gm.gameState);
        
    }


}
