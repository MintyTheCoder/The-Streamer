using System.IO;
using UnityEngine;
using GameUtils;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.TestTools;
using System.ComponentModel;
using System.Collections;
using System;

/// <summary>
/// Class that contains the methods to control the main and settings menus. This also creates the inital save file and reads other json files.
/// </summary>
public class UIManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] Button playButton;

    [Header("Menus")]
    [SerializeField] GameObject loadingScreen;
    [SerializeField] GameObject titleScreen;

    [Header("Sliders")]
    [SerializeField] Slider progressBar;
    
    void Awake()
    {
        SaveBaseData();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerSaveU.LoadSave().Night);
        playButton.GetComponentInChildren<TextMeshProUGUI>().text = PlayerSaveU.LoadSave().Night;
    }

    public void LoadLatestScene()
    {
        titleScreen.SetActive(false);
        loadingScreen.SetActive(true);

        // Run async operation
        StartCoroutine(LoadLevelAsync(PlayerSaveU.LoadSave().Night));
    }

    private IEnumerator LoadLevelAsync(string sceneName)
    {
        UnityEngine.AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName);
        
        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            progressBar.value = progressValue;
            yield return null;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    private void SaveBaseData()
    {
        if (!File.Exists(PlayerSaveU.path))
        {
            // Creating player save
            PlayerSaveData _data = new PlayerSaveData();
            _data.Night = "Home Scene";
            _data.IsGameComplete = false;

            string json = JsonUtility.ToJson(_data);
            Debug.Log(json);
            Debug.Log("Writing initial save...");
            File.WriteAllText(PlayerSaveU.path, json);
        }
    }

}
