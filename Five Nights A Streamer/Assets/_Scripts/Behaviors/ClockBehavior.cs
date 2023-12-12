using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.VFX;

public class ClockBehavior : MonoBehaviour
{
    private int time = 6;
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
        while (GameManager.IsGameOver == false)
        {    
            time++;
            clockTime.text = time + ":00 PM";
            
            if (time >= 12)
            {
                Debug.Log("Clock got here");
                GameManager.IsGameOver = true;
                GameManager.HasPlayerWon = true;  
                yield break;  // Exit the coroutine
            }
            yield return new WaitForSeconds(delay);
        }
    }
}
