# mostly-bs-totally-ba

Team Contract: 
=========
Mostly BS, Totally BA.

Project Name: 
=========
Images of Morphia

Members: 
========
* Daniel Re
* Christian Wilson
* Andrew Forthman
* Arody Deleon

Gitter Badge
==============
[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/MostlyBSTotallyBA/Project_Discussion?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)


Project Videos
===========
Prototype Video:
https://www.youtube.com/watch?v=tOTkq1Pvyuw

Alpha Release Video:
https://www.youtube.com/watch?v=sRCQMmgo13g&feature=youtu.be

Alpha Release Instructions
=========================
Mac
------
1) Go to the releases section here: https://github.com/Mostly-BS-Totally-BA/mostly-bs-totally-ba/releases
2) Download the tar.gz to your computer
3) Unzip the contents
4) Locate the file named "IoM_MacOS.app"
5) Run this file to begin playing

Windows
------------
1) Go to the releases section here: https://github.com/Mostly-BS-Totally-BA/mostly-bs-totally-ba/releases
2) Download the zip to your computer
3) Unzip the contents
4) Locate the file IoM_Windows_Build.zip and unzip this
5) Go into the folder Windows Build
6) Within this folder locate the file named "Images_of_Morphia.exe"
7) Run this file to begin playing

Prototype Instructions
=========================
Mac
------
1) Locate the executable in the CSE442_Project folder
2) Download this to your computer
3) Run the executable to begin playing

Windows
------------
1) Locate the zip file in the CSE442_Project folder
2) Download this to your computer
3) Unzip all contents of the downloaded file
4) Run the executable to begin playing


Minimum Viable Product:
=========================
Overview:
-------------------------
* Game Style: old-school style, 16-bit game - classic 2D top-down 
* Game Type: single player action-adventure game. 
* Distribution Platforms:  Windows and Mac
* IDE / Game Engine: Unity

Gameplay:
-------------------------
* Player Functionality:
	* The player controls a character that will be able to move, attack enemies of different types.
	* The player will have the option to choose between using a melee or ranged attack to defeat enemies.
* Setting:
	* Game is based in a dungeon or tower, with multiple levels going up and/or down.
	* A minimum of 5 levels will exist with the game difficulty increasing for each.
	* These levels will contain different enemies types / themes to prevent the game from feeling redundant. 
* Enemies / Boss:
	* The final level will contain the final game boss that the player needs to defeat in order to beat the game. 
	* The levels will increase in difficulty as the player progresses, with the first level being the easiest and the final boss being the hardest. 
* User Interface:
	* Game opens and loads to a basic menu with options for creating a new game,  loading a saved game, and exiting the game.
	* When the player beats the game, or if the player decides to exit the game, they will be able to do so with an option screen to take them back to the main menu.





Add-Ons
=========
* Each boss fight will have different mechanics. This is to add variety to the game so that bosses feel unique and provide a challenge for the player to overcome.
* Ability to solve puzzles, and interact with objects in game such as opening a chest to find loot.
* Functioning inventory system where you can see items you have picked up throughout the game, and possibly use said items.
* Procedurally generate maps, so that every time a player starts a game it is a never before seen map, this will make memorizing the game maps nearly impossible.
* Provide readable text on the screen that will pop up at various points. Each time it will provide more context to the story of the game so that the player can feel involved in the game world.
* Multiple Player Classes, such as Rogue, Warrior, Wizard who have different weapon/attack functionality.
* Addition of an in game map, to track where the player is and where they have/haven’t been yet.
* save and load an existing game.


User Story:
============
“I want to be able to play an old style game that feels nostalgic, such as The Legend of Zelda. The game should have some basic common functionality, including a user interface, and options to start a new game. Concerning gameplay, the character I am controlling needs to move freely,attack, and defeat enemeies. A level needs to contain a variety of basic enemies with a boss, all of which the character will need to attack to kill. I want to be able to be able to finish a level that provides me a sense of accomplishment."   




Team Roles:
==============
Arody Deleon (Backend Developer)
* Enemy movement/functionality
* Attack scripts
* General AI system


Christian Wilson (Frontend Designer)
* Level Design
* Object/Map Interaction
* Designing/Implementing Traps/Secret Passages/Puzzles

Daniel Re (Backend Developer)
* Player Movement/ Player Interactions
* Player Animations
* Item Usage/ Item Interaction


Andrew Forthman (Front and Backend)
* UI development and design
* HUD development and design
* General backend support


Code Reviewing:
* Level Design Review/ Map Interaction Review: Andrew Forthman
* Player Movement/Interactions Review: Arody Deleon
* UI/HUD Functionality Review: Christian Wilson
* Enemy Movement/Functionality Review: Daniel Re
