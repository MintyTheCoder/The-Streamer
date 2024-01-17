using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource source;
    Collider soundTrigger;

    void Start()
    {
        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        source.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        source.Stop();
    }
}
