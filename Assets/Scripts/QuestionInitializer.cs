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
        string line;
        string[] linar = new string[10];
        List<Question> questions = new List<Question>();


        int lineCount = 0;

        using (StreamReader reader = new StreamReader("Assets/Scripts/test.txt", Encoding.Default))
        {
            //read as long as there are lines
            while (reader.ReadLine() != null)
            {
                lineCount++;
            }

            //reset the streamreader
            reader.DiscardBufferedData();
            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            reader.BaseStream.Position = 0;

            for (int r = 0; r < lineCount; r++)
            {
                line = reader.ReadLine();
                linar = line.Split('|');
                List<Answer> answers = new List<Answer>();
                for (int i = 2; i < linar.Length - 1; i += 2)
                {
                    answers.Add(new Answer(int.Parse(linar[i]), linar[i + 1]));
                }
                questions.Add(new Question(int.Parse(linar[0]), linar[1], answers));
            }
            
        }

        //questions.Add(new Question(0, "hi", new List<Answer>() { new Answer(1 ,"Hi1"), new Answer(2, "hello"), new Answer(3, "doe is aardig") }));
        //questions.Add(new Question(1, "hi", new List<Answer>() { new Answer(1, "1234234234234234234"), new Answer(2, "1234234234234234234"), new Answer(3, "doe is aardig") }));
        return questions;
    }
}

//    string jsonString = reader.ReadToEnd(); /*of*/ string jsonLine = reader.ReadLine();
//    Do Jsonstuff
//    questions.Add(new Question(0, "hi", new List<Answer>() { new Answer("hi2", 1) }));