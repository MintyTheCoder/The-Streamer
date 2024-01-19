using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{

    public static FadeController _instance;
    [SerializeField] static Animator anim;
    [SerializeField] TextMeshProUGUI nightText;
    private static int levelToLoad;

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

        anim = GameObject.Find("SceneFade").GetComponent<Animator>();
        nightText.text = SceneManager.GetActiveScene().name;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Update()
    {
        Debug.Log(levelToLoad);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("On scene loaded method");
        if (scene.name == "Start Menu")
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            anim.ResetTrigger("FadeOut");
            anim.SetTrigger("FadeIn");
        }
    }

    public static void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void FadeToLevel(int levelIndex)
    {
        Debug.Log("Fade Started");
        levelToLoad = levelIndex;
        anim.ResetTrigger("FadeIn");
        anim.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        // Workaround because unity has a broken method in the SceneManager class
        string scenePath = SceneUtility.GetScenePathByBuildIndex(levelToLoad);
        string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);

        nightText.text = sceneName;
        SceneManager.LoadScene(levelToLoad);
    }


}
