using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGrounded = true;
    private Animator animator;
    private SceneManager sceneManagerScript;
    private bool isLanding = false;
    private TMP_Text endInfo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // sceneManagerScript
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        sceneManagerScript = GameObject.Find("SceneManager").GetComponent<SceneManager>();
        endInfo = sceneManagerScript.endInfo;
    }

    // Update is called once per frame
    void Update()
    {
        isLanding = animator.GetCurrentAnimatorStateInfo(0).IsName("HumanM@Jump01 - Land");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !sceneManagerScript.level1Completed)
        {
            animator.SetBool("isJump",true);
            rb.AddForce(Vector3.up*150f,ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJump",false);
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            sceneManagerScript.level1Completed = true;
            Destroy(gameObject);
            Destroy(collision.gameObject);
            endInfo.text = "Level "+1+" failed!";
        }
    }

}
