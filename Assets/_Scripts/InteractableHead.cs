using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHead : InteractableCollider
{
    private CharacterJoint charJoint;

    [SerializeField]
    private float maxDelta = 2f;

    protected override void Awake()
    {
        base.Awake();

        this.charJoint = this.joint.connectedBody.gameObject.GetComponent<CharacterJoint>();
    }

    protected override void UpdateJoint()
    {
        Vector3 finalRotationVector = Vector3.zero;

        Vector3 oldRotation = this.colliderRb.rotation.eulerAngles;

        //Rotates y
        float xDelta = this.targetPosition.x - this.initialClickPosition.x;
        //Rotates x
        float yDelta = this.targetPosition.y - this.initialClickPosition.y;

        float yAngle = Mathf.Lerp(0.0f, (this.charJoint.swing2Limit.limit), (Mathf.Abs(xDelta) / this.maxDelta));
        float xAngle = 0f;

        if (xDelta > 0)
        {
            yAngle *= -1;
        }
        if (yDelta > 0)
        {
            xAngle = -Mathf.Lerp(0.0f, (this.charJoint.highTwistLimit.limit), (Mathf.Abs(yDelta) / this.maxDelta));
        }
        else
        {
            xAngle = -Mathf.Lerp(0.0f, (this.charJoint.lowTwistLimit.limit), (Mathf.Abs(yDelta) / this.maxDelta));
        }

        finalRotationVector = new Vector3(xAngle, yAngle - 180.0f, oldRotation.z);
        
        this.colliderRb.MoveRotation(Quaternion.Euler(finalRotationVector));
    }
}
