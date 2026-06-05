using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGrounded = true;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        // Physics.gravity = new Vector3(0,-10f,0);
        // rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animator.SetBool("isJump",true);
            rb.AddForce(Vector3.up*150f,ForceMode.Impulse);
            isGrounded = false;
        }
        // if (isGrounded)
        // {
        //     animator.SetBool("isReachedGround",true);
        // }
        // animator.SetBool("isReachedGround",false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJump",false);
            animator.SetBool("isReachedGround",true);
        }
    }
    void OnCollisionExit(Collision collision)
    {
        animator.SetBool("isReachedGround",false);
    }

}
