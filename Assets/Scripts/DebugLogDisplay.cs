using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLogDisplay : MonoBehaviour
{
    public string output = "";
    public string stack = "";


    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;

    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    { 
    output = logString;
    stack = stackTrace;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(800, 5, 800, 600), output);
        GUI.Label(new Rect(800, 105, 800, 60), stack);
    }
}