using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundGround : MonoBehaviour
{
    public AudioClip collisionSound; // 충돌 시 재생할 소리
    private AudioSource audioSource; // 오디오 소스
    public LayerMask playerLayer; // 플레이어가 속한 레이어
    private int playerCount = 0; // 물체위의 플레이어 수
    private int cnt = 1; // 한번만 재생

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
        if (playerCount > 0 && cnt == 0 && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(collisionSound);
            cnt = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어 레이어와 충돌했는지 확인
        if (((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            playerCount++; // 플레이어가 엘리베이터에 올라탔을 때
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 플레이어 레이어와 충돌했는지 확인
        if (((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            playerCount--; // 플레이어가 엘리베이터에서 내렸을 때
            cnt = 0;
        }
    }
}