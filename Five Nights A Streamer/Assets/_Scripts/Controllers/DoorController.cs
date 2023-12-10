using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Used to control aspects of the door
/// </summary>
/// <remarks>Requires a HingeJoint and XRGrabInteractable component</remarks>
[RequireComponent(typeof(HingeJoint))]
[RequireComponent(typeof(XRGrabInteractable))]
public class DoorController : MonoBehaviour
{
    private HingeJoint hingeJoint;
    private float hingeLimit;
    [SerializeField] float angleThreshold = 0.5f;
    public bool IsDoorClosed {get; private set;}

    // Start is called before the first frame update
    void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        hingeLimit = hingeJoint.limits.min;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(hingeJoint.angle - hingeLimit) <= angleThreshold)
        {
            IsDoorClosed = true;
            Debug.Log("Closed");
        }
    }
}
