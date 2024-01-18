using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.VFX;

public class ClockBehavior : MonoBehaviour
{
    private int time = 5;
    private AudioSource sound;
    [SerializeField] TextMeshProUGUI clockTime;
    [SerializeField] float delay = 120f;

    // Start is called before the first frame update
    void Start()
    {
        clockTime.text = time + ":00 PM";
        StartCoroutine(IncrementClock());
        sound = GetComponent<AudioSource>();
    }

    IEnumerator IncrementClock()
    {
        while (GameManager.IsGameOver == false)
        {    
            time++;
            
            if (time >= 12)
            {
                clockTime.text = time + ":00 AM";
                Debug.Log("Clock got here");
                sound.Play();
                GameManager.IsGameOver = true;
                GameManager.HasPlayerWon = true;
                yield break;  // Exit the coroutine
            }

            clockTime.text = time + ":00 PM";
            yield return new WaitForSeconds(delay);
        }
    }
}
