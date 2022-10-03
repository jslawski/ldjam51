using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTorso : InteractableCollider
{
    private CharacterJoint charJoint;

    [SerializeField]
    private float maxDelta = 2f;

    public override void SetupInteractableCollider()
    {
        base.SetupInteractableCollider();

        this.charJoint = this.joint.connectedBody.gameObject.GetComponent<CharacterJoint>();
    }

    protected override void UpdateJoint()
    {
        Vector3 finalRotationVector = Vector3.zero;

        //Rotates z
        float xDelta = this.targetPosition.x - this.initialClickPosition.x;
        //Rotates x
        float yDelta = this.targetPosition.y - this.initialClickPosition.y;

        float zAngle = Mathf.Lerp(0.0f, (this.charJoint.swing1Limit.limit), (Mathf.Abs(xDelta) / this.maxDelta));
        float xAngle = 0f;

        if (xDelta < 0)
        {
            zAngle *= -1;
        }
        if (yDelta > 0)
        {
            xAngle = -Mathf.Lerp(0.0f, (this.charJoint.highTwistLimit.limit), (Mathf.Abs(yDelta) / this.maxDelta));
        }
        else
        {
            xAngle = -Mathf.Lerp(0.0f, (this.charJoint.lowTwistLimit.limit), (Mathf.Abs(yDelta) / this.maxDelta));
        }

        finalRotationVector = new Vector3(xAngle, 180.0f, zAngle);
        
        this.colliderRb.MoveRotation(Quaternion.Euler(finalRotationVector));
    }
}
