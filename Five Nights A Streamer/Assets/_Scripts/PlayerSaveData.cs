using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveData
{
    public string Night;
    public bool IsGameComplete;

    public PlayerSaveData(string Night, bool IsGameCompelte) 
    {
        this.Night = Night;
        this.IsGameComplete = IsGameCompelte;
    }
}
