using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //We can give in a time in the editor
    public float timePerQuestion;
    public int amountOfDots;

    //We want a local variable to keep track of the time and not the in editor variable when we set the timer again.
    float currentTime;
    Text timerText;

    //We need a dot prefab and a list where we put instantiated dots in.
    public GameObject dotPrefab;
    List<GameObject> dots = new List<GameObject>();

    //some variables for dot placement.
    RectTransform timerRect;
    RectTransform dotRect;

    //we need to check if the timer is set before we start removing dots.
    // bool timerSet;

    //to keep track of the last time a dot was removed
    float lastTime;

    //to figure out how much time a dot has for lifetime
    float timePerDot;

    //to keep track of the amount of disabled dots
    int amountOfEnabledDots;

    //We need to edit parameters of the animator
    List<Animator> animators = new List<Animator>();

    void Awake()
    {
        timerRect = this.gameObject.GetComponent<RectTransform>();
        CreateDots(dotPrefab);
    }
    void Start()
    {
        timerText = this.gameObject.GetComponentInChildren<Text>();
        timePerDot = timePerQuestion / amountOfDots;
    }

    void Update()
    {
        if (!TimeUp())
        {
            currentTime -= Time.deltaTime;
            timerText.text = currentTime.ToString("f0");
            DisableDotsOnTime();
        }
        else
        {
            Debug.Log("Time is up");
        }
        
    }

    public void SetTimer()
    {
        EnableAllDots();
        amountOfEnabledDots = amountOfDots;
        currentTime = timePerQuestion;
        lastTime = currentTime;
    }

    bool TimeUp()
    { 
        if (currentTime <= 0)
        {
            DisableAllDots();
            ResetAnimatorBools();
            return true;
        }
        else{ return false; }
    }

    void CreateDots(GameObject dotPrefab)
    {
        for (int i = 0; i < amountOfDots; i++)
        {
            GameObject dot = Instantiate(dotPrefab) as GameObject;
            dots.Add(dot);
            animators.Add(dot.GetComponent<Animator>());
            dotRect = dot.GetComponent<RectTransform>();
            dot.transform.parent = this.transform;
            dot.transform.localPosition = new Vector2(timerRect.rect.x + dotRect.rect.size.x / 2 + (dotRect.rect.size.x * i), timerRect.rect.y + dotRect.rect.size.y / 2);
        }
    }

    void DisableAllDots()
    {
        for (int i = 0; i < amountOfDots; i++)
        {
            dots[i].gameObject.SetActive(false);
        }
    }

    void EnableAllDots()
    {
        for (int i = 0; i < amountOfDots; i++)
        {
            dots[i].gameObject.SetActive(true);
        }
    }

    void DisableDotsOnTime()
    {
        if (currentTime <= lastTime - timePerDot)
        {
            dots[amountOfEnabledDots - 1].gameObject.SetActive(false);
            lastTime = currentTime;
            amountOfEnabledDots--;
        }
        if (currentTime <= lastTime - timePerDot + 0.9)
        {
            if (animators[amountOfEnabledDots -1].GetBool("MayBreak") != true)
            {
                animators[amountOfEnabledDots - 1].SetBool("MayBreak", true);
            }
        }
    }

    void ResetAnimatorBools()
    {
        for (int i = 0; i < amountOfDots; i++)
        {
            animators[i].SetBool("MayBreak", false);
        }
    }
}
