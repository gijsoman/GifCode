using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public class DialogueManager : MonoBehaviour {
 
    public GameObject clientTextBox;
    public GameObject[] userOptionsButtons;
    Text clientText;
    Text[] userOptionsText = new Text[4];
    List<Question> questions;

    public Question currentQuestion;

	// Use this for initialization
	void Start () {
        questions = InitializeQuestions();
        currentQuestion = questions[0];
        //get the text components from all the objects
        clientText = clientTextBox.GetComponent<Text>();
        for (int i = 0; i < userOptionsButtons.Length; i++)
        {
            userOptionsText[i] = userOptionsButtons[i].GetComponentInChildren<Text>();
        }
        SetText();
    }
	
	// Update is called once per frame
	void Update () {
        //reload scene for debugging purposes
        if (Input.GetKey("space"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private static List<Question> InitializeQuestions()
    {
        //return questions from somewhere else
        return QuestionInitializer.InitializeQuestions();
    }

    public void OnClick(Button button)
    {
        //currentQuestion = questions[int.Parse(button.name.Substring(button.name.Length - 2))];
        //added some errorhandling  if there is no text on the button there is no answer so i dont want to set my currentquestion
        if (button.name == "Option1" && questions.Count > 1 && userOptionsText[0].text != "")
        {
            //if there are more questions and the id of my answer isnt bigger than the total amount of questions we want to set currentQuestion.
            //Otherwise we would be leading to questions that don't exist.
            if (currentQuestion.answers[0].answerId < questions.Count)
            {
                currentQuestion = questions.First(question => question.id == currentQuestion.answers[0].answerId);
            }
            else
            {
                Debug.Log("Dit antwoord heeft geen volgende vraag");
            }
        }
        if (button.name == "Option2" && questions.Count > 1 && userOptionsText[1].text != "")
        {
            if (currentQuestion.answers[1].answerId <= questions.Count - 1)
            {
                currentQuestion = questions.First(question => question.id == currentQuestion.answers[1].answerId);
            }
            else
            {
                Debug.Log("Dit antwoord heeft geen volgende vraag");
            }
        }
        if (button.name == "Option3" && questions.Count > 1 && userOptionsText[2].text != "")
        {
            if (currentQuestion.answers[2].answerId <= questions.Count - 1)
            {
                currentQuestion = questions.First(question => question.id == currentQuestion.answers[2].answerId);
            }
            else
            {
                Debug.Log("Dit antwoord heeft geen volgende vraag");
            }
        }
        if (button.name == "Option4" && questions.Count > 1 && userOptionsText[3].text != "")
        {
            if (currentQuestion.answers[3].answerId <= questions.Count - 1)
            {
                currentQuestion = questions.First(question => question.id == currentQuestion.answers[3].answerId);
            }
            else
            {
                Debug.Log("Dit antwoord heeft geen volgende vraag");
            }
        }

        SetText();
    }

    void SetText()
    {
        //first empty all the texts
        clientText.text = null;
        for (int i = 0; i < userOptionsText.Length; i++)
        {
            userOptionsText[i].text = null;
        }

        //set all the texts
        clientText.text = currentQuestion.questionText;
        for (int i = 0; i < currentQuestion.answers.Count; i++)
        {
            userOptionsText[i].text = currentQuestion.answers[i].answerText;
        }
    }
}
