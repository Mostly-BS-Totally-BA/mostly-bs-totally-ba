using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentEnding : MonoBehaviour
{
    private GUIStyle guiStyle = new GUIStyle();
    bool showGUI = false;
    float timer = 3;                                           //timer
    GameManager _gm = null;
	
	
	// Update is called once per frame
	void Update ()
    {
		if(gameObject.activeInHierarchy)
        {
            showGUI = true;
            _gm = GameManager.Instance;
            _gm.GameOver();
            StartCoroutine(Wait(timer));
        }
	}

    //Checks if showGUI is true
    private void OnGUI()
    {
        if (showGUI == true)
        {
            guiStyle.fontSize = 30;                                            //change the font size
            guiStyle.normal.textColor = Color.white;
            GUI.Label(new Rect(10, 10, 500, 20), "This ends the beta!", guiStyle);             //places text on screen
        }
    }

    //Coroutine that causes script to wait before resuming 
    IEnumerator Wait(float timer)
    {
        yield return new WaitForSecondsRealtime(timer);        //Waits for seconds indicated by timer
        _gm = GameManager.Instance;
        _gm.KillPlayer();
    }
}
