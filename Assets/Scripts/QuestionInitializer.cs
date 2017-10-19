using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public static class QuestionInitializer
{
    public static List<Question> InitializeQuestions()
    {
        //Hier mag je questions initializen en vanuit JSon halen, voorbeeld van hoe het misschien kan.
        string[] linar;
        List<Question> questions = new List<Question>();
        TextAsset file = Resources.Load<TextAsset>("flitsScenarioAgressief");
        string[] lines = file.text.Split('\n');

        for (int i = 0; i < lines.Length; i++)
        {
            linar = lines[i].Split('|');
            List<Answer> answers = new List<Answer>();
            for (int j = 2; j < linar.Length - 1; j += 2)
            {
                answers.Add(new Answer(int.Parse(linar[j]), linar[j + 1]));
            }
            questions.Add(new Question(int.Parse(linar[0]), linar[1], answers));
        }

        return questions;
    }
}