using System.Collections;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject wallPrefab;
    private Renderer rend;
    private float width;
    private Vector3 initialWallPos;
    private const int numberOfObstacles = 5;
    public GameObject[] barriers = new GameObject[numberOfObstacles];
    private Vector3 spawnPosition = new Vector3(40f,0.7767304f,6f);
    private int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("GenerateObstacles",3f,10f);
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
        // barriers[index].transform.Translate(Vector3.left*Time.deltaTime*5f);
    }

    void GenerateObstacles()
    {
        index = Random.Range(0,numberOfObstacles);
        Instantiate(barriers[index],spawnPosition,barriers[index].transform.rotation);
        // yield return new WaitForSeconds(5f);
    }
}
