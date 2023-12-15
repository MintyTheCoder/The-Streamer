using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SetVolume : MonoBehaviour
{
    public AudioMixer Mixer;
    public  float SliderValue = 0.5f;

    public void SetLevel (float Slidervalue)
    { 
        Mixer.SetFloat("MusicVol", Mathf.Log10(SliderValue) *20);
    }
}
