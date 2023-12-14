using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using GameUtils;
using UnityEngine.Events;

/// <summary>
/// Contains the code to run events at certain times and manage the game loop/events.
/// <para/>
/// 
/// Naming conventions for variables in all scripts:
/// <para/>
/// <ul>
///     <list>- Public variables, structs and classes -> pascal case</list>
///     <list>- Private and Serialized Fields -> camel case</list>
///     <list>- Objects we created -> use a dash then camel case</list>
///     <list>- Other objects -> use camel case</list>
/// </ul>
/// </summary>
/// <remarks>
/// Remember for all public variables use encapsulation!
/// <para/>
/// <seealso href="https://github.com/MintyTheCoder/The-Streamer">The-Streamers GitHub</seealso>
/// </remarks>
public class GameManager : MonoBehaviour
{
    private DoorController _doorController;
    private GameObject dangerGameObject;
    private List<Spawnable> originalSpawnables;

    public static bool IsGameOver {get; set;}
    public static bool HasPlayerWon { get; set;}

    [Header("GameObject References")]

    [SerializeField] GameObject doorObject;

    [Header("Game Status Events")]

    [SerializeField] UnityEvent onPlayerWin;
    [SerializeField] UnityEvent onPlayerLoss;

    [Header("Intruder Event Settings")]

    [SerializeField] bool doesIntruderSpawn;
    [SerializeField] float intruderSpawnDelay;
    [SerializeField] float intruderYOffset;
    [SerializeField] float timeBeforeSpawn;
    [SerializeField] GameObject intruderPrefab;

    [Serializable]
    public struct Spawnable
    {
        public GameObject GameObject;
        public float Weight;
    }
    [SerializeField] List<Spawnable> spawnables;
    

    

    void Awake()
    {
        PlayerSaveU.SaveData();
        _doorController = doorObject.GetComponent<DoorController>();
        originalSpawnables = spawnables;
        dangerGameObject = originalSpawnables[0].GameObject;
    }


    void Start()
    {
        IsGameOver = false;
        HasPlayerWon = false;  
        if (doesIntruderSpawn)
        {
            Invoke(nameof(StartIntruderEvent), timeBeforeSpawn);
        }
    }

    void Update()
    {
        // Checking for game status and saving data
        if (IsGameOver == true && HasPlayerWon == true)
        {
            Debug.Log("You won");
            StopAllCoroutines();
            PlayerSaveU.SaveData();
            onPlayerWin.Invoke();
        }
        else if (IsGameOver == true && HasPlayerWon == false)
        {
            Debug.Log("You lost");
            StopAllCoroutines();
            onPlayerLoss.Invoke();
        }
    }

    private void StartIntruderEvent()
    {
        StartCoroutine(SpawnIntruder(intruderSpawnDelay, intruderYOffset));
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private GameObject RandomSpawnPoint()
    {
        float totalWeight = 0f;

        foreach (Spawnable obj in spawnables)
        {
            totalWeight += obj.Weight;
        }

        float randomValue = UnityEngine.Random.Range(0f, totalWeight);

        ListU.ShuffleList(spawnables);
        
        foreach (Spawnable obj in spawnables)
        {
            if (randomValue < obj.Weight)
            {
                return obj.GameObject;
            }

            /*
            * By subtracting the weight, the algorithm accounts for the probability distribution based on weights.
            * The larger the weight of the current object, the less likely it is to subtract its weight from randomValue
            */
            randomValue -= obj.Weight;
        }

        throw new Exception("Couldn't pick a random weighted object");
    }

    /// <summary>
    /// Moves the intruder to a random spawn point based on weight after a specified delay.
    /// </summary>
    /// <param name="delay">The delay in seconds before moving the intruder.</param>
    /// <param name="yOffset">The offset on the y axis of the intruders spawn</param>
    /// <returns>A coroutine to handle the intruder movement.</returns>
    private IEnumerator SpawnIntruder(float delay, float yOffset)
    {
        while (true)
        {
            if (GameObject.FindWithTag("Intruder") != null)
            {
                Destroy(GameObject.FindWithTag("Intruder"));
            }
            GameObject randomObject = RandomSpawnPoint();

            Instantiate(intruderPrefab, new Vector3(randomObject.transform.position.x, randomObject.transform.position.y + intruderYOffset, randomObject.transform.position.z), Quaternion.identity);

            Vector3 intruderPosition = GameObject.FindWithTag("Intruder").transform.position;
            Vector3 dangerZone = new Vector3(dangerGameObject.transform.position.x, dangerGameObject.transform.position.y + yOffset, dangerGameObject.transform.position.z);
            if (dangerZone == intruderPosition && _doorController.IsDoorClosed == false)
            {
                Debug.Log("You DIEEEDDDDD");
                IsGameOver = true;
                HasPlayerWon = false;
            }
            yield return new WaitForSeconds(delay);
        }

    }
}



   

     

    

