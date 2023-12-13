using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BrightnessFading : MonoBehaviour
{
    public Image Image;
    public Slider BrightnessSlider;

    //Changing the a value of the image to change the brightness of the scene
    void Update()
    {
        Image = GetComponent<Image>();
        var TempColor = Image.color;
        TempColor.a = BrightnessSlider.value;
        Image.color = TempColor;
    }
}
