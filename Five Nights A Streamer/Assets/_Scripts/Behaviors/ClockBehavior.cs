using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.VFX;

public class ClockBehavior : MonoBehaviour
{
    private int time = 7;
    [SerializeField] TextMeshProUGUI clockTime;
    [SerializeField] float delay = 120f;
    GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        clockTime.text = time + ":00 PM";
        StartCoroutine(IncrementClock());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator IncrementClock()
    {
        while (!_gameManager.IsGameOver)
        {
            if (time >= 12)
            {
                _gameManager.HasPlayerWon = true;
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
