using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCollider : MonoBehaviour
{
    [HideInInspector]
    public bool isGrabbed = false;

    public Rigidbody colliderRb;
    public ConfigurableJoint joint;

    protected Vector3 initialClickPosition;
    protected Vector3 targetPosition;

    // Start is called before the first frame update
    protected virtual void Awake()
    {
        this.colliderRb = GetComponent<Rigidbody>();
        this.joint = GetComponent<ConfigurableJoint>();
    }

    public void SetInitialClickPosition(Vector3 initialPos)
    {
        this.initialClickPosition = initialPos;
    }

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
    protected void FixedUpdate()
    {
        if (this.isGrabbed == true)
        {
            this.UpdateJoint();
        }
    }

    protected virtual void UpdateJoint()
    {

    }
    
}
