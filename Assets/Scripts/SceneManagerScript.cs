using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public GameObject wallPrefab;
    private Renderer rend;
    public float width;
    public Vector3 initialWallPos;
    private const int numberOfObstacles = 5;
    public GameObject[] barriers = new GameObject[numberOfObstacles];
    private Vector3 spawnPosition = new Vector3(40f, 0.7767304f, 6f);
    private int index;
    private float distanceTravelled;
    private float distance = 500;
    public bool level1Completed=false;
    private Animator animator;
    private bool isLanding = false;
    public TMP_Text endInfo;
    private bool isRunningJumping=false;
    public bool isPause=false;
    private const int numberOfPauseMenuObject = 4;
    public GameObject[] pauseMenuObject = new GameObject[numberOfPauseMenuObject];
    private int[] repeatingRate=new int[]{10,8,7,6,5};
    public int[] playerSpeed=new int[]{5,6,7,8,9};
    private GameManager gameManagerScript;
    public int level;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        level=GameManager.Instance.level;
        Debug.Log("Level :- " + level);
        Debug.Log("Players Speed :- " + playerSpeed[level]);
        for(int i = 0; i < numberOfPauseMenuObject; i++)
        {
            pauseMenuObject[i].SetActive(false);
        }
        endInfo.text = "";
        animator = GameObject.Find("Player").GetComponent<Animator>();
        InvokeRepeating("GenerateObstacles", 3f, repeatingRate[level]);
        rend = wallPrefab.GetComponent<Renderer>();
        Vector3 wallSize = rend.bounds.size;
        width = wallSize.x;
        // Debug.Log("X :- " + wallSize.x);
        // Debug.Log("Y :- " + wallSize.y);
        // Debug.Log("Z :- " + wallSize.z);
        initialWallPos = wallPrefab.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        isRunningJumping = animator.GetCurrentAnimatorStateInfo(0).IsName("HumanM@Run01_Forward") || animator.GetCurrentAnimatorStateInfo(0).IsName("HumanM@Jump01 - Begin");
        isLanding = animator.GetCurrentAnimatorStateInfo(0).IsName("HumanM@Jump01 - Land");
        if (!level1Completed && !isLanding && isRunningJumping && !isPause)
        {
            wallPrefab.transform.Translate(Vector3.left * Time.deltaTime * playerSpeed[level]);
            if (Vector3.Distance(wallPrefab.transform.position, initialWallPos) >= width / 2)
            {
                distanceTravelled = distanceTravelled+width/2;
                wallPrefab.transform.position = initialWallPos;
                if(distanceTravelled == distance)
                {
                    animator.SetBool("isOver",true);
                    level1Completed = true;
                    endInfo.text = "Level " + 1 + " Completed!";
                }
            }
        }
    }

    public void MakePauseMenuAppear()
    {
        animator.SetBool("isOver",true);
        isPause = true;
        for(int i = 0; i < numberOfPauseMenuObject; i++)
        {
            pauseMenuObject[i].SetActive(true);
        }
    }

    public void MakePauseMenuDisappear()
    {
        animator.SetBool("isOver",false);
        isPause = false;
        for(int i = 0; i<numberOfPauseMenuObject; i++)
        {
            pauseMenuObject[i].SetActive(false);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToLevelScene()
    {
        SceneManager.LoadScene("LevelScene");
    }

    void GenerateObstacles()
    {
        index = Random.Range(0, numberOfObstacles);
        Instantiate(barriers[index], spawnPosition, barriers[index].transform.rotation);
    }
}
