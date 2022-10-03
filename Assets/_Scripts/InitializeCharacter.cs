using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeCharacter : MonoBehaviour
{
    [SerializeField]
    private RagdollManipulator manipulator;

    [SerializeField]
    private Material bodyMaterial;

    [SerializeField]
    private GameObject headTop;

    [SerializeField]
    private MeshFilter eyesFilter;

    [SerializeField]
    private MeshFilter noseFilter;

    public void Awake()
    {
        GameObject.Find("GoalZones").GetComponent<GoalZoneParent>().SetupGoalZoneParent(this.gameObject.transform.position);
        GameObject.Find("PuppetManipulator").GetComponent<RagdollManipulator>().SetupRagdollManipulator();

        this.CustomizeCharacter();

        StartCoroutine(this.RandomlyApplyGravity());
    }

    private void CustomizeCharacter()
    {
        Texture2D[] bodyTextures = Resources.LoadAll<Texture2D>("BodyTextures");
        this.bodyMaterial.mainTexture = bodyTextures[Random.Range(0, bodyTextures.Length)];

        Mesh[] eyesMeshes = Resources.LoadAll<Mesh>("Meshes/Eyes");
        this.eyesFilter.mesh = eyesMeshes[Random.Range(0, eyesMeshes.Length)];

        Mesh[] noseMeshes = Resources.LoadAll<Mesh>("Meshes/Noses");
        this.noseFilter.mesh = noseMeshes[Random.Range(0, noseMeshes.Length)];

        List<Transform> childHairs = new List<Transform>();

        for (int i = 0; i < this.headTop.transform.childCount; i++)
        {
            childHairs.Add(this.headTop.transform.GetChild(i));
        }

        childHairs[UnityEngine.Random.Range(0, childHairs.Count)].gameObject.SetActive(true);


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
