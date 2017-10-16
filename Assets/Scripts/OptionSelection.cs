using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionSelection : MonoBehaviour {


    GameObject managerObject; 
    DialogueManager manager;

    // Use this for initialization
    void Start ()
    {
        managerObject = GameObject.Find("Dialoog");
        manager = managerObject.GetComponent<DialogueManager>();
    }


    public void OnClick(Button button)
    {
        if (button.name == "Option1")
        {
            manager.selectedOption = 1;
        }
        if (button.name == "Option2")
        {
            manager.selectedOption = 2;
        }
        if (button.name == "Option3")
        {
            manager.selectedOption = 3;
        }
        if (button.name == "Option4")
        {
            manager.selectedOption = 4;
        }
    }

    public void OnRelease(Button button)
    {
        manager.questionCounter++;
    }
}
