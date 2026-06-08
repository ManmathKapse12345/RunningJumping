using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSceneManager : MonoBehaviour
{
    public void GoToMainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    public void GoToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is create
}
