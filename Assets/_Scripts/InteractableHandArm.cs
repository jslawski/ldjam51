using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHandArm : InteractableCollider
{
    protected override void UpdateJoint()
    {
        this.colliderRb.MovePosition(this.targetPosition);
    }
}
