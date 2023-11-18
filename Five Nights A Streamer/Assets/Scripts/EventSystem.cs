using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventSystem : MonoBehaviour
{
    private Boolean isGameOver;
    [SerializeField] GameObject[] intruderSpawnLocations = new GameObject[4];
    [SerializeField] GameObject intruderPrefab;
    
    private void Start()
    {
        isGameOver = GameObject.Find("GameManager").GetComponent<GameManager>().isGameOver;
    }

    private GameObject RandomSpawnPoint()
    {
       int randomPosition =  UnityEngine.Random.Range(0, intruderSpawnLocations.Length);
       
       return intruderSpawnLocations[randomPosition];
    }

    /// <summary>
    /// Moves the intruder to a random spawn point after a specified delay.
    /// </summary>
    /// <param name="delay">The delay in seconds before moving the intruder.</param>
    /// <returns>A coroutine to handle the intruder movement.</returns>
    public IEnumerator SpawnIntruder(float delay)
    {
        while (!isGameOver)
        {
            if (GameObject.FindWithTag("Intruder") != null)
            {
                Debug.Log("Destroying... : " + GameObject.FindWithTag("Intruder").name);
                Destroy(GameObject.FindWithTag("Intruder"));
            }

            // no condition
            Instantiate(intruderPrefab, RandomSpawnPoint().transform.position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
            Debug.Log("Will it Reach?"); 
        }
        
    }
}
