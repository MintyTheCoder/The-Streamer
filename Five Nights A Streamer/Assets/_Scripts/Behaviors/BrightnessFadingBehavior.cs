using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BrightnessFadingBehavior : MonoBehaviour
{
    public Image ImageObj;
    public Slider BrightnessSlider;

    //Changing the a value of the image to change the brightness of the scene
    void Update()
    {
        ImageObj = GetComponent<Image>();
        if (ImageObj != null)
        {
            var TempColor = ImageObj.color;
            TempColor.a = BrightnessSlider.value;
            ImageObj.color = TempColor;
            if (TempColor.a >= 0.9f)
            {
                TempColor.a = 0.9f;
                ImageObj.color = TempColor;
            }
        }

        
    }
}
