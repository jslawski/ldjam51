using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandArmManipulator : MonoBehaviour
{
    private Rigidbody objectRb;

    [SerializeField]
    private LayerMask detectableLayer;

    //private Vector3 initialClickPosition;
    //private Vector3 currentDragPosition;

    [SerializeField]
    private float dragCheckDelayInSeconds = 0.2f;

    [SerializeField]
    private float maxTorqueForce = 50f;

    // Start is called before the first frame update
    void Start()
    {
        this.objectRb = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseRay, out hit, Mathf.Infinity, detectableLayer))
            {
                Vector3 screenPosition = Input.mousePosition;
                screenPosition.z = Camera.main.nearClipPlane;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

                StartCoroutine(this.DragObject(worldPosition));
            }
        }

        /*
        if (Input.GetMouseButtonUp(0))
        {
            
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
        */
    }

    private IEnumerator DragObject(Vector3 initialPoint)
    {
        Vector3 lastPosition = initialPoint;

        while (Input.GetMouseButton(0) == true)
        {
            yield return new WaitForSeconds(this.dragCheckDelayInSeconds);

            Vector3 currentScreenPosition = Input.mousePosition;
            currentScreenPosition.z = Camera.main.nearClipPlane;

            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPosition);

            float xDiff = lastPosition.x - currentPosition.x;
            float yDiff = currentPosition.y - lastPosition.y;

            Vector3 horizontalTorque = Vector3.up * this.maxTorqueForce * xDiff;// * Time.fixedDeltaTime;
            //Vector3 verticalTorque = this.gameObject.transform.up * this.maxTorqueForce * yDiff * Time.fixedDeltaTime;

            this.objectRb.AddTorque(horizontalTorque, ForceMode.VelocityChange);

            lastPosition = currentPosition;
        }
    }
}
