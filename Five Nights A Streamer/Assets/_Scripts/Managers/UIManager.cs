using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that contains the methods to control the main and settings menus. This also creates the inital save file and reads other json files.
/// </summary>
public class UIManager : MonoBehaviour
{
    void Awake()
    {
        SetBasePLayerSaveData();
        GetSavedLevel();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private string GetSavedLevel()
    {
        if(File.Exists(Application.persistentDataPath + "/PlayerSave.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/PlayerSave.json");
            GameManager.PlayerSaveData _saveData = JsonUtility.FromJson<GameManager.PlayerSaveData>(json);
            return  _saveData.Night;
        }
        else 
        {
            throw new Exception("File doesnt exist");
        }
    }

    private void SetBasePLayerSaveData()
    {
        GameManager.PlayerSaveData _save = new GameManager.PlayerSaveData();
        _save.Night = "Night 1";

        string json = JsonUtility.ToJson(_save);
        Debug.Log(json);
        File.WriteAllText(Application.persistentDataPath + "/PlayerSave.json", json);
    }
}
