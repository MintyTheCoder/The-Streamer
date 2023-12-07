using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

/// <summary>
/// Class that contains the methods to control the main and settings menus. This also creates the inital save file and reads other json files.
/// </summary>
public class UIManager : MonoBehaviour
{
    void Awake()
    {
        SetBasePlayerSaveData();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private string GetSavedNight()
    {
        if(File.Exists(Application.persistentDataPath + "/PlayerSave.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/PlayerSave.json");
            GameManager.PlayerSaveData _saveData = JsonUtility.FromJson<GameManager.PlayerSaveData>(json);
            Debug.Log(_saveData);
            return _saveData.Night;
        }
        else
        {
            throw new Exception("File doesnt exist");

        }
    }

    private void SetBasePlayerSaveData()
    {
        GameManager.PlayerSaveData data = new GameManager.PlayerSaveData();
        if (!File.Exists(Application.persistentDataPath + "/PlayerSave.json"))
        {
            
            data.Night = "Night 1";
            data.IsGameComplete = false;

            string json = JsonUtility.ToJson(data);
            Debug.Log(json);
            File.WriteAllText(Application.persistentDataPath + "/PlayerSave.json", json);
        }
        else
        {
            Debug.Log("File exists");
        }
    }

}
