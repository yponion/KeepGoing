using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float time;
    private float startTime;

    // Use this for initialization
    void Start()
    {
        startTime = Time.realtimeSinceStartup;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 경과 시간을 계산
        time = Time.realtimeSinceStartup - startTime;

        int hours = Mathf.FloorToInt(time / 3600);
        int minutes = Mathf.FloorToInt((time % 3600) / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        Text uiText = GetComponent<Text>();

        if (time < 60)
        {
            // 총 시간이 60초를 넘기지 않은 경우
            uiText.text = string.Format("{0:D2}", seconds);
        }
        else if (time < 3600)
        {
            // 총 시간이 60분을 넘기지 않은 경우
            uiText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
        }
        else
        {
            // 총 시간이 1시간을 넘긴 경우
            uiText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
        }
    }
}
