using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int level;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChooseLevel1()
    {
        level=0;
        SceneManager.LoadScene("GameScene");
    }
    public void ChooseLevel2()
    {
        level=1;
        SceneManager.LoadScene("GameScene");
    }
    public void ChooseLevel3()
    {
        level=2;
        SceneManager.LoadScene("GameScene");
    }
    public void ChooseLevel4()
    {
        level=3;
        SceneManager.LoadScene("GameScene");
    }
    public void ChooseLevel5()
    {
        level=4;
        SceneManager.LoadScene("GameScene");
    }
}
