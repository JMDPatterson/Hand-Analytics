using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

// Stopwatch script to track passing of time via Unity Events
public class Stopwatch : MonoBehaviour
{
    bool stopwatchActive = false;
    [HideInInspector]
    public float currentTime;
    [SerializeField]
    private TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;    // Sets stopwatch to 0 on start
    }

    // Update is called once per frame
    void Update()
    {
        if (stopwatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
            int min = (int)(currentTime / 60);
            int sec = (int)(currentTime % 60);
            int msec = (int)((currentTime - (int)currentTime) * 100);
            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", min, sec, msec); // Writes current time in min:sec:msec format to GUI
        }
    }

    // Method to unpause stopwatch
    public void StartStopwatch()
    {
        stopwatchActive = true;
    }

    // Method to pause stopwatch
    public void StopStopwatch()
    {
        stopwatchActive = false;
    }
}
