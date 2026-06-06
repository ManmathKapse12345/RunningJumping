using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private float speed = 5f;
    private SceneManager sceneManagerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneManagerScript = GameObject.Find("SceneManager").GetComponent<SceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!sceneManagerScript.level1Completed)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        }
    }
}
