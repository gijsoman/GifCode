using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    GameObject menu;
    Animator animator;
	// Use this for initialization
	void Start () {
        menu = GameObject.Find("Menu");
        animator = menu.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void OnClick(Button button)
    {
        if (button.name == "MenuBurger")
        {
            animator.SetBool("SlideOut", false);
            animator.SetBool("SlideIn", true);
        }
        if (button.name == "MenuCross")
        {
            animator.SetBool("SlideIn", false);
            animator.SetBool("SlideOut", true);
        }
    }
}
