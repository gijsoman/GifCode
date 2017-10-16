using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public static class QuestionInitializer
{
    public static List<Question> InitializeQuestions()
    {
        //Hier mag je questions initializen en vanuit JSon halen, voorbeeld van hoe het misschien kan.

        List<Question> questions = new List<Question>();

        //using (StreamReader reader = new StreamReader("pathToJson.txt"))
        //{
        //    string jsonString = reader.ReadToEnd(); /*of*/ string jsonLine = reader.ReadLine();
        //    Do Jsonstuff
        //    questions.Add(new Question(0, "hi", new List<Answer>() { new Answer("hi2", 1) }));
        //}

        questions.Add(new Question(0, "hi", new List<Answer>() { new Answer("hi2", 1), new Answer("hello", 2), new Answer("doe is aardig", 3) }));
        questions.Add(new Question(1, "hi", new List<Answer>() { new Answer("1234234234234234234", 1), new Answer("hello", 2), new Answer("doe is aardig", 3) }));
        return questions;
    }
}
