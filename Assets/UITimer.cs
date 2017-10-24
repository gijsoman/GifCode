using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITimer : MonoBehaviour {

    public GameObject timerDot;
    List<GameObject> dots;
    RectTransform timerRect;
    RectTransform dotRect;
    Timer timer;

    int amountOfDisabled;

    float currentTime;

    float xIncreaser;

    bool dotsShown;

	void Start () {
        timer = this.GetComponent<Timer>();
        timerRect = this.GetComponent<RectTransform>();
        dots = new List<GameObject>();
        amountOfDisabled = timer.amountOfDots;
	}
	
	void Update () {
        ShowDots(timerDot);
	}

    void ShowDots(GameObject dot)
    {
        if (!dotsShown)
        {
            for (int i = 0; i < timer.amountOfDots; i++)
            {
                GameObject childObject = Instantiate(dot) as GameObject;
                dots.Add(childObject);
                dotRect = dot.GetComponent<RectTransform>();
                xIncreaser = dotRect.rect.size.x * i;
                childObject.transform.parent = this.transform;
                childObject.transform.localPosition = new Vector2(timerRect.rect.x + dotRect.rect.size.x / 2 + xIncreaser, timerRect.rect.y + dotRect.rect.size.y / 2);
            }
            dotsShown = true;
        }
        if (dotsShown && timer.timerSet)
        {
            if (timer.timePerQuestion <= timer.lastTime - timer.timePerDot)
            {
                dots[amountOfDisabled-1].gameObject.SetActive(false);
                timer.lastTime = timer.timePerQuestion;
                amountOfDisabled--;
            }
        }


    }

}
