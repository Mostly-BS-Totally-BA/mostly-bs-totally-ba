using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textManager : Singleton<textManager> {

    bool showGUI = false;                           //variable that determines if text is on screen
    private string text;                             //text that is displayed, can be set in Unity
    private GUIStyle guiStyle = new GUIStyle();


    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void enableText(string label)
    {
        text = label;
        guiStyle.fontSize = 20;                                            //change the font size
        guiStyle.normal.textColor = Color.white;
        showGUI = true;
    }

    public void enableTextRed(string label)
    {
        text = label;
        guiStyle.fontSize = 20;                                            //change the font size
        guiStyle.normal.textColor = Color.red;
        showGUI = true;
    }

    public void disableText(string label)
    {
        if (text == label)
            showGUI = false;
    }

    public void disableTextTransition()
    {
        showGUI = false;
    }

    //Checks if showGUI is true
    private void OnGUI()
    {
        if (showGUI == true)
        {
            GUI.Label(new Rect(10, 10, 500, 20), text, guiStyle);             //places text on screen
        }
    }
}
