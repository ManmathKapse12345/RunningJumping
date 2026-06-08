using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainSceneManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("LevelScene");
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying=false;
        #endif
        Application.Quit();
    }
}
