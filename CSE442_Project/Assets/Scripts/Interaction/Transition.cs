using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    private GameManager _gm = null;

    public void RunInteraction()
    {
        _gm = GameManager.Instance;
        Debug.Log("RI1: " + _gm.gameState);
        if (_gm.gameState == GameState.Game){
            Debug.Log("RI2: " + _gm.gameState);
            _gm.NextLevelTransition();            
            Debug.Log("RI3: " + _gm.gameState);
        }

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
