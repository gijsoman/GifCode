using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {
 
    public GameObject clientTextBox;
    public GameObject[] userOptionsButtons;
    Text clientText;
    Text[] userOptionsText = new Text[4];

    //the text for the options of the players
    string[] options = new string[4];

    //question: contains question that shows in dialogue box
    //questionCounter: remember at what question we are. edited from the OptionSelection script
    //selectedOption: contains the selected option of the current question. edited from the OptionSelection script
    //previousAsked: From what question did you come here?
    string question;
    public int questionCounter = 0;
    public int selectedOption = 0;
    int previousAsked;

	// Use this for initialization
	void Start () {
        //get the text components from all the objects
        clientText = clientTextBox.GetComponent<Text>();
        for (int i = 0; i < userOptionsButtons.Length; i++)
        {
            userOptionsText[i] = userOptionsButtons[i].GetComponentInChildren<Text>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        //reload scene for debugging purposes
        if (Input.GetKey("space"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //set all the texts
        clientText.text = question;
        for (int i = 0; i < userOptionsText.Length; i++)
        {
            userOptionsText[i].text = options[i]; 
        }

        //Dialogue
        switch (questionCounter)
        {
            case 0:
                AskNewQuestion("He hallo, ik voel me niet zo lekker...", "Oh wat vervelend", "Boeit me niks", "Oke", "");
                break;
            case 1:
                if (selectedOption == 1)
                {
                    AskNewQuestion("Ja... ik weet niet zo goed wat ik moet doen.", "HAHAHHAHAHA IK OOK NIET", "", "", "");
                    previousAsked = 1;
                }
                else
                {
                    AskNewQuestion("JA, wattefak reageer eens wat leuker.", "Sorry...Ik bedoelde het niet zo.", "Nee.....:)", "", "");
                    previousAsked = 2;
                }
                break;
            case 2:
                if (previousAsked == 1 && selectedOption == 1)
                {
                    AskNewQuestion("Jij vieze hond", "Ja, best wel", "", "", "");
                    previousAsked = 1;
                }
                if (previousAsked == 2 && (selectedOption == 1 || selectedOption == 2))
                {
                    AskNewQuestion("Henkie is boos weggelopen....", "", "", "", "");
                }
                break;
            case 3:
                //new questions here
                break;
            case 4:
                //new questions here
                break;
            case 5:
                //new questions here
                break;
            case 6:
                //new questions here
                break;
        }
    }

    void AskNewQuestion(string askQuestion, string option1, string option2, string option3, string option4)
    {
        question = askQuestion;
        options[0] = option1;
        options[1] = option2;
        options[2] = option3;
        options[3] = option4;
    }
}
