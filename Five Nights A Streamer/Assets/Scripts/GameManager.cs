using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


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
/// <remarks>Remember for all public variables use encapsulation!</remarks>
public class GameManager : EventSystem
{


    public Boolean IsGameOver {get; set;}

    [SerializeField] Boolean doesIntruderSpawn;
    [SerializeField] float intruderSpawnDelay;
    [SerializeField] float yOffset;
    
    private void Start()
    {
        if (doesIntruderSpawn)
        {
            StartCoroutine(SpawnIntruder(intruderSpawnDelay, yOffset));
        }
        
        Debug.Log("Running too!");
    }
  
    private void Update()
    {
        Debug.Log(IsGameOver);
        if (IsGameOver)
        {
            //code
        }
    }
   

    
}
