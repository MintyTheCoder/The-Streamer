using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


/// <summary>
/// Contains the code to run events at certain times and manage the game/UI.
/// <para/>
/// 
/// Naming conventions for variables in all scripts:
/// <para/>
/// <ul>
///     <list>- Public variables -> pascal case</list>
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
    [SerializeField] Boolean doesIntruderSpawn;
    [SerializeField] float intruderSpawnDelay;
    [SerializeField] float yOffset;
    [SerializeField] float timeBeforeSpawn;
    
    private void Start()
    {
        if (doesIntruderSpawn)
        {
            Invoke("StartIntruderEvent", timeBeforeSpawn); 
        }
        
        Debug.Log("Running too!");
    }

    private void Update()
    {
        Debug.Log(IsGameOver);
        if (IsGameOver)
        {
            Invoke("ReloadScene", 3);
        }
    }

    // So we can invoke the spawning
    private void StartIntruderEvent()
    {
        StartCoroutine(SpawnIntruder(intruderSpawnDelay, yOffset));
    }

    // So we can invoke the reloaded
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
