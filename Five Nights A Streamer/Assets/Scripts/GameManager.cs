using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.Build.Reporting;
using UnityEngine.Rendering;

public class GameManager : EventSystem
{
    public Boolean isGameOver;

    private void Start()
    {
        //temporary
        //StartCoroutine(SpawnIntruder(8));
        
        Debug.Log("Running too!");
    }
  
    private void Update()
    {
        if (isGameOver)
        {
            Debug.Log("Game Over!");
        }
    }
   

    
}
