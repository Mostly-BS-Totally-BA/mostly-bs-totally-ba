using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    private GameManager _gm = null;

    public void RunInteraction()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        _gm = GameManager.Instance;
        if (_gm.gameState == GameState.Game)
        {
            _gm.NextLevelTransition();
        }
    }
}
