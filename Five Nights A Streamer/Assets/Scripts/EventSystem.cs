using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventSystem : MonoBehaviour
{
    private Boolean isGameOver;
    [SerializeField] GameObject[] intruderSpawnLocations = new GameObject[4];
    [SerializeField] GameObject intruderPrefab;
    
    private void Start()
    {
        isGameOver = GameObject.Find("GameManager").GetComponent<GameManager>().isGameOver;
    }

    public void moveIntruder(float intensity)
    {
        while (!isGameOver)
        {
            StartCoroutine(spawnAfterDelay(intensity));
            if (GameObject.FindWithTag("Intruder"))
            {
                Destroy(intruderPrefab);
                spawnAfterDelay(intensity);
            }
            else
            {
                Debug.Log("error");
            }
        }
    }

    private GameObject randomSpawnPoint()
    {
       int randomPosition =  UnityEngine.Random.Range(0, intruderSpawnLocations.Length);
       
       return intruderSpawnLocations[randomPosition];
    }

    IEnumerator spawnAfterDelay(float delay)
    {
        Debug.Log("Spawning...");
        yield return new WaitForSeconds(delay);
        Instantiate(intruderPrefab, randomSpawnPoint().transform.position, Quaternion.identity);
    }
}
