using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClockBehavior : MonoBehaviour
{
    private GameManager _gameManager = new GameManager();
    private int time = 7;
    [SerializeField] TextMeshProUGUI clockTime;
    [SerializeField] float delay = 120f;
    
    

    // Start is called before the first frame update
    void Start()
    {
        clockTime.text = time + ":00 PM";
        StartCoroutine(IncrementClock());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Other scripts" + _gameManager.IsGameOver);
    }

    IEnumerator IncrementClock()
    {
        while (!_gameManager.IsGameOver)
        {
            if (time >= 12)
            {
                _gameManager.IsGameOver = true;
            }
            else
            {
                yield return new WaitForSeconds(delay);
                time++;
                clockTime.text = time + ":00 PM";
            }
        }
 
    }
}
