using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int levelScore = 0;

    [SerializeField]
    private GoalZoneParent goalZoneParent;

    private PoseData[] allPoses;

    [SerializeField]
    private PhotoTaker photoTaker;

    public bool debug = false;

    [SerializeField]
    private Animator apertureAnimator;

    [SerializeField]
    private GameObject characterPrefab;
    private GameObject currentCharacter;

    private int currentRound = 0;
    private int numRounds = 3;

    public string characterName;
    public string quote;

    [SerializeField]
    private GameObject yearbook;

    [SerializeField]
    private Image poseImage;
    [SerializeField]
    private Image tutorialImage;

    [SerializeField]
    private TextMeshProUGUI studentCounter;
    [SerializeField]
    private TextMeshProUGUI nameLabel;
    [SerializeField]
    private TextMeshProUGUI poseLabel;
    
    public bool tutorial = false;
    private bool tutorialSuccessTriggered = false;

    public int perfectScore = 6;
    public int goodScore = 4;    

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        this.allPoses = Resources.LoadAll<PoseData>("Poses");
        LiteralStrings.SetupLists();
        PhotoAlbum.SetupPhotoAlbum();

        this.StartGame();
    }

    private void StartGame()
    {
        if (debug == false)
        {
            this.StartupGameSequence();
        }
        else
        {
            StartCoroutine(this.LoadCharacter());
        }
    }

    private void StartupGameSequence()
    {        
        LoadNextLevel();
    }

    private void WrapUpGameSequence() { }

    private void SetupNextPose()
    {
        levelScore = 0;
        
        PoseData currentPose = this.allPoses[UnityEngine.Random.Range(0, this.allPoses.Length)];
        
        if (this.tutorial == true)
        {
            currentPose = this.allPoses[this.allPoses.Length - 1];            
        }

        this.poseImage.sprite = Resources.Load<Sprite>("PoseSprites/" + currentPose.name);

        this.goalZoneParent.allGoalZonesTransforms[0].position += currentPose.headZonePosition;
        this.goalZoneParent.allGoalZonesTransforms[1].position += currentPose.torsoZonePosition;
        this.goalZoneParent.allGoalZonesTransforms[2].position += currentPose.rightArmZonePosition;
        this.goalZoneParent.allGoalZonesTransforms[3].position += currentPose.rightHandZonePosition;
        this.goalZoneParent.allGoalZonesTransforms[4].position += currentPose.leftArmZonePosition;
        this.goalZoneParent.allGoalZonesTransforms[5].position += currentPose.leftHandZonePosition;        
    }

    public void CloseAperture()
    {
        this.apertureAnimator.SetTrigger("CloseTrigger");
    }

    public void OpenAperture()
    {
        this.apertureAnimator.SetTrigger("OpenTrigger");
    }

    public void LoadNextLevel()
    {
        if (this.currentRound < this.numRounds)
        {
            if (this.tutorial == false)
            {
                this.currentRound++;
                this.CloseAperture();
            }
            
            StartCoroutine(this.LoadCharacter());
        }
        else
        {
            //End Game
            this.CloseAperture();
            this.DisplayYearbook();
        }
    }

    private void DisplayYearbook()
    {
        this.yearbook.SetActive(true);
    }

    private void UpdateLabels()
    {
        if (this.poseImage.sprite.name.Contains("Dab"))
        {
            this.poseLabel.text = "Dab";    
        }
        else if (this.poseImage.sprite.name.Contains("Sassy"))
        {
            this.poseLabel.text = "Sassy";
        }
        else if (this.poseImage.sprite.name.Contains("VPose"))
        {
            this.poseLabel.text = "V-Pose";
        }

        this.studentCounter.text = this.currentRound.ToString() + "/" + this.numRounds.ToString() + " Students";

        this.nameLabel.text = this.characterName;
    }

    private IEnumerator LoadCharacter()
    {
        yield return new WaitForSeconds(0.5f);

        if (this.tutorial == false)
        {
            this.tutorialImage.enabled = false;
        }

        this.characterName = LiteralStrings.GetRandomName();
        this.quote = LiteralStrings.GetRandomQuote();
        
        Destroy(this.currentCharacter);

        yield return null;

        Vector3 spawnPosition = new Vector3(-0.3f, 0.1f, -0.2f);
            
        this.currentCharacter = Instantiate(this.characterPrefab, spawnPosition, Quaternion.Euler(0.0f, 160.0f, 0.0f));
        this.SetupNextPose();

        this.UpdateLabels();
    }

    public void StartLevelTimer()
    {
        this.photoTaker.StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.debug == false && this.tutorial == true && this.tutorialSuccessTriggered == false && this.levelScore >= 5)
        {
            this.tutorialSuccessTriggered = true;
            this.photoTaker.TakePhoto();
        }
    }
}
