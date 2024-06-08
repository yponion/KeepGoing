using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TVoff : MonoBehaviour
{
    public GameObject tvScreen;
    public GameObject onObject;
    public GameObject underObject;
    public GameObject timerText;
    public LayerMask playerLayer; // 플레이어 레이어

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            Text textComponent = timerText.GetComponent<Text>();
            int initialFontSize = textComponent.fontSize;
            int targetFontSize = 500;

            Vector3 timerTextTargetPos = new Vector3(timerText.transform.position.x + 850f, timerText.transform.position.y - 515f, timerText.transform.position.z);
            StartCoroutine(ChangePropertiesOverTime(tvScreen, onObject, underObject, timerText, 1f, 0f, tvScreen.transform.localScale.z, onObject.transform.position.y - 540f, onObject.transform.position.y, underObject.transform.position.y + 540f, underObject.transform.position.y, timerTextTargetPos, timerText.transform.position, targetFontSize, initialFontSize));

            // 타이머 멈춤
            Timer timerComponent = timerText.GetComponent<Timer>();
            if (timerComponent != null)
            {
                timerComponent.PauseTimer();
            }

            // 2초 후 게임 종료
            StartCoroutine(EndGameAfterDelay(2f));
        }
    }

    private IEnumerator ChangePropertiesOverTime(GameObject scaleObj, GameObject moveObj1, GameObject moveObj2, GameObject textObj, float duration, float targetHeight, float startHeight, float targetY1, float startY1, float targetY2, float startY2, Vector3 targetTextPos, Vector3 startTextPos, int targetFontSize, int startFontSize)
    {
        float elapsedTime = 0f;
        Vector3 initialScale = scaleObj.transform.localScale;
        Vector3 targetScale = new Vector3(initialScale.x, initialScale.y, targetHeight);

        Text textComponent = textObj.GetComponent<Text>();
        RectTransform textRectTransform = textObj.GetComponent<RectTransform>();

        while (elapsedTime < duration)
        {
            // Change scale on Z axis
            float newZ = Mathf.Lerp(startHeight, targetHeight, elapsedTime / duration);
            scaleObj.transform.localScale = new Vector3(initialScale.x, initialScale.y, newZ);

            // Change position on Y axis for first object
            float newY1 = Mathf.Lerp(startY1, targetY1, elapsedTime / duration);
            moveObj1.transform.position = new Vector3(moveObj1.transform.position.x, newY1, moveObj1.transform.position.z);

            // Change position on Y axis for second object
            float newY2 = Mathf.Lerp(startY2, targetY2, elapsedTime / duration);
            moveObj2.transform.position = new Vector3(moveObj2.transform.position.x, newY2, moveObj2.transform.position.z);

            // Change position for text object
            textObj.transform.position = Vector3.Lerp(startTextPos, targetTextPos, elapsedTime / duration);

            // Change font size for text object
            textComponent.fontSize = (int)Mathf.Lerp(startFontSize, targetFontSize, elapsedTime / duration);

            // Update RectTransform size based on new font size
            textRectTransform.sizeDelta = new Vector2(textComponent.preferredWidth, textComponent.preferredHeight);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the scale and position are set to the target values at the end
        scaleObj.transform.localScale = targetScale;
        moveObj1.transform.position = new Vector3(moveObj1.transform.position.x, targetY1, moveObj1.transform.position.z);
        moveObj2.transform.position = new Vector3(moveObj2.transform.position.x, targetY2, moveObj2.transform.position.z);
        textObj.transform.position = targetTextPos;
        textComponent.fontSize = targetFontSize;

        // Update RectTransform size based on final font size
        textRectTransform.sizeDelta = new Vector2(textComponent.preferredWidth, textComponent.preferredHeight);
    }

    private IEnumerator EndGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void ResumeTimer()
    {
        Timer timerComponent = timerText.GetComponent<Timer>();
        if (timerComponent != null)
        {
            timerComponent.ResumeTimer();
        }
    }
}