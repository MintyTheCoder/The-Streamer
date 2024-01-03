using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    public static bool StartSceneSwitch {get; set;}
    [SerializeField] Animator anim;
    [SerializeField] TextMeshProUGUI nightText;
    private int levelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        StartSceneSwitch = false;
        nightText.text = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (StartSceneSwitch == true)
        {
            FadeToNextLevel();
        }
    }

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        anim.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
