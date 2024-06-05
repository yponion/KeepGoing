using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public static bool isCtrlEnabled = false;
    public static bool isAltEnabled = false;

    public void StartGameEasy()
    {
        isCtrlEnabled = true;
        isAltEnabled = true;
        LoadMainScene();
    }

    public void StartGameNormal()
    {
        isCtrlEnabled = false;
        isAltEnabled = true;
        LoadMainScene();
    }

    public void StartGameHard()
    {
        isCtrlEnabled = false;
        isAltEnabled = false;
        LoadMainScene();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene("Main");
    }
}