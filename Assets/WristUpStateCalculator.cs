using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WristUpStateCalculator : MonoBehaviour
{
    [Header("Wrist 'Up' State calculator")]
    [SerializeField]
    private TextMeshProUGUI percentText;
    [SerializeField]
    private Stopwatch wristUpStateTimer;
    [SerializeField]
    private Stopwatch sessionTimer;
    private float percentTime;

    // Update is called once per frame
    void Update()
    {
        //// Wrist 'Up' State calculator
        percentTime = wristUpStateTimer.currentTime / sessionTimer.currentTime * 100;   // Compares total time spent in 'Up' state to total Session time
        percentText.text = string.Format("{0:0} %", percentTime);                       // Writes percentTime to Output GUI
    }
}
