using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundInAndOut : MonoBehaviour
{
    public AudioClip inSound; // 충돌 시 재생할 소리
    public AudioClip outSound; // 나갈 때 재생할 소리
    private AudioSource audioSource; // 오디오 소스
    public LayerMask playerLayer; // 플레이어가 속한 레이어
    private int playerCount = 0; // 물체위의 플레이어 수
    private int inplay = 0; // 한번만 재생
    private int outplay = 1; // 한번만 재생

    void Start()
    {
        // 오디오 소스 컴포넌트 가져오기 또는 추가
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (playerCount > 0 && inplay == 0)
        {
            audioSource.PlayOneShot(inSound);
            inplay = 1;
        } else if (playerCount <= 0 && outplay == 0) {
            audioSource.PlayOneShot(outSound);
            outplay = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어 레이어와 충돌했는지 확인
        if (((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            playerCount++; // 플레이어가 트리거에 들어옴
            outplay = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 플레이어 레이어와 충돌했는지 확인
        if (((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            playerCount--; // 플레이어가 트리거에서 나감
            inplay = 0;
        }
    }
}