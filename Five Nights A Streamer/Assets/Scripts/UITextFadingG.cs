using System.Collections;
using UnityEngine;
using TMPro;

public class UITextFadingG : MonoBehaviour
{
    public TextMeshProUGUI textDisplay1;
   
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
            textDisplay1.color = new Color(textDisplay1.color.r, textDisplay1.color.g, textDisplay1.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }
}