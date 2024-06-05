using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    public GameObject buttons;


    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ESC();
        }
    }

    private void ESC()
    {
        bool isActive = !buttons.activeSelf;
        buttons.SetActive(isActive); // 활성화 상태를 토글

        // 마우스 커서 표시 및 잠금 상태 설정
        Cursor.visible = isActive;
        Cursor.lockState = isActive ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void KeepGoing()
    {
        ESC();
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