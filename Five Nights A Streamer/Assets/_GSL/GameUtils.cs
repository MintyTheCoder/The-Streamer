using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameUtils
{
    public class ListU
    {
        /// <summary>
        /// Randomly shuffles the list you input
        /// </summary>
        /// <param name="list">Generic list</param> 
        public static void ShuffleList<T>(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int randomIndex = UnityEngine.Random.Range(i, list.Count);
                T temp = list[i];
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }
        }

    }

    public class PlayerSaveU
    {
        /// <summary>
        /// Determines if the game is completed or not.
        /// </summary>
        /// <returns>True if the game is completed</returns>
        public static bool IsGameCompleted()
        {
            string currentScene = SceneManager.GetActiveScene().name;
            if (currentScene.Equals("Night 5") && GameManager.HasPlayerWon == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Parses the latest night to the PlayerSave json.
        /// </summary> 
        public static void SaveLatestNight()
        {
            string currentLevel = SceneManager.GetActiveScene().name;
            PlayerSaveData _data = new PlayerSaveData();
            _data.Night = currentLevel;

            string json = JsonUtility.ToJson(_data);
            File.WriteAllText(Application.persistentDataPath + "/PlayerSave.json", json);
        }

        /// <summary>
        /// Saves the completion status of the game.
        /// </summary> 
        public static void SaveCompletionStatus()
        {
            PlayerSaveData _data = new PlayerSaveData();
            _data.IsGameComplete = IsGameCompleted();

            string json = JsonUtility.ToJson(_data);
            File.WriteAllText(Application.persistentDataPath + "/PlayerSave.json", json);
        }

        /// <summary>
        /// Get the latest night found in the PlayerSave json.
        /// </summary>
        /// <returns>The night as a string</returns>
        public static string GetSavedNight()
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/PlayerSave.json");
            PlayerSaveData _saveData = JsonUtility.FromJson<PlayerSaveData>(json);
            return _saveData.Night;
        }

    }

    /// <summary>
    /// Serializable blueprint of the PlayerSave
    /// </summary> 
    [System.Serializable]
    public class PlayerSaveData
    {
        public string Night;
        public bool IsGameComplete;
    }
}

