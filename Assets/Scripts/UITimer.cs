using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public static class UITimer
{
    public static float timePerDot;
    public static List<GameObject> dots = new List<GameObject>();

    public static int amountOfEnabledDots;

    public static List<Animator> animators = new List<Animator>();

    public static int amountOfDots;

    public static float lastTime;

    public static void DisableAllDots()
    {
        for (int i = 0; i < dots.Count; i++)
        {
            dots[i].gameObject.SetActive(false);
        }
    }

    public static void EnableAllDots()
    {
        for (int i = 0; i < dots.Count; i++)
        {
            dots[i].gameObject.SetActive(true);
        }
    }

    public static void DisableDotsOnTime(float currentTime)
    {
        if (currentTime <= lastTime - timePerDot)
        {
            dots[amountOfEnabledDots - 1].gameObject.SetActive(false);
            lastTime = currentTime;
            amountOfEnabledDots--;
        }
        if (currentTime <= lastTime - timePerDot + 0.9)
        {
            if (animators[amountOfEnabledDots - 1].GetBool("MayBreak") != true)
            {
                animators[amountOfEnabledDots - 1].SetBool("MayBreak", true);
            }
        }
    }

    public static void ResetAnimatorBools()
    {
        for (int i = 0; i < amountOfDots; i++)
        {
            animators[i].SetBool("MayBreak", false);
            animators[i].Rebind();
        }
    }
}
