using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClockBehavior : MonoBehaviour
{
    private Boolean isGameOver;
    [SerializeField] TextMeshProUGUI clockTime;
    [SerializeField] float delay = 120f;
    int time = 7;
    

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
        while (!isGameOver)
        {
            if (time >= 12)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().isGameOver = true;
                isGameOver = true;
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
