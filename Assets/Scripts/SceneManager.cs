using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject wallPrefab;
    private Renderer rend;
    private float width;
    private Vector3 initialWallPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = wallPrefab.GetComponent<Renderer>();
        Vector3 wallSize = rend.bounds.size;
        width = wallSize.x;
        Debug.Log("X :- " + wallSize.x);
        Debug.Log("Y :- " + wallSize.y);
        Debug.Log("Z :- " + wallSize.z);
        initialWallPos = wallPrefab.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        wallPrefab.transform.Translate(Vector3.left*Time.deltaTime*5f);
        if(Vector3.Distance(wallPrefab.transform.position,initialWallPos) >= width / 2)
        {
            wallPrefab.transform.position = initialWallPos;
        }
    }
}
