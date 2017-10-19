using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Stopwatch stopwatch = new Stopwatch();
    long curTime = 0;
    long maxTime = 0;
    // DISPLAY ON SCREEN: (maxTime - curTime) / 1000
    // END SCORE SCREEN: curTime / 1000 (or beautify)
    // TEXT FIELD OR CLOCK LINK TO UNITY
    Text timerText;

    private void Start()
    {
        timerText = this.gameObject.GetComponentInChildren<Text>();
        stopwatch.Start();
    }

    // Update is called once per frame
    void Update()
    {
        curTime = stopwatch.ElapsedMilliseconds;
        if (curTime > maxTime)
        {
            TimeUp();
        }
        timerText.text = ((maxTime - curTime) / 1000).ToString();
    }

    public void setTimer(int time)
    {
        time *= 1000;
        maxTime = stopwatch.ElapsedMilliseconds + time;
        curTime = stopwatch.ElapsedMilliseconds;
    }

    void TimeUp()
    {
        throw new Exception();
    }
}
