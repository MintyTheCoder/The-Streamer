using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] Camera[] cams;
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
        cams[currentCam].enabled = false;
        currentCam++;
        if (currentCam > cams.Length)
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
