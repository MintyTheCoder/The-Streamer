using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRButton : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;

    Material material;

    GameObject presser;
    AudioSource sound;
    bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
        //material = button.GetComponent<Material>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!isPressed) 
        {
            button.transform.localPosition -= new Vector3(0.001f, 0, 0.001f);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;

            //material.color -= new Color(0, 0, 0, 10);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == presser)
        {
            button.transform.localPosition += new Vector3(0.001f, 0, 0.001f);
            onRelease.Invoke();
            isPressed = false;
        }
    }
}
