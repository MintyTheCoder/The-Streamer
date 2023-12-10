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


    // Start is called before the first frame update
    void Start()
    {
        clockTime.text = time + ":00 PM";
        StartCoroutine(IncrementClock());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator IncrementClock()
    {
        while (!GameManager.IsGameOver)
        {
            if (time >= 12)
            {
                GameManager.IsGameOver = true;
                GameManager.HasPlayerWon = true;
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
