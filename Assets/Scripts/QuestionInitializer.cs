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
        string[] linar = new string[10];
        List<Question> questions = new List<Question>();

        using (StreamReader reader = new StreamReader("Assets/Scripts/flitsScenarioAgressief.txt", Encoding.Default))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                linar = line.Split('|');
                List<Answer> answers = new List<Answer>();
                for (int i = 2; i < linar.Length - 1; i += 2)
                {
                    answers.Add(new Answer(int.Parse(linar[i]), linar[i + 1]));
                }
                questions.Add(new Question(int.Parse(linar[0]), linar[1], answers));
            }
        }

        return questions;
    }
}