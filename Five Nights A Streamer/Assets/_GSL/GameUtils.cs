using System.Collections.Generic;
using System.IO;
using System;
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
        public static string path { get; private set; } = Application.persistentDataPath + "/PlayerSave.json";

        /// <summary>
        /// Parses the latest data to the PlayerSave json.
        /// </summary>
        public static void SaveData()
        {
            string currentLevel = SceneManager.GetActiveScene().name;
            PlayerSaveData _data = LoadSave();

            _data.Night = currentLevel;
            _data.IsGameComplete = IsGameCompleted();

            string json = JsonUtility.ToJson(_data);
            Debug.Log(json);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Get the latest save data found in the PlayerSave json.
        /// </summary>
        /// <returns>A PlayerSaveData object</returns>
        public static PlayerSaveData LoadSave()
        {
            string json = File.ReadAllText(path);
            PlayerSaveData _saveData = JsonUtility.FromJson<PlayerSaveData>(json);
            return _saveData;
        }

        // Determines if the game is completed or not
        private static bool IsGameCompleted()
        {
            string currentScene = SceneManager.GetActiveScene().name;
            return currentScene.Equals("Night 5") && GameManager.HasPlayerWon == true ? true : false;
        }


    }

    /// <summary>
    /// Serializable blueprint of the PlayerSave
    /// </summary> 
    [Serializable]
    public class PlayerSaveData
    {
        public string Night;
        public bool IsGameComplete;
    }

}

