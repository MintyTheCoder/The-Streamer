using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private HingeJoint hingeJoint;
    private float hingeLimit;
    private float angleThreshold = 0.5f;
    public Boolean isDoorClosed;

    // Start is called before the first frame update
    void Start()
    {
        hingeJoint = GetComponentInChildren<HingeJoint>();
        hingeLimit = hingeJoint.limits.min; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(hingeJoint.angle - hingeLimit) <= angleThreshold)
        {
            isDoorClosed = true;
        }
    }
}
