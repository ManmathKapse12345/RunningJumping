using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int level;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(Instance.gameObject);
        }
        Instance=this;
        DontDestroyOnLoad(gameObject);
    }

    public void ChooseLevel1()
    {
        Debug.Log("Level 1 is clicked");
        GameManager.Instance.level=0;
        SceneManager.LoadScene("GameScene");
    }
    public void ChooseLevel2()
    {
        Debug.Log("Level 2 is clicked");
        GameManager.Instance.level=1;
        SceneManager.LoadScene("GameScene");
    }
    public void ChooseLevel3()
    {
        Debug.Log("Level 3 is clicked");
        GameManager.Instance.level=2;
        SceneManager.LoadScene("GameScene");
    }
    public void ChooseLevel4()
    {
        Debug.Log("Level 4 is clicked");
        GameManager.Instance.level=3;
        SceneManager.LoadScene("GameScene");
    }
    public void ChooseLevel5()
    {
        Debug.Log("Level 5 is clicked");
        GameManager.Instance.level=4;
        SceneManager.LoadScene("GameScene");
    }
}
