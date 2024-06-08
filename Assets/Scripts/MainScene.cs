using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    public GameObject buttons;

    public GameObject easyWall;
    public GameObject nomalWall;

    public GameObject P1;
    public GameObject P2;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        buttons.SetActive(false);

        if (StartScene.level == 0) // easy
        {
            easyWall.SetActive(false);
            nomalWall.SetActive(false);
            P1.SetActive(false);
            P2.SetActive(false);
        }
        else if (StartScene.level == 1) // nomal
        {
            easyWall.SetActive(true);
            nomalWall.SetActive(false);
            P1.SetActive(true);
            P2.SetActive(false);
        }
        else // hard
        {
            easyWall.SetActive(true);
            nomalWall.SetActive(true);
            P1.SetActive(true);
            P2.SetActive(true);
        }
    }

    private void Update()
    {
        ESC();
    }

    private void ESC()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool isActive = !buttons.activeSelf;
            buttons.SetActive(isActive);
            Cursor.visible = isActive;
            Cursor.lockState = isActive ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("Start");
    }
}