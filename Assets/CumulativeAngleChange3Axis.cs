using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CumulativeAngleChange3Axis : MonoBehaviour
{
    [Header("Transform rotation tracker")]
    [SerializeField]
    private TextMeshProUGUI transformText;
    [SerializeField]
    private Stopwatch sessionTimer;
    public Transform parent;
    public Transform child;

    // Declare rotation variables
    private float prevAng;
    private float currentAng;
    private float cumAng;

    // Declare a tolerance value for measuring angle changes
    public float angTolerance = 0.4f;

    private void OnEnable()
    {
        // When calculator is enabled, read starting XYZ rotation values (deg) for desired transforms
        prevAng = Quaternion.Angle(parent.rotation, child.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        //// Cumulative wrist angle calculator

        // Read XYZ rotation values (deg) for this frame
        currentAng = Quaternion.Angle(parent.rotation, child.rotation);

        // Calculate cumulative unsigned angle difference for X, Y and Z based on previous frame
        float diff = (180 - Mathf.Abs(Mathf.Abs(currentAng - prevAng) - 180));
        cumAng += diff <= angTolerance ? 0 : diff;


        // Write Wrist rotation data to GUI
        transformText.text = string.Format(@"Total Rotation: {0:0.0} (deg)
Avg Rotation: {1:0.0} (deg/s)"
, cumAng, cumAng / sessionTimer.currentTime);

        // Update previous frame rotation vector
        prevAng = Quaternion.Angle(parent.rotation, child.rotation);
    }
}