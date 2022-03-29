using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

// Script to define Unity Events which trigger start and end of test sessions via Key press.
public class EventManager : MonoBehaviour
{
    private bool isStarted = false;     // Boolean for if session has started
    private bool isEnded = false;       // Boolean for if session has ended
    [SerializeField]
    private UnityBoolEvent sessionStart = new UnityBoolEvent();
    [SerializeField]
    private UnityBoolEvent sessionEnd = new UnityBoolEvent();

    private void Update()
    {
        // Start session
        if (Input.GetKeyDown(KeyCode.Keypad1))  
        {
            sessionStart?.Invoke(isStarted);    // Triggers Session Start event
        }
        // End session
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            sessionEnd?.Invoke(isEnded);    // Triggers Session End event
        }
    }

    // Define boolean Unity Event (to make Event field serializable)
    [Serializable]
    public class UnityBoolEvent : UnityEvent<bool> { }
}
