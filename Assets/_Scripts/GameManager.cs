using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        Debug.LogError("Current Pose: " + currentPose.name);
        
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

            this.currentRound++;
            this.CloseAperture();
            StartCoroutine(this.LoadCharacter());
        }
        else
        {
            //End Game
            this.CloseAperture();
            this.DisplayYearbook();
            Debug.LogError("GAME OVER");
        }
    }

    private void DisplayYearbook()
    {
        this.yearbook.SetActive(true);
    }

    private IEnumerator LoadCharacter()
    {
        yield return new WaitForSeconds(0.5f);

        this.characterName = LiteralStrings.GetRandomName();
        this.quote = LiteralStrings.GetRandomQuote();

        Destroy(this.currentCharacter);

        yield return null;

        Vector3 spawnPosition = new Vector3(-0.3f, 0.1f, -0.2f);
            
        this.currentCharacter = Instantiate(this.characterPrefab, spawnPosition, Quaternion.Euler(0.0f, 160.0f, 0.0f));
        this.SetupNextPose();
    }

    public void StartLevelTimer()
    {
        this.photoTaker.StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            this.StartGame();
        }
    }
}
