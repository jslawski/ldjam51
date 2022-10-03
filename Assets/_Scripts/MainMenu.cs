using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private AudioSource buttonSound;

    public void OnPlayClicked()
    {
        this.buttonSound.Play();
        SceneLoader.instance.LoadScene("MainGameScene");
    }

    public void OnExitClicked()
    {
        this.buttonSound.Play();
        Application.Quit();
    }
}
