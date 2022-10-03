using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZone : MonoBehaviour
{
    [SerializeField]
    private string linkedObjectName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == this.linkedObjectName)
        {
            Debug.LogError(this.linkedObjectName + " Entered!");
            GameManager.instance.levelScore++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == this.linkedObjectName)
        {
            Debug.LogError(this.linkedObjectName + " Exited!");
            GameManager.instance.levelScore--;
        }
    }
}
