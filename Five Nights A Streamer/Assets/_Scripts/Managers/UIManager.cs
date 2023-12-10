using System.IO;
using UnityEngine;
using GameUtils;

/// <summary>
/// Class that contains the methods to control the main and settings menus. This also creates the inital save file and reads other json files.
/// </summary>
public class UIManager : MonoBehaviour
{
    void Awake()
    {
        SetBasePlayerSaveData();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerSaveU.GetSavedNight());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetBasePlayerSaveData()
    {
        if (!File.Exists(Application.persistentDataPath + "/PlayerSave.json"))
        {
            PlayerSaveData _data = new PlayerSaveData();
            _data.Night = "Night 1";
            _data.IsGameComplete = false;

            string json = JsonUtility.ToJson(_data);
            Debug.Log(json);
            File.WriteAllText(Application.persistentDataPath + "/PlayerSave.json", json);
        }
        else
        {
            Debug.Log("File exists");
        }
    }

}
