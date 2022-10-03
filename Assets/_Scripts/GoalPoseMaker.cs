using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPoseMaker : MonoBehaviour
{
    public PoseData poseData;

    private List<Transform> poseZones;

    [SerializeField]
    private List<Rigidbody> ragdollRbs;

    public bool makePose = false;

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

    private void MovePoseZones()
    {
        this.poseZones[0].position = this.ragdollRbs[0].position;
        this.poseZones[1].position = this.ragdollRbs[1].position;
        this.poseZones[2].position = this.ragdollRbs[2].position;
        this.poseZones[3].position = this.ragdollRbs[3].position;
        this.poseZones[4].position = this.ragdollRbs[4].position;
        this.poseZones[5].position = this.ragdollRbs[5].position;
    }

    private void SavePoseZones()
    {
        this.poseData.headZonePosition = this.poseZones[0].position;
        this.poseData.torsoZonePosition = this.poseZones[1].position;
        this.poseData.rightArmZonePosition = this.poseZones[2].position;
        this.poseData.rightHandZonePosition = this.poseZones[3].position;
        this.poseData.leftArmZonePosition = this.poseZones[4].position;
        this.poseData.leftHandZonePosition = this.poseZones[5].position;
    }

    private void Update()
    {
        if (this.makePose == true)
        {
            this.MovePoseZones();
            this.SavePoseZones();

            this.makePose = false;
        }
    }
}
