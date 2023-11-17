using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : EventSystem
{
    public Boolean isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        moveIntruder(8);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
