using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public class DialogueManager : MonoBehaviour
{

    public GameObject clientTextBox;
    public GameObject[] userOptionsButtons;
    Timer timer;
    Text clientText;
    Text[] userOptionsText = new Text[4];
    List<Question> questions;
    Stack<Question> previousQuestions = new Stack<Question>();
    
    public Question currentQuestion;

    // Use this for initialization
    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        questions = InitializeQuestions();
        currentQuestion = questions[0];

        //get the text components from all the objects
        clientText = clientTextBox.GetComponent<Text>();
        for (int i = 0; i < userOptionsButtons.Length; i++)
        {
            userOptionsText[i] = userOptionsButtons[i].GetComponentInChildren<Text>();
        }
        SetText();
        timer.setTimer();
    }

    // Update is called once per frame
    void Update()
    {
        //reload scene for debugging purposes
        if (Input.GetKey("space"))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown("backspace"))
        {
            try
            {
                currentQuestion = previousQuestions.Pop();
                SetText();
                timer.setTimer();
            }
            catch(Exception)
            {
                Debug.Log("Er is geen vorige vraag");
            }
        }

    }

    private static List<Question> InitializeQuestions()
    {
        //return questions from somewhere else
        return QuestionInitializer.InitializeQuestions();
    }

    public void OnClick(Button button)
    {
        int buttonNumber = int.Parse(button.name.Substring(button.name.Length - 1)) - 1;

        //added some errorhandling  if there is no text on the button there is no answer so i dont want to set my currentquestion
        try
        {
            previousQuestions.Push(currentQuestion);
            currentQuestion = questions.First(question => question.id == currentQuestion.answers[buttonNumber].answerId);
        }
        catch (Exception)
        {
            Debug.Log("Dit antwoord heeft geen volgende vraag.");
        }

        SetText();
        timer.setTimer();
    }

    void SetText()
    {
        //set all the texts
        clientText.text = currentQuestion.id.ToString() + "| " + currentQuestion.questionText;
        for (int i = 0; i < currentQuestion.answers.Count; i++)
        {
            userOptionsText[i].text = currentQuestion.answers[i].answerId.ToString() + "| " + currentQuestion.answers[i].answerText;
        }

        for (int i = currentQuestion.answers.Count; i < userOptionsText.Length; i++)
        {
            userOptionsText[i].text = "";
        }
    }
}
