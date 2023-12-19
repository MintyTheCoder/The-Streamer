using System.IO;
using UnityEngine;
using GameUtils;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Class that contains the methods to control the main and settings menus. This also creates the inital save file and reads other json files.
/// </summary>
public class UIManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] Button playButton;
    
    void Awake()
    {
        SaveBasePlayerSaveData();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerSaveU.LoadSave().Night);
        playButton.GetComponentInChildren<TextMeshProUGUI>().text = PlayerSaveU.LoadSave().Night;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLatestScene()
    {
        SceneManager.LoadScene(PlayerSaveU.LoadSave().Night);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void SaveBasePlayerSaveData()
    {
        if (!File.Exists(PlayerSaveU.path))
        {
            PlayerSaveData _data = new PlayerSaveData();
            _data.Night = "Night 1";
            _data.IsGameComplete = false;

            string json = JsonUtility.ToJson(_data);
            Debug.Log(json);
            File.WriteAllText(PlayerSaveU.path, json);
        }
    }

}
