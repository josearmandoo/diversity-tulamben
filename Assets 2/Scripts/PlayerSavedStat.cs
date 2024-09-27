using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int Day;
    public int Money;
    public int Popularity;

    // Shop check
    public bool Flipper1;
    public bool SeaTurtle;
    public bool Oxygen1;
    public bool Battery1;
    public bool Manta;
    public bool Flipper2;
    public bool LionFish;
    public bool Oxygen2;
    public bool Battery2;
    public bool WhaleShark;

    
}

public class PlayerSavedStat : MonoBehaviour
{
    public GameData gameData;

    public int Loot;

    private string saveFilePath;

    private void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "gamedata.json");

        gameData = LoadGameData();
    }

    void Start()
    {
        
    }

    public void NextDay()
    {
        gameData.Day = gameData.Day + 1;
        gameData.Money = gameData.Money + Loot;
        SaveGameData(gameData);
    }

    public void BlackOut()
    {
        gameData.Day = gameData.Day + 1;
        SaveGameData(gameData);
    }

    public void SaveGameData(GameData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Game data saved.");
    }

    public GameData LoadGameData()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            GameData data = JsonUtility.FromJson<GameData>(json);
            Debug.Log("Game data loaded.");
            return data;
        }
        else
        {
            Debug.LogWarning("No save file found, initializing with default values.");
            return new GameData();
        }
    }

    public void NewGame()
    {
        SaveGameData(new GameData());
    }
}
