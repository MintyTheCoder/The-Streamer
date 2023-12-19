using System.Collections;
using UnityEngine;
using TMPro;

public class UITextFadingGBehavior : MonoBehaviour
{
    public TextMeshProUGUI TextDisplay1;
   
    void OnEnable()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float duration = 2f; //Fade out over 2 seconds.
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(0f, 1f, currentTime / duration);
            TextDisplay1.color = new Color(TextDisplay1.color.r, TextDisplay1.color.g, TextDisplay1.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }
}