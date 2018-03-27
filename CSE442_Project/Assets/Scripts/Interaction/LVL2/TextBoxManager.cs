using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script that handles display of Platino monologues
public class TextBoxManager : MonoBehaviour {

    public TextAsset textFile;                          //text file containing monologue lines, set in Unity
    public GameObject textBox;                          //textBox to display the lines, set in Unity

    public Text theText;                                //the line of text to be displayed
    public Player_Movement player;                      //links script to player sprite, set in Unity
    public Platino_Speech platino;                      //links script to platino sprite, set in Unity

    public string[] lines;                              //array of monologue lines
    public int currentLine;                             //initial value set in Unity
    public int endLine;                                 //set in Unity
   
    //Activates when level starts
    private void Start()
    {
        lines = (textFile.text.Split('\n'));           //places individual lines from text file into lines array 
        //endLine = lines.Length - 1;
    }

    //Activates every frame
    private void Update()
    {
        theText.text = lines[currentLine];             //Sets the line being displayed to the current line of the array

        if(Input.GetKeyDown(KeyCode.Return))           //if the player presses the return key ('enter')
        {
            currentLine++;                             //increments current line
            if (currentLine > endLine)
            {
                DisableText();                         //Reached end of monologue, calls DisableText() function
            }
        }        
    }


    //Called in Platino_Speech
    public void EnableText()
    {
        textBox.SetActive(true);                        //activates textBox object (appears on screen)
        player.canMove = false;                         //disable player's ability to move, alters variable within Player_Movement script on player object
    }

    //Disables textBox
    public void DisableText()
    {
        textBox.SetActive(false);                       //deactivates textBox object
        player.canMove = true;                          //allows the player to move again
        platino.Disapper();                             //calls function in Platino_Speech function of platino game object
    }
}
