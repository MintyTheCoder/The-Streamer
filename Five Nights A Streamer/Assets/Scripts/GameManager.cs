using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.Build.Reporting;
using UnityEngine.Rendering;

public class GameManager : EventSystem
{
    public Boolean isGameOver;
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
        Debug.Log(isGameOver);
        if (isGameOver)
        {
            //code
        }
    }
   

    
}
