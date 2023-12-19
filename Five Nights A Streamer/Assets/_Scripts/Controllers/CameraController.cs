using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject cam1;
    [SerializeField] GameObject cam2;
    [SerializeField] GameObject cam3;
    [SerializeField] GameObject cam4;
    [SerializeField] GameObject cam5;
    [SerializeField] GameObject cam6;
    [SerializeField] GameObject cam7;
    [SerializeField] GameObject cam8;


    void Start()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(false);
        cam5.SetActive(false);
        cam6.SetActive(false);
        cam7.SetActive(false);
        cam8.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
        }
        if(Input.GetKeyDown("2")) 
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
        }
        if(Input.GetKeyDown("3"))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(true);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
        }
        if (Input.GetKeyDown("4"))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(true);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
        }
        if (Input.GetKeyDown("5"))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(true);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(false);
        }
        if (Input.GetKeyDown("6"))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(true);
            cam7.SetActive(false);
            cam8.SetActive(false);
        }
        if (Input.GetKeyDown("7"))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(true);
            cam8.SetActive(false);
        }
        if (Input.GetKeyDown("8"))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
            cam6.SetActive(false);
            cam7.SetActive(false);
            cam8.SetActive(true);
        }
    }
}
