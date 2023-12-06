using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.IO;

/// <summary>
/// Contains the code to run events at certain times and manage the game loop/events.
/// <para/>
/// 
/// Naming conventions for variables in all scripts:
/// <para/>
/// <ul>
///     <list>- Public variables and structs -> pascal case</list>
///     <list>- Private and Serialized Fields -> camel case</list>
///     <list>- Objects -> use a dash then camel case</list>
/// </ul>
/// </summary>
/// <remarks>
/// Remember for all public variables use encapsulation!
/// <para/>
/// <seealso href="https://github.com/MintyTheCoder/The-Streamer">The-Streamers GitHub</seealso>
/// </remarks>
public class GameManager : MonoBehaviour
{
    public Boolean IsGameOver {get; set;}
    public Boolean HasPlayerWon { get; set;}

    [SerializeField] Boolean doesIntruderSpawn;
    [SerializeField] float intruderSpawnDelay;
    [SerializeField] float yOffset;
    [SerializeField] float timeBeforeSpawn;
    [SerializeField] GameObject intruderPrefab;
    [SerializeField] GameObject doorObject;
    
    private DoorController _doorController;
    private GameObject dangerGameObject;

    [System.Serializable]
    public struct Spawnable
    {
        public GameObject GameObject;
        public float Weight;
    }

    [SerializeField] List<Spawnable> spawnables;
    private List<Spawnable> originalSpawnables;

    public struct PlayerSaveData
    {
        public static string Night;
    }

    void Awake()
    {
        SetLevel();
        _doorController = doorObject.GetComponent<DoorController>();
        originalSpawnables = spawnables;
        dangerGameObject = originalSpawnables[0].GameObject;
    }


    void Start()
    {
        if (doesIntruderSpawn)
        {
            Invoke(nameof(StartIntruderEvent), timeBeforeSpawn);
        }
    }

    void Update()
    {
        /*if (IsGameOver && HasPlayerWon == true)
        {
            Debug.Log("You won");
            Invoke(nameof(LoadNextScene), 5);
        }
        else
        {
            Debug.Log("You lost");
            Invoke(nameof(ReloadScene), 5);
        }*/

    }

    // Parse the level information to the PlayerSave json file.
    private void SetLevel()
    {
        string currentLevel = SceneManager.GetActiveScene().name;

        string data = PlayerSaveData.Night = currentLevel;

        string parsedData = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/PlayerSave.json", parsedData);
    }

    // So we can invoke the spawning
    private void StartIntruderEvent()
    {
        StartCoroutine(SpawnIntruder(intruderSpawnDelay, yOffset));
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

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

    private GameObject RandomSpawnPoint()
    {
        float totalWeight = 0f;

        foreach (Spawnable obj in spawnables)
        {
            totalWeight += obj.Weight;
        }

        float randomValue = UnityEngine.Random.Range(0f, totalWeight);

        ShuffleList(spawnables);

        foreach (Spawnable obj in spawnables)
        {
            if (randomValue < obj.Weight)
            {
                return obj.GameObject;
            }

            /** 
             * By subtracting the weight, the algorithm accounts for the probability distribution based on weights.
             * The larger the weight of the current object, the less likely it is to subtract its weight from randomValue
             */
            randomValue -= obj.Weight;
        }

        throw new Exception("Could pick a random weighted object");
    }

    


    /// <summary>
    /// Moves the intruder to a random spawn point after a specified delay.
    /// </summary>
    /// <param name="delay">The delay in seconds before moving the intruder.</param>
    /// <param name="yOffset">The offset on the y axis of the intruders spawn</param>
    /// <returns>A coroutine to handle the intruder movement.</returns>
    public IEnumerator SpawnIntruder(float delay, float yOffset)
    {
        while (!IsGameOver)
        {

            if (GameObject.FindWithTag("Intruder") != null)
            {
                Destroy(GameObject.FindWithTag("Intruder"));
            }
            GameObject randomObject = RandomSpawnPoint();

            Instantiate(intruderPrefab, new Vector3(randomObject.transform.position.x, randomObject.transform.position.y + yOffset, randomObject.transform.position.z), Quaternion.identity);

            Vector3 intruderPosition = GameObject.FindWithTag("Intruder").transform.position;
            Vector3 dangerZone = new Vector3(dangerGameObject.transform.position.x, dangerGameObject.transform.position.y + yOffset, dangerGameObject.transform.position.z);
            if (dangerZone == intruderPosition && _doorController.IsDoorClosed == false)
            {
                Debug.LogWarning("You died");
                IsGameOver = true;
                HasPlayerWon = false;
            }
            yield return new WaitForSeconds(delay);
        }

    }

}



   

     

    

