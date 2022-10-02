using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHandArm : InteractableCollider
{
    private float moveSpeed = 3f;

    protected override void UpdateJoint()
    {
        Vector3 lerpedPosition = Vector3.Lerp(this.colliderRb.position, this.targetPosition, this.moveSpeed * Time.fixedDeltaTime);

        this.colliderRb.MovePosition(lerpedPosition);
    }
}
