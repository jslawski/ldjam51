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
    private MeshRenderer eyesRenderer;

    [SerializeField]
    private MeshFilter noseFilter;

    public void Awake()
    {
        GameObject.Find("GoalZones").GetComponent<GoalZoneParent>().SetupGoalZoneParent(this.gameObject.transform.position);
        GameObject.Find("PuppetManipulator").GetComponent<RagdollManipulator>().SetupRagdollManipulator();
        GameObject.Find("Background").GetComponent<CustomBackground>().SetRandomBackground();

        this.CustomizeCharacter();

        StartCoroutine(this.RandomlyApplyGravity());
    }

    private void CustomizeCharacter()
    {
        Texture2D[] bodyTextures = Resources.LoadAll<Texture2D>("BodyTextures");
        this.bodyMaterial.mainTexture = bodyTextures[Random.Range(0, bodyTextures.Length)];

        Texture2D[] eyesTextures = Resources.LoadAll<Texture2D>("CharTextures/eyes");
        this.eyesRenderer.material.mainTexture = eyesTextures[Random.Range(0, eyesTextures.Length)];

        Mesh[] eyesMeshes = Resources.LoadAll<Mesh>("Meshes/Eyes");
        this.eyesFilter.mesh = eyesMeshes[Random.Range(0, eyesMeshes.Length)];

        Mesh[] noseMeshes = Resources.LoadAll<Mesh>("Meshes/Noses");
        this.noseFilter.mesh = noseMeshes[Random.Range(0, noseMeshes.Length)];
        
        List<Transform> childHairs = new List<Transform>();
        for (int i = 0; i < this.headTop.transform.childCount; i++)
        {
            childHairs.Add(this.headTop.transform.GetChild(i));
        }

        int randomIndex = Random.Range(0, childHairs.Count);
        childHairs[randomIndex].gameObject.SetActive(true);

        Texture2D[] allHairTextures = Resources.LoadAll<Texture2D>("CharTextures/" + childHairs[randomIndex].name);
        childHairs[randomIndex].GetComponent<MeshRenderer>().material.mainTexture = 
            allHairTextures[Random.Range(0, allHairTextures.Length)];
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

        if (GameManager.instance.debug == false)
        {
            GameManager.instance.OpenAperture();
            GameManager.instance.StartLevelTimer();
        }
    }
}
