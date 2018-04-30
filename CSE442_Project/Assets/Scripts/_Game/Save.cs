using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save {

    public List<int> livingTargetPositions = new List<int>();
    public List<int> livingTargetsTypes = new List<int>();

    public string gameBuild = "";
    public float playerSpeedNorm = 2.25f;
    public float playerSpeed = 2.25f;
    public float playerAttackSpeedNorm = 1f;
    public float playerAttackSpeed = 1f;
    public int level = 1;
    public int livesmax = 0;
    public int lives = 0;
    public int score = 0;
	public int potionCount = 0;
	public int arrowCount = 5;

}
