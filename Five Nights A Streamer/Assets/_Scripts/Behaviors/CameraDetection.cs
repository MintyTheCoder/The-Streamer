using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CameraDetection : MonoBehaviour
{
    private Camera camera;
    [SerializeField] AudioSource source;
    private MeshRenderer meshRenderer;
    private Plane[] cameraFrustum;
    private Bounds bounds;
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
            source.Play();   
        }
    }
}
