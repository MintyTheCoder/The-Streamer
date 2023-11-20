using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventSystem : MonoBehaviour
{
    private Boolean isGameOver;
    [SerializeField] GameObject intruderPrefab;

    [System.Serializable]
    public struct Spawnable
    {
        public GameObject gameObject;
        public float weight;
    }

    [SerializeField] List<Spawnable> spawnables;

    private void Start()
    {
        isGameOver = GameObject.Find("GameManager").GetComponent<GameManager>().isGameOver;
    }

    private GameObject RandomSpawnPoint()
    {
        float totalWeight = 0f;
        // Add the weight of every single spawnable
        foreach (Spawnable obj in spawnables)
        {
            totalWeight += obj.weight;
        }

        // Pick a random value from 0 to the added weight of every spawnable
        float random = UnityEngine.Random.Range(0, totalWeight);

        // Looping through the list again
        foreach (Spawnable obj in spawnables)
        {
            // If the random value is less than an objects weight spawn the object
            if(random < obj.weight)
            {
                return obj.gameObject;
            }
        }

        // This should NOT happen
        return null;
    }

    /// <summary>
    /// Moves the intruder to a random spawn point after a specified delay.
    /// </summary>
    /// <param name="delay">The delay in seconds before moving the intruder.</param>
    /// <returns>A coroutine to handle the intruder movement.</returns>
    public IEnumerator SpawnIntruder(float delay)
    {
        // Run until the game is over
        while (!isGameOver)
        {
            if (GameObject.FindWithTag("Intruder") != null)
            {
                Debug.Log("Destroying... : " + GameObject.FindWithTag("Intruder").name);
                Destroy(GameObject.FindWithTag("Intruder"));
            }

            Instantiate(intruderPrefab, RandomSpawnPoint().transform.position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
        
    }
}
