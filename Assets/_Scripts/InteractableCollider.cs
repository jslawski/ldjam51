using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCollider : MonoBehaviour
{
    public bool isGrabbed = false;
    public Rigidbody colliderRb;
    public ConfigurableJoint joint;

    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        this.colliderRb = GetComponent<Rigidbody>();
        this.joint = GetComponent<ConfigurableJoint>();
    }



    /*
    public void SetTargetPosition(Vector3 targetPos)
    {
        this.targetPosition = targetPos;
    }

    private void Update()
    {
        if (this.isGrabbed == false)
        {
            this.targetPosition = this.colliderRb.position;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.colliderRb.MovePosition(this.targetPosition);
    }
    */
    
}
