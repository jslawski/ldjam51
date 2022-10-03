using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject[] resultsObjects;
    
    public void ShowResultsAnimation()
    {
        StartCoroutine(this.ShowResult());
    }

    private IEnumerator ShowResult()
    {
        int resultIndex = 0;

        if (GameManager.instance.levelScore >= GameManager.instance.perfectScore)
        {
            resultIndex = 0;
        }
        else if (GameManager.instance.levelScore >= GameManager.instance.goodScore)
        {
            resultIndex = 1;
        }
        else
        {
            resultIndex = 2;
        }

        this.resultsObjects[resultIndex].SetActive(true);

        yield return new WaitForSeconds(3.0f);

        this.resultsObjects[resultIndex].SetActive(false);


    }

}
