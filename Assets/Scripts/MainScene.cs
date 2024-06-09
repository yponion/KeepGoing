using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets; // ThirdPersonController가 포함된 네임스페이스를 추가


public class MainScene : MonoBehaviour
{
    public GameObject buttons;

    public GameObject easyWall;
    public GameObject nomalWall;

    public GameObject P1;
    public GameObject P2;

    public GameObject ctrl;
    public GameObject alt;

    private ThirdPersonController thirdPersonController;
    private Timer timer;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        buttons.SetActive(false);

        // ThirdPersonController 컴포넌트를 가져옴
        thirdPersonController = FindObjectOfType<ThirdPersonController>();
        timer = FindObjectOfType<Timer>();

        if (StartScene.level == 0) // easy
        {
            easyWall.SetActive(false);
            nomalWall.SetActive(false);
            P1.SetActive(false);
            P2.SetActive(false);
            ctrl.SetActive(true);
            alt.SetActive(true);
        }
        else if (StartScene.level == 1) // nomal
        {
            easyWall.SetActive(true);
            nomalWall.SetActive(false);
            P1.SetActive(true);
            P2.SetActive(false);
            ctrl.SetActive(false);
            alt.SetActive(true);
        }
        else // hard
        {
            easyWall.SetActive(true);
            nomalWall.SetActive(true);
            P1.SetActive(true);
            P2.SetActive(true);
            ctrl.SetActive(false);
            alt.SetActive(false);
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
            if (isActive)
            {
                Time.timeScale = 0f;
                thirdPersonController.enabled = false;
                timer.PauseTimer();
            }
            else
            {
                Time.timeScale = 1f;
                thirdPersonController.enabled = true;
                timer.ResumeTimer();
            }
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