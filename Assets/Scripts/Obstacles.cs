using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private float speed = 5f;
    private SceneManager sceneManagerScript;
    private Animator animator;
    private bool isLanding = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneManagerScript = GameObject.Find("SceneManager").GetComponent<SceneManager>();
        animator = GameObject.Find("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isLanding = animator.GetCurrentAnimatorStateInfo(0).IsName("HumanM@Jump01 - Land");
        if (!sceneManagerScript.level1Completed && !isLanding)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        }
    }
}
