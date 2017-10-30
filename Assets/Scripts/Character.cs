using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Character : MonoBehaviour
{
    private string emotion = "default";

    public void SetEmotion(string emotion)
    {
        this.emotion = emotion;
    }
}