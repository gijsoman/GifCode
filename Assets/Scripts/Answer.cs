using UnityEngine;
using System.Collections;

public class Answer
{
    public string answerText;
    public int answerId;

    public Answer(int answerId, string answerText)
    {
        this.answerText = answerText;
        this.answerId = answerId;
    }
}
