using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Script to calculate various metrics relating to Oculus hand tracking
public class Calculator : MonoBehaviour
{
    [Header("Wrist Transform tracker")]
    [SerializeField]
    private TextMeshProUGUI leftTranformText;
    [SerializeField]
    private TextMeshProUGUI rightTransformText;
    public Transform leftWristTransform;
    public Transform rightWristTransform;
    [SerializeField]
    private Stopwatch sessionTimer;

    // Declare Left Wrist rotation variables
    private float lYCum = 0;
    private float lXCum = 0;
    private float lZCum = 0;
    private Vector3 lPrevRotationVec;
    private Vector3 lCurrentRotationVec;

    // Declare Right Wrist rotation variables
    private float rYCum = 0;
    private float rXCum = 0;
    private float rZCum = 0;
    private Vector3 rPrevRotationVec;
    private Vector3 rCurrentRotationVec;

    // Declare a tolerance value for measuring angle changes
    public float angTolerance;

    private void OnEnable()
    {
        // When calculator is enabled, read starting XYZ rotation values (deg) for desired transforms
        lPrevRotationVec = leftWristTransform.eulerAngles;
        rPrevRotationVec = rightWristTransform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        // Read XYZ rotation values (deg) for this frame
        lCurrentRotationVec = leftWristTransform.eulerAngles;
        rCurrentRotationVec = rightWristTransform.eulerAngles;
        // Calculate cumulative unsigned angle difference for X, Y and Z based on previous frame 
        // Left Wrist
        float lXDiff = (180 - Mathf.Abs(Mathf.Abs(lCurrentRotationVec.x - lPrevRotationVec.x) - 180));
        lXCum += lXDiff <= angTolerance ? 0 : lXDiff;
        float lYDiff = (180 - Mathf.Abs(Mathf.Abs(lCurrentRotationVec.y - lPrevRotationVec.y) - 180));
        lYCum += lYDiff <= angTolerance ? 0 : lYDiff;
        float lZDiff = (180 - Mathf.Abs(Mathf.Abs(lCurrentRotationVec.z - lPrevRotationVec.z) - 180));
        lZCum += lZDiff <= angTolerance ? 0 : lZDiff;
        // Right Wrist
        float rXDiff = (180 - Mathf.Abs(Mathf.Abs(rCurrentRotationVec.x - rPrevRotationVec.x) - 180));
        rXCum += rXDiff <= angTolerance ? 0 : rXDiff;
        float rYDiff = (180 - Mathf.Abs(Mathf.Abs(rCurrentRotationVec.y - rPrevRotationVec.y) - 180));
        rYCum += rYDiff <= angTolerance ? 0 : rYDiff;
        float rZDiff = (180 - Mathf.Abs(Mathf.Abs(rCurrentRotationVec.z - rPrevRotationVec.z) - 180));
        rZCum += rZDiff <= angTolerance ? 0 : rZDiff;

        // Write Left Wrist rotation data to GUI
        leftTranformText.text = string.Format(@"Total Pronation/Supination Travel (deg) {0:0}:
Total Extension/Flexion Travel (deg) {1:0}: 
Total Radial/Ulnar Travel (deg) {2:0}:

Avg Pronation/Supination Travel (deg/s) {3:00}:
Avg Extension/Flexion Travel (deg/s) {4:00}:
Avg Radial/Ulnar Travel (deg/s) {5:00}:"
, lXCum, lZCum, lYCum, lXCum / sessionTimer.currentTime, lZCum / sessionTimer.currentTime, lYCum / sessionTimer.currentTime);

        // Write Right Wrist rotation data to GUI
        rightTransformText.text = string.Format(@"Total Pronation/Supination Travel (deg) {0:0}: 
Total Extension/Flexion Travel (deg) {1:0}: 
Total Radial/Ulnar Travel (deg) {2:0}:

Avg Pronation/Supination Travel (deg/s) {3:00}:
Avg Extension/Flexion Travel (deg/s) {4:00}:
Avg Radial/Ulnar Travel (deg/s) {5:00}:"
, rXCum, rZCum, rYCum, rXCum/sessionTimer.currentTime, rZCum/sessionTimer.currentTime, rYCum/sessionTimer.currentTime);

        // Update previous frame rotation vector
        lPrevRotationVec = leftWristTransform.eulerAngles;
        rPrevRotationVec = rightWristTransform.eulerAngles;
    }
}
