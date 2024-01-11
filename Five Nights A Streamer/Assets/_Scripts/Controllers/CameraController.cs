using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Serializable]
    private struct Cam
    {
        public Camera cam;
        public GameObject trigger;
    }

    [SerializeField] Cam[] cams;
    private int currentCam;

    void Start()
    {
        currentCam = 0;
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
        Debug.Log("Prev cam");
        cams[currentCam].cam.enabled = false;
        currentCam++;
        if (currentCam > cams.Length - 1)
        {
            currentCam = 0;
            cams[currentCam].cam.enabled = true;
        }
        else
        {
            cams[currentCam].cam.enabled = true;
        }
        
    }

    public void decCamera()
    {
        Debug.Log("Next cam");
        cams[currentCam].cam.enabled = false;
        currentCam--;
        if (currentCam < 0)
        {
            currentCam = cams.Length-1;
            cams[currentCam].cam.enabled = true;
        }
        else
        {
            cams[currentCam].cam.enabled = true;
        }
        
    }
}
