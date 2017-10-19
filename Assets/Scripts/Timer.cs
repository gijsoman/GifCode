using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System;

public class Timer : MonoBehaviour
{
    Stopwatch stopwatch = new Stopwatch();
    long curTime = 0;
    long maxTime = 0;
    // DISPLAY ON SCREEN: (maxTime - curTime) / 1000
    // END SCORE SCREEN: curTime / 1000 (or beautify)
    // TEXT FIELD OR CLOCK LINK TO UNITY

    private void Start()
    {
        // FIND UNITY TEXT FIELD
    }

    // Update is called once per frame
    void Update()
    {
        curTime = stopwatch.ElapsedMilliseconds;
        if (curTime > maxTime)
        {
            TimeUp();
        }
        // UnityClock.text = (maxTime - curTime) / 1000;
    }

    public void setTimer(int time)
    {
        maxTime = stopwatch.ElapsedMilliseconds + time;
        curTime = stopwatch.ElapsedMilliseconds;
    }

    void TimeUp()
    {
        throw new Exception();
    }
}
