using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timePerQuestion;
    Text timerText;
    public int amountOfDots;

    [System.NonSerialized]
    public bool timerSet;
    [System.NonSerialized]
    public float timePerDot;
    [System.NonSerialized]
    public float lastTime;

    private void Start()
    {
        timerText = this.gameObject.GetComponentInChildren<Text>();
        timePerDot = timePerQuestion / amountOfDots;
        lastTime = timePerQuestion;
    }

    void Update()
    {
        //if the timer not is set than dont substract
        if (timerSet)
        {
            timePerQuestion -= Time.deltaTime;
            timerText.text = timePerQuestion.ToString("f0");
            if (timePerQuestion <= 0)
            {
                timerSet = false;
                TimeUp();
            }
        }
    }

    public void setTimer()
    {
        timerSet = true;
    }

    void TimeUp()
    {
        throw new Exception();
    }
}
