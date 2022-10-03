using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeCharacter : MonoBehaviour
{
    [SerializeField]
    private RagdollManipulator manipulator;

    public void Awake()
    {
        GameObject.Find("GoalZones").GetComponent<GoalZoneParent>().SetupGoalZoneParent(this.gameObject.transform.position);
        GameObject.Find("PuppetManipulator").GetComponent<RagdollManipulator>().SetupRagdollManipulator();

        StartCoroutine(this.RandomlyApplyGravity());
    }

    private IEnumerator RandomlyApplyGravity()
    {
        float randomDuration = UnityEngine.Random.Range(0.5f, 1.0f);

        for (int i = 0; i < this.manipulator.allInteractableColliders.Length; i++)
        {            
            this.manipulator.allInteractableColliders[i].colliderRb.isKinematic = false;            
        }

        for (int i = 2; i < this.manipulator.allInteractableColliders.Length; i++)
        {
            float randomRoll = UnityEngine.Random.Range(0.0f, 100.0f);
            this.manipulator.allInteractableColliders[i].colliderRb.useGravity = (randomRoll > 30.0f);
        }

        yield return new WaitForSeconds(randomDuration);

        for (int i = 0; i < this.manipulator.allInteractableColliders.Length; i++)
        {
            this.manipulator.allInteractableColliders[i].colliderRb.isKinematic = true;
            this.manipulator.allInteractableColliders[i].colliderRb.useGravity = false;
        }


        GameManager.instance.OpenAperture();
        GameManager.instance.StartLevelTimer();
    }
}
