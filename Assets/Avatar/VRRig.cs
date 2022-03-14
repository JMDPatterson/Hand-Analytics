using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make VRMap class visible in Unity Inspector window
[System.Serializable]

// Align character mesh to match animation targets and VR controller and headset transforms.
public class VRMap
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}
public class VRRig : MonoBehaviour
{
    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;

    public Transform headConstraint;    // variable to define transform of Head IK transform
    public Vector3 headBodyOffset;      // difference between head and body positions

    // Start is called before the first frame update
    void Start()
    {
        headBodyOffset = transform.position - headConstraint.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Define new transform position according to head offset and align Y (up) axis of head and body
        transform.position = headConstraint.position + headBodyOffset;
        transform.forward = Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized;

        // Enable tracking and rotation offset positions to be defined in Unity Inspector window
        head.Map();
        leftHand.Map();
        rightHand.Map();
    }
}
