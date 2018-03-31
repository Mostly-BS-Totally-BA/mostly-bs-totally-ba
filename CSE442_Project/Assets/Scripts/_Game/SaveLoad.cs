using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad {

    //public static List<Game> savedGames = new List<Game>();
    private static GameManager _gm = null;

    public static void SaveGame(){
        Save save = CreateSaveGameObject();

        //savedGames.Add(Game.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("Game Saved");
    }

    public static void Load(){
        if(File.Exists(Application.persistentDataPath + "/gamesave.save")) {
            _gm = GameManager.Instance;
            //Reset functions

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            //load game values
            _gm.LoadGame(save);
            //start game
            _gm.StartLevel();
        }
    }

    private static Save CreateSaveGameObject(){
        Save save = new Save();
        _gm = GameManager.Instance;

        save.playerSpeedNorm = _gm.playerSpeedNorm;
        save.playerSpeed = _gm.playerSpeed;
        save.playerAttackSpeedNorm = _gm.playerAttackSpeedNorm;
        save.playerAttackSpeed = _gm.playerAttackSpeed;
        save.level = _gm.Level;
        save.livesmax = _gm.livesMax;
        save.lives = _gm.LivesCount;
        save.score = _gm.Score;

        return save;
    }
}
