using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngineInternal;
using UnityEditorInternal;
using System.Linq;

public class EventSystem : MonoBehaviour
{
    [SerializeField] GameObject intruderPrefab;
    private Transform dangerZone;
    [System.Serializable]
    public struct Spawnable
    {
        public GameObject gameObject;
        public float weight;
    }

    [SerializeField] List<Spawnable> spawnables;

    private void Start()
    {
        // Get the "danger" game objects transform before list shuffles
        dangerZone = spawnables.ElementAt(0).gameObject.transform;
    }

    // Handle all the checks here
    private void Update()
    {
        // Check if the intruder is at a certain game object and if the door is not closed, if so stop the game(Jump scares and delays will be added in the future).
        if (intruderPrefab.transform.position == dangerZone.position && !GameObject.Find("Door").GetComponent<DoorController>().isDoorClosed)
        {
            Debug.LogWarning("You died");
            GameObject.Find("GameManager").GetComponent<GameManager>().isGameOver = true;
        }

    }

    private GameObject RandomSpawnPoint()
    {
        float totalWeight = 0f;

        // Adding all the objects weights together
        foreach (Spawnable obj in spawnables)
        {
            totalWeight += obj.weight;
        }

        float randomValue = UnityEngine.Random.Range(0f, totalWeight);

        // Shuffle the list to randomize selection among objects with the same weight
        ShuffleList(spawnables);

        foreach (Spawnable obj in spawnables)
        {
            if (randomValue < obj.weight)
            {
                return obj.gameObject;
            }
            Debug.Log("Subtracted " + obj.weight);
            // By subtracting the weight, the algorithm accounts for the probability distribution based on weights.
            // The larger the weight of the current object, the less likely it is to subtract its weight from randomValue
            randomValue -= obj.weight;
            Debug.Log("Value: " + randomValue);
        }

        // Fallback in case of any issue (shouldn't normally happen)
        return spawnables[spawnables.Count - 1].gameObject; 
    }

    // Helper function to shuffle the list
    private void ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = UnityEngine.Random.Range(i, list.Count);
            T temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    /// <summary>
    /// Moves the intruder to a random spawn point after a specified delay.
    /// </summary>
    /// <param name="delay">The delay in seconds before moving the intruder.</param>
    /// <param name="yOffset">The offset on the y axis of the intruders spawn</param>
    /// <returns>A coroutine to handle the intruder movement.</returns>
    public IEnumerator SpawnIntruder(float delay, float yOffset)
    {
        // Run until the game is over
        while (!GameObject.Find("GameManager").GetComponent<GameManager>().isGameOver)
        {
            if (GameObject.FindWithTag("Intruder") != null)
            {
                Debug.Log("Destroying... : " + GameObject.FindWithTag("Intruder").name);
                Destroy(GameObject.FindWithTag("Intruder"));
            }
            GameObject randomObject = RandomSpawnPoint(); 

            Instantiate(intruderPrefab, new Vector3(randomObject.transform.position.x, randomObject.transform.position.y + yOffset, randomObject.transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
        
    }
}
