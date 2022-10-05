using UnityEngine;

public class RagdollManipulator : MonoBehaviour
{
    public InteractableCollider[] allInteractableColliders;

    private InteractableCollider grabbedCollider;

    [SerializeField]
    private LayerMask detectableLayer;

    private Vector2 targetDestination;

    private float rayDistance = 0.0f;

    public void SetupRagdollManipulator()
    {
        for (int i = 0; i < this.allInteractableColliders.Length; i++)
        {
            this.allInteractableColliders[i].SetupInteractableCollider();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);            
            if (Physics.Raycast(mouseRay, out hit, 10.0f, detectableLayer))
            {
                this.grabbedCollider = hit.collider.gameObject.GetComponent<InteractableCollider>();

                this.rayDistance = hit.distance;

                this.grabbedCollider.isGrabbed = true;
                this.grabbedCollider.SetInitialClickPosition(hit.point);                                
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (this.grabbedCollider != null)
            {
                this.grabbedCollider.isGrabbed = false;
                this.grabbedCollider = null;
                this.ResetAllInteractableColliders();
            }

            this.rayDistance = 0.0f;
        }

        if (this.rayDistance > 0.0f)
        {
            Vector3 adjustedMosPos =
                Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.16f));
            adjustedMosPos = new Vector3(adjustedMosPos.x, adjustedMosPos.y, this.grabbedCollider.colliderRb.position.z);

            if (this.grabbedCollider != null)
            {
                this.grabbedCollider.SetTargetPosition(adjustedMosPos);
            }            
        }
    }

    private void ResetAllInteractableColliders()
    {
        for (int i = 0; i < this.allInteractableColliders.Length; i++)
        {
            this.allInteractableColliders[i].gameObject.transform.position = 
                this.allInteractableColliders[i].joint.connectedBody.position;
        }
    }
}
