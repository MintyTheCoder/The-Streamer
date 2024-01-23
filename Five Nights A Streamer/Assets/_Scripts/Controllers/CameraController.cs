using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    [SerializeField] Camera[] cams;
    GameObject[] camObjects;
    private int currentCam;

    void Start()
    {
        currentCam = 0;
        cams = GameObject.FindObjectsOfType<Camera>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            incCamera();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            decCamera();
        }
    }

    public void incCamera()
    {
        Debug.Log("Next cam");
        cams[currentCam].enabled = false;
        currentCam++;
        if (currentCam > cams.Length - 1)
        {
            currentCam = 0;
            cams[currentCam].enabled = true;
        }
        else
        {
            cams[currentCam].enabled = true;
        }
        
    }

    public void decCamera()
    {
        Debug.Log("Prev cam");
        cams[currentCam].enabled = false;
        currentCam--;
        if (currentCam < 0)
        {
            currentCam = cams.Length-1;
            cams[currentCam].enabled = true;
        }
        else
        {
            cams[currentCam].enabled = true;
        }
        
    }
}
