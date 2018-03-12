using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManageLVL1 : MonoBehaviour
{

    public TextAsset textFile;
    public GameObject textBox;

    public Text theText;
    public Player_Movement player;
    public Platino_speech_lvl1 platino;

    public string[] lines;
    public int currentLine;
    public int endLine;

    private void Start()
    {
        lines = (textFile.text.Split('\n'));
        endLine = lines.Length - 1;
    }

    private void Update()
    {
        theText.text = lines[currentLine];

        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentLine++;
            if (currentLine > endLine)
            {
                DisableText();
            }
        }
    }

    public void EnableText()
    {
        textBox.SetActive(true);
        player.canMove = false;
    }

    public void DisableText()
    {
        textBox.SetActive(false);
        player.canMove = true;
        platino.Disapper();
    }
}