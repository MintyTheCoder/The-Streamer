using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Class that contains the methods to control the main and settings menus. This also creates the inital save file and reads other json files.
/// </summary>
public class UIManager : MonoBehaviour
{
    void Awake()
    {
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

    private void GetSavedLevel()
    {
        if(File.Exists(Application.persistentDataPath + "/PlayerSave.json"))
        {
            Debug.Log("File exists");
            string json = File.ReadAllText(Application.persistentDataPath + "/PlayerSave.json");
            GameManager.PlayerSaveData saveData = JsonUtility.FromJson<GameManager.PlayerSaveData>(json);
            Debug.Log(saveData);
        }
        else 
        {
            throw new Exception("File doesnt exist");
        }
    }
}
