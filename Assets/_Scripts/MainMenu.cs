using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnPlayClicked()
    {
        SceneLoader.instance.LoadScene("MainGameScene");
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }
}
