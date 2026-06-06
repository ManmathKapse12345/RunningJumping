using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGrounded = true;
    private Animator animator;
    private SceneManager sceneManagerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // sceneManagerScript
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        sceneManagerScript = GameObject.Find("SceneManager").GetComponent<SceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !sceneManagerScript.level1Completed)
        {
            animator.SetBool("isJump",true);
            rb.AddForce(Vector3.up*150f,ForceMode.Impulse);
            isGrounded = false;
        }
        // if (sceneManagerScript.level1Completed)
        // {
        //     animator.SetBool("isJump",false);
        // }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJump",false);
        }
    }

}
