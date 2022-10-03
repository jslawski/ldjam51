using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pose", menuName = "Pose")]
public class PoseData : ScriptableObject
{
    public Vector3 headZonePosition;
    public Vector3 torsoZonePosition;
    public Vector3 rightArmZonePosition;
    public Vector3 rightHandZonePosition;
    public Vector3 leftArmZonePosition;
    public Vector3 leftHandZonePosition;
}
