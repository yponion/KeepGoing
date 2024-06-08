using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public static bool isCtrlEnabled = false;
    public static bool isAltEnabled = false;
    public static int level = 2;

    public void StartGameEasy()
    {
        isCtrlEnabled = true;
        isAltEnabled = true;
        level = 0;
        LoadMainScene();
    }

    public void StartGameNormal()
    {
        isCtrlEnabled = false;
        isAltEnabled = true;
        level = 1;
        LoadMainScene();
    }

    public void StartGameHard()
    {
        isCtrlEnabled = false;
        isAltEnabled = false;
        level = 2;
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