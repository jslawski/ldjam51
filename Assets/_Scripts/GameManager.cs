using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int levelScore = 0;

    [SerializeField]
    private Transform[] poseZones;

    private PoseData[] allPoses;

    [SerializeField]
    private PhotoTaker photoTaker;

    public bool debug = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        this.allPoses = Resources.LoadAll<PoseData>("Poses");

        if (debug == false)
        {
            this.StartupGameSequence();
        }
    }

    private void StartupGameSequence()
    {
        this.SetupNextPose();
        this.photoTaker.StartTimer();
    }

    private void WrapUpGameSequence() { }

    private void SetupNextPose()
    {
        levelScore = 0;

        PoseData currentPose = this.allPoses[UnityEngine.Random.Range(0, this.allPoses.Length)];

        Debug.LogError("Current Pose: " + currentPose.name);

        this.poseZones[0].position = currentPose.headZonePosition;
        this.poseZones[1].position = currentPose.torsoZonePosition;
        this.poseZones[2].position = currentPose.rightArmZonePosition;
        this.poseZones[3].position = currentPose.rightHandZonePosition;
        this.poseZones[4].position = currentPose.leftArmZonePosition;
        this.poseZones[5].position = currentPose.leftHandZonePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}
