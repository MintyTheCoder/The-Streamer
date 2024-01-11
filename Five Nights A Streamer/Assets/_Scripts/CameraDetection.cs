using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetection : MonoBehaviour
{
    Camera camera;
    MeshRenderer meshRenderer;
    Plane[] cameraFrustum;
    Bounds bounds;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        bounds = GetComponent<Collider>().bounds;
    }

    // Update is called once per frame
    void Update()
    {
        camera = GameObject.FindGameObjectWithTag("Security Cams").GetComponent<Camera>();
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(camera);

        if(GeometryUtility.TestPlanesAABB(cameraFrustum, bounds)) 
        { 
        
        }
    }
}
