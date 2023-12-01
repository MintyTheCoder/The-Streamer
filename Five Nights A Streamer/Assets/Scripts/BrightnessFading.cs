using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BrightnessFading : MonoBehaviour
{
    public Image image;
    public Slider brightnessSlider;
    // Start is called before the first frame update
    void Update()
    {
       image = GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = brightnessSlider.value;
        image.color = tempColor;
    }
}
