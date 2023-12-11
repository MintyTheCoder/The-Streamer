using System.Collections;
using UnityEngine;
using TMPro;

public class OpeningText : MonoBehaviour
{
    public TextMeshProUGUI textDisplay1;
    public TextMeshProUGUI textDisplay2;
    public TextMeshProUGUI textDisplay3;
    public TextMeshProUGUI textDisplay4;
    
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
            textDisplay2.color = new Color(textDisplay2.color.r, textDisplay2.color.g, textDisplay2.color.b, alpha);
            textDisplay3.color = new Color(textDisplay3.color.r, textDisplay3.color.g, textDisplay3.color.b, alpha);
            textDisplay4.color = new Color(textDisplay4.color.r, textDisplay4.color.g, textDisplay4.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }
}