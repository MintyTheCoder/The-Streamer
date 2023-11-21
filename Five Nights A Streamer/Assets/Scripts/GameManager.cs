using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.Build.Reporting;
using UnityEngine.Rendering;

public class GameManager : EventSystem
{
    public Boolean isGameOver;
    [SerializeField] float intruderSpawnDelay;

    private void Start()
    {
        //temporary
        StartCoroutine(SpawnIntruder(intruderSpawnDelay));
        
        Debug.Log("Running too!");
    }
  
    private void Update()
    {
        Debug.Log(isGameOver);
        if (isGameOver)
        {
            Debug.Log("Game Over!");
        }
    }
   

    
}
