using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CumulativeAngleCalculator : MonoBehaviour
{
    [Header("Transform rotation tracker")]
    [SerializeField]
    private TextMeshProUGUI transformText;
    [SerializeField]
    private Stopwatch sessionTimer;
    public Transform trackTransform;

    // Declare Left Wrist rotation variables
    private float yCum = 0;
    private float xCum = 0;
    private float zCum = 0;
    private Vector3 prevRotationVec;
    private Vector3 currentRotationVec;

    // Declare a tolerance value for measuring angle changes
    public float angTolerance = 0;
    private void OnEnable()
    {
        // When calculator is enabled, read starting XYZ rotation values (deg) for desired transforms
        prevRotationVec = trackTransform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //// Cumulative wrist angle calculator

        // Read XYZ rotation values (deg) for this frame
        currentRotationVec = trackTransform.eulerAngles;
        // Calculate cumulative unsigned angle difference for X, Y and Z based on previous frame 
        // Left Wrist
        float lXDiff = (180 - Mathf.Abs(Mathf.Abs(currentRotationVec.x - prevRotationVec.x) - 180));
        xCum += lXDiff <= angTolerance ? 0 : lXDiff;
        float lYDiff = (180 - Mathf.Abs(Mathf.Abs(currentRotationVec.y - prevRotationVec.y) - 180));
        yCum += lYDiff <= angTolerance ? 0 : lYDiff;
        float lZDiff = (180 - Mathf.Abs(Mathf.Abs(currentRotationVec.z - prevRotationVec.z) - 180));
        zCum += lZDiff <= angTolerance ? 0 : lZDiff;

        // Write Left Wrist rotation data to GUI
        transformText.text = string.Format(@"Total Pronation/Supination Travel (deg) {0:0}:
Total Extension/Flexion Travel (deg) {1:0}: 
Total Radial/Ulnar Travel (deg) {2:0}:

Avg Pronation/Supination Travel (deg/s) {3:00}:
Avg Extension/Flexion Travel (deg/s) {4:00}:
Avg Radial/Ulnar Travel (deg/s) {5:00}:"
, xCum, zCum, yCum, xCum / sessionTimer.currentTime, zCum / sessionTimer.currentTime, yCum / sessionTimer.currentTime);

        // Update previous frame rotation vector
        prevRotationVec = trackTransform.eulerAngles;
    }
}