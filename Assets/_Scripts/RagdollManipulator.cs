using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollManipulator : MonoBehaviour
{
    [SerializeField]
    private Transform grabbedTransform;

    [SerializeField]
    private LayerMask detectableLayer;

    private Vector2 targetDestination;

    private float rayDistance = 0.0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);            
            if (Physics.Raycast(mouseRay, out hit, Mathf.Infinity, detectableLayer))
            {
                this.grabbedTransform = hit.collider.gameObject.transform;
                this.rayDistance = hit.distance;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            this.grabbedTransform = null;
            this.rayDistance = 0.0f;
        }


        if (this.rayDistance > 0.0f)
        {
            Vector3 adjustedMosPos =
                Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.rayDistance));

            this.targetDestination = new Vector2(adjustedMosPos.x, adjustedMosPos.y);
        }
    }

    private void FixedUpdate()
    {
        
        if (this.grabbedTransform != null)
        {
            this.grabbedTransform.position = new Vector3(this.targetDestination.x, 
                                                this.targetDestination.y, 
                                                this.grabbedTransform.position.z);
        }
        
    }
}
