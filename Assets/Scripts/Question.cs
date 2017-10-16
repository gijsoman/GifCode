using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Question
{
    //Every question has the question text and a variable number of possible answers
    public int path;
    public string questionText;
    public List<Answer> answers;

    public Question(int path, string questionText, List<Answer> answers)
    {
        this.path = path;
        this.questionText = questionText;
        this.answers = answers;
    }
}
