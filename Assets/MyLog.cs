using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MyLog : MonoBehaviour
{
    string myLog;
    Queue myLogQueue = new Queue();
    public Text logtxt;

    void Start(){

    }

    void OnEnable () {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable () {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type){
        myLog = logString;
        string newString = "\n [" + type + "] : " + myLog;
        myLogQueue.Enqueue(newString);
        if (type == LogType.Exception)
        {
            newString = "\n" + stackTrace;
            myLogQueue.Enqueue(newString);
        }
        myLog = string.Empty;
        foreach(string mylog in myLogQueue){
            myLog += mylog;
        }
    }

    void OnGUI () {
        logtxt.text = myLog;
    }
}