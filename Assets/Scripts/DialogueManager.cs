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
        if (button.name == "Option1")
        {
            currentQuestion = questions.First(question => question.id == currentQuestion.answers[0].answerId);
        }
        if (button.name == "Option2")
        {
            currentQuestion = questions.First(question => question.id == currentQuestion.answers[1].answerId);
        }
        if (button.name == "Option3")
        {
            currentQuestion = questions.First(question => question.id == currentQuestion.answers[2].answerId);
        }
        if (button.name == "Option4")
        {
            currentQuestion = questions.First(question => question.id == currentQuestion.answers[3].answerId);
        }

        SetText();
    }

    void SetText()
    {
        //set all the texts
        clientText.text = currentQuestion.questionText;
        for (int i = 0; i < currentQuestion.answers.Count; i++)
        {
            userOptionsText[i].text = currentQuestion.answers[i].answerText;
        }
    }
}
