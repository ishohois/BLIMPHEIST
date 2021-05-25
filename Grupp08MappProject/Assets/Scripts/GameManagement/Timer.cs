using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    bool timerActive;
    float currentTime; 
    string endTime;

    void Awake()
    {
        timerActive = true; 
        currentTime = 0;
    }

    void Update()
    {
        if (timerActive == true) 
        {
            currentTime = currentTime + Time.deltaTime;
            //Debug.Log("Timer running");
        }
    }

    public String EndTimer()
    {
        timerActive = false;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        String endTime = time.Minutes.ToString();
        if (time.Seconds < 10)
        {
            endTime += ":0" + time.Seconds.ToString();
        }
        else
        {
            endTime += ":" + time.Seconds.ToString();
        }
        return endTime;
    }

    public int GetSeconds()
    {
        return TimeSpan.FromSeconds(currentTime).Seconds;
    }
    public int GetTimeInSeconds()
    {
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        int timeInSeconds = (int)time.TotalSeconds;
        return timeInSeconds;
    }
}
