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

    // Declare rotation variables
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
        prevRotationVec = trackTransform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //// Cumulative wrist angle calculator

        // Read XYZ rotation values (deg) for this frame
        currentRotationVec = trackTransform.localEulerAngles;

        // Calculate cumulative unsigned angle difference for X, Y and Z based on previous frame
        float xDiff = (180 - Mathf.Abs(Mathf.Abs(currentRotationVec.x - prevRotationVec.x) - 180));
        xCum += xDiff <= angTolerance ? 0 : xDiff;
        float yDiff = (180 - Mathf.Abs(Mathf.Abs(currentRotationVec.y - prevRotationVec.y) - 180));
        yCum += yDiff <= angTolerance ? 0 : yDiff;
        float zDiff = (180 - Mathf.Abs(Mathf.Abs(currentRotationVec.z - prevRotationVec.z) - 180));
        zCum += zDiff <= angTolerance ? 0 : zDiff;

        // Write Wrist rotation data to GUI
        transformText.text = string.Format(@"Total Radial/Ulnar Travel (deg) {0:0}:
Total Pronation/Supination Travel (deg) {1:0}: 
Total Extension/Flexion Travel (deg) {2:0}:
Avg Pronation/Supination Travel (deg/s) {3:00}:
Avg Radial/Ulnar Travel (deg/s) {4:00}:
Avg Extension/Flexion Travel (deg/s) {5:00}:"
, xCum, yCum, zCum, xCum / sessionTimer.currentTime, yCum / sessionTimer.currentTime, zCum / sessionTimer.currentTime);

        // Update previous frame rotation vector
        prevRotationVec = trackTransform.localEulerAngles;
    }
}