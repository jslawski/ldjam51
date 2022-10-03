using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPose : MonoBehaviour
{
    public PoseData poseData;

    private List<Transform> poseZones;

    private void Awake()
    {
        this.poseZones = new List<Transform>();
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.poseZones.Add(this.gameObject.transform.GetChild(i));
        }

        this.poseZones[0].position = this.poseData.headZonePosition;
        this.poseZones[1].position = this.poseData.torsoZonePosition;
        this.poseZones[2].position = this.poseData.rightArmZonePosition;
        this.poseZones[3].position = this.poseData.rightHandZonePosition;
        this.poseZones[4].position = this.poseData.leftArmZonePosition;
        this.poseZones[5].position = this.poseData.leftHandZonePosition;
    }

    private void Update()
    {
        this.poseData.headZonePosition = this.poseZones[0].position;
        this.poseData.torsoZonePosition = this.poseZones[1].position;
        this.poseData.rightArmZonePosition = this.poseZones[2].position;
        this.poseData.rightHandZonePosition = this.poseZones[3].position;
        this.poseData.leftArmZonePosition = this.poseZones[4].position;
        this.poseData.leftHandZonePosition = this.poseZones[5].position;
    }
}
