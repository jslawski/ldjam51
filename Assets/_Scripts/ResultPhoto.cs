using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPhoto : MonoBehaviour
{
    public void StartNextLevel()
    {
        GameManager.instance.tutorial = false;
        GameManager.instance.LoadNextLevel();
    }
}
