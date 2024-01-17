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

    private void OnCollisionEnter(Collision collision)
    {
        source.Play();
    }

    private void OnCollisionExit(Collision collision)
    {
        source.Stop();
    }

}
