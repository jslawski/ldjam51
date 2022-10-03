using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZoneParent : MonoBehaviour
{
    [HideInInspector]
    public List<Transform> allGoalZonesTransforms;

    public void SetupGoalZoneParent(Vector3 playerPosition)
    {
        //this.gameObject.transform.position = playerPosition;

        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.allGoalZonesTransforms.Add(this.transform.GetChild(i));
            this.transform.GetChild(i).position = this.transform.position;
        }
    }    
}
