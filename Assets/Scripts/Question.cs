using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Question
{
    //Every question has the question text and a variable number of possible answers
    public int id;
    public string questionText;
    public List<Answer> answers;

    public Question(int id, string questionText, List<Answer> answers)
    {
        this.id = id;
        this.questionText = questionText;
        this.answers = answers;
    }
}
