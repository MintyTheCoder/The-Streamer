using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.IO;

/// <summary>
/// Contains the code to run events at certain times and manage the game/UI.
/// <para/>
/// 
/// Naming conventions for variables in all scripts:
/// <para/>
/// <ul>
///     <list>- Public variables and structs -> pascal case</list>
///     <list>- Private and Serialized Fields -> camel case</list>
///     <list>- Objects -> use a dash then camel case</list>
/// </ul>
/// </summary>
/// <remarks>
/// Remember for all public variables use encapsulation!
/// <para/>
/// <seealso href="https://github.com/MintyTheCoder/The-Streamer">The-Streamers GitHub</seealso>
/// </remarks>
public class GameManager : EventSystem
{
    public Boolean IsGameOver {get; set;}
    public Boolean HasPlayerWon { get; set;}
    [SerializeField] Boolean doesIntruderSpawn;
    [SerializeField] float intruderSpawnDelay;
    [SerializeField] float yOffset;
    [SerializeField] float timeBeforeSpawn;

    public struct PlayerSaveData
    {
        public static string Night;
    }

    void Awake()
    {
        SetLevel();
    }

    void Start()
    {
        if (doesIntruderSpawn)
        {
            Invoke(nameof(StartIntruderEvent), timeBeforeSpawn);
        }
    }

    void Update()
    {
        Debug.Log(IsGameOver);
        if (IsGameOver && HasPlayerWon == true)
        {
            Debug.Log("You won");
            Invoke(nameof(LoadNextScene), 5);
        }
        else
        {
            Debug.Log("You lost");
            Invoke(nameof(ReloadScene), 5);
        }
    }

    // Parse the level information to the PlayerSave json file.
    private void SetLevel()
    {
        string currentLevel = SceneManager.GetActiveScene().name;

        string data = PlayerSaveData.Night = currentLevel;
         
        string parsedData = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/PlayerSave.json", parsedData);
    } 

    // So we can invoke the spawning
    private void StartIntruderEvent()
    {
        StartCoroutine(SpawnIntruder(intruderSpawnDelay, yOffset));
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
