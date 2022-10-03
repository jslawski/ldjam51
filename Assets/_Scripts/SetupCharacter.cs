using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;

public class SetupCharacter : MonoBehaviour
{
    [SerializeField]
    private RagdollManipulator ragdollManipulator;

    [SerializeField]
    private List<Rigidbody> jointRbs;

    public Preset[] jointPresets;

    [SerializeField]
    private Rigidbody[] allRbs;

    [SerializeField]
    private Rigidbody rightArmRb;
    [SerializeField]
    private Rigidbody leftArmRb;

    // Start is called before the first frame update
    void Start()
    {
        this.jointRbs = new List<Rigidbody>();

        this.allRbs = GetComponentsInChildren<Rigidbody>();

        for (int i = 0; i < this.ragdollManipulator.allInteractableColliders.Length; i++)
        {
            //this.ragdollManipulator.allInteractableColliders[i].joint.connectedBody.isKinematic = false;
            //this.jointPresets[i].ApplyTo(this.ragdollManipulator.allInteractableColliders[i].joint);
            //this.ragdollManipulator.allInteractableColliders[i].joint.autoConfigureConnectedAnchor = false;
            //this.ragdollManipulator.allInteractableColliders[i].joint.connectedAnchor = Vector3.zero;

            this.jointRbs.Add(this.ragdollManipulator.allInteractableColliders[i].joint.connectedBody);
            Destroy(this.ragdollManipulator.allInteractableColliders[i].joint);
        }

        StartCoroutine(this.ApplyGravity());
    }

    private IEnumerator ApplyGravity()
    {
        float randomDuration = UnityEngine.Random.Range(0.5f, 1.5f);

        for (int i = 0; i < this.jointRbs.Count; i++)
        {
            float randomRoll = UnityEngine.Random.Range(0.0f, 100.0f);
            this.jointRbs[i].isKinematic = false;
            this.jointRbs[i].useGravity = (randomRoll > 30.0f);
        }

        yield return new WaitForSeconds(randomDuration);

        for (int i = 0; i < this.allRbs.Length; i++)
        {
            this.allRbs[i].useGravity = false;
            this.allRbs[i].isKinematic = true;
            this.allRbs[i].velocity = Vector3.zero;
        }

        yield return null;

        this.SetupJoints();
    }

    private void SetupJoints()
    {
        for (int i = 0; i < this.jointRbs.Count; i++)
        {
            this.ragdollManipulator.allInteractableColliders[i].joint =
                    this.ragdollManipulator.allInteractableColliders[i].gameObject.AddComponent<ConfigurableJoint>();
            if (this.jointPresets[i].CanBeAppliedTo(this.ragdollManipulator.allInteractableColliders[i].joint))
            {

                this.jointPresets[i].ApplyTo(this.ragdollManipulator.allInteractableColliders[i].joint);

                this.ragdollManipulator.allInteractableColliders[i].joint.connectedBody = this.jointRbs[i];
                this.ragdollManipulator.allInteractableColliders[i].colliderRb.position = this.jointRbs[i].position;
            }            
        }

        StartCoroutine(this.ReEnableRbs());
    }

    private IEnumerator ReEnableRbs()
    {
        yield return null;

        this.rightArmRb.isKinematic = false;
        this.leftArmRb.isKinematic = false;

        for (int i = 0; i < this.jointRbs.Count; i++)
        {
            this.jointRbs[i].isKinematic = false;
        }
    }
}
