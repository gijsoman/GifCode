using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timePerQuestion;
    public int amountOfDots;

    float currentTime;
    Text timerText;

    public GameObject dotPrefab;

    RectTransform timerRect;
    RectTransform dotRect;

    void Awake()
    {
        timerRect = this.gameObject.GetComponent<RectTransform>();
        UITimer.amountOfDots = amountOfDots;
        CreateDots(dotPrefab);
    }

    void Start()
    {
        timerText = this.gameObject.GetComponentInChildren<Text>();
        UITimer.timePerDot = timePerQuestion / amountOfDots;
    }

    void Update()
    {
        if (!TimeUp())
        {
            currentTime -= Time.deltaTime;
            timerText.text = currentTime.ToString("f0");
            UITimer.DisableDotsOnTime(currentTime);
        }
        else
        {
            Debug.Log("Time is up");
            SceneManager.LoadScene(0);
        }
        
    }

    public void SetTimer()
    {
        UITimer.ResetAnimatorBools();
        UITimer.EnableAllDots();
        UITimer.amountOfEnabledDots = amountOfDots;
        UITimer.lastTime = currentTime = timePerQuestion;
    }

    bool TimeUp()
    { 
        if (currentTime <= 0)
        {
            UITimer.DisableAllDots();
            UITimer.ResetAnimatorBools();
            return true;
        }
        else{ return false; }
    }

    void CreateDots(GameObject dotPrefab)
    {
        UITimer.dots.Clear();
        UITimer.animators.Clear();
        for (int i = 0; i < amountOfDots; i++)
        {
            GameObject dot = Instantiate(dotPrefab) as GameObject;
            UITimer.dots.Add(dot);
            UITimer.animators.Add(dot.GetComponent<Animator>());
            dotRect = dot.GetComponent<RectTransform>();
            dot.transform.parent = this.transform;
            dot.transform.localPosition = new Vector2(timerRect.rect.x + dotRect.rect.size.x / 2 + (dotRect.rect.size.x * i), timerRect.rect.y + dotRect.rect.size.y / 2);
        }
    }
}
