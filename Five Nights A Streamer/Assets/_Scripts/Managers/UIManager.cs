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
        string json = File.ReadAllText(Application.persistentDataPath + "/PlayerSave.json");
        PlayerSaveData _saveData = JsonUtility.FromJson<PlayerSaveData>(json);
        return _saveData.Night;
    }

    private void SetBasePlayerSaveData()
    {
        
        if (!File.Exists(Application.persistentDataPath + "/PlayerSave.json"))
        {
            PlayerSaveData _data = new PlayerSaveData("Night 1", false);
            Debug.Log(_data.IsGameComplete);
            string json = JsonUtility.ToJson(_data);
            Debug.Log(json);
            File.WriteAllText(Application.persistentDataPath + "/PlayerSave.json", json);
        }
        else
        {
            Debug.Log("File exists");
        }
    }

}
