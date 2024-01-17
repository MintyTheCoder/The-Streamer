using System.IO;
using UnityEngine;
using GameUtils;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.TestTools;
using System.ComponentModel;

/// <summary>
/// Class that contains the methods to control the main and settings menus. This also creates the inital save file and reads other json files.
/// </summary>
public class UIManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] Button playButton;
    
    void Awake()
    {
        SaveBaseData();
    }

    // Start is called before the first frame update
    void Start()
    {
        playButton.GetComponentInChildren<TextMeshProUGUI>().text = PlayerSaveU.LoadSave().Night;
    }

    public void LoadLatestScene()
    {
        SceneManager.LoadScene(PlayerSaveU.LoadSave().Night);
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
            //_data.Night = "Night 1";
            _data.Night = "Night 1";
            _data.IsGameComplete = false;

            string json = JsonUtility.ToJson(_data);
            Debug.Log(json);
            File.WriteAllText(PlayerSaveU.path, json);
        }

        if (!File.Exists(Application.persistentDataPath + "/ChatInfoCopy.json"))
        {
            // Making the chat different across machines
            File.Copy(Application.dataPath + "/_Scripts/ChatInfo.json", Application.persistentDataPath + "/ChatInfoCopy.json");
        }
    }

}
