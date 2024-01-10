using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPresencePhysics : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;
    public Renderer nonPhysicalHand;
    public float showNonPhysicalHandDistance = 0.05f;
    private Collider[] handColliders;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        handColliders = GetComponentsInChildren<Collider>();
    }

    public void EnableHandCollider()
    {
        foreach (Collider collider in handColliders) 
        {
            collider.enabled = true;
        }
    }

    public void EnableHandColliderDelay(float delay)
    {
        Invoke("EnableHandCollider", delay);
    }

    public void DisableHandCollider()
    {
        foreach (Collider collider in handColliders)
        {
            collider.enabled = false;
        }
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > showNonPhysicalHandDistance)
        {
            nonPhysicalHand.enabled = true;
        }

        else
        {
            nonPhysicalHand.enabled = false;
        }
    }

    void FixedUpdate()
    {
        //position
        //rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;

        //rotation
        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        Vector3 rotationDifferenceInDegree = angleInDegree * rotationAxis;

        rb.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);

        // Position
        rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;

        /*// Rotation
        Quaternion rotationDifference = Quaternion.Inverse(transform.rotation) * target.rotation;

        // Extract the rotation axis
        Vector3 rotationAxis;
        float rotationAngle;
        rotationDifference.ToAngleAxis(out rotationAngle, out rotationAxis);

        // Set the angular velocity using the rotation axis
        rb.angularVelocity = (rotationAxis * rotationAngle * Mathf.Deg2Rad / Time.fixedDeltaTime);*/
    }
}
