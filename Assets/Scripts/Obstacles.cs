using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private float speed;
    private SceneManagerScript sceneManagerScript;
    private Animator animator;
    private bool isLanding = false;
    private Vector3 initialWallPos;
    private float width;
    private bool isRunningJumping=false;
    // private int level;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // level = GameManager.Instance.level;
        sceneManagerScript = GameObject.Find("SceneManager").GetComponent<SceneManagerScript>();
        speed = sceneManagerScript.playerSpeed[sceneManagerScript.level];
        animator = GameObject.Find("Player").GetComponent<Animator>();
        width = sceneManagerScript.width;
        initialWallPos = sceneManagerScript.initialWallPos;
    }

    // Update is called once per frame
    void Update()
    {
        isLanding = animator.GetCurrentAnimatorStateInfo(0).IsName("HumanM@Jump01 - Land");
        isRunningJumping = animator.GetCurrentAnimatorStateInfo(0).IsName("HumanM@Run01_Forward") || animator.GetCurrentAnimatorStateInfo(0).IsName("HumanM@Jump01 - Begin");
        if (!sceneManagerScript.level1Completed && !isLanding && isRunningJumping && !sceneManagerScript.isPause)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        }
        if(transform.position.x < initialWallPos.x-width/2)
        {
            Destroy(gameObject);
        }
    }
}
