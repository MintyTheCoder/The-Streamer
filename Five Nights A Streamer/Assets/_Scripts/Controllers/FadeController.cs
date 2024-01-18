using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{

    public static FadeController _instance;
    public static bool StartSceneSwitch { private get; set; }
    public static bool StartMenuSwitch { private get; set; }
    [SerializeField] Animator anim;
    [SerializeField] TextMeshProUGUI nightText;
    private int levelToLoad;

    void Awake()
    {
        Debug.Log("Here");
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {

        if (StartSceneSwitch == true)
        {
            FadeToNextLevel();
        }

        if (StartMenuSwitch == true)
        {
            FadeToLevel(0);
        }

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("On scene loaded method");
        Debug.Log("HELLLLLLLLLLLLLLLOOOOOOOOOOOOOO");
        if (SceneManager.GetActiveScene().name == "Start Menu")
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            StartSceneSwitch = false;
            StartMenuSwitch = false;
            nightText.text = SceneManager.GetActiveScene().name;
        }
    }

    private void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void FadeToLevel (int levelIndex)
    {
        Debug.Log("Fade Started");
        levelToLoad = levelIndex;
        anim.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        Debug.Log("On Fade Compelete");
        SceneManager.LoadScene(levelToLoad);
    }

}
