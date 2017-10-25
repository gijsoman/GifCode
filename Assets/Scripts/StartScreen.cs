using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {
    public void OnClick(Button button)
    {
        if (button.name == "PlayButton")
        {
            SceneManager.LoadScene(1);
        }
    }
}
