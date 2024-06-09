using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOne : MonoBehaviour
{
    public AudioClip collisionSound; // 충돌 시 재생할 소리
    private AudioSource audioSource; // 오디오 소스
    public LayerMask playerLayer; // 플레이어가 속한 레이어
    private bool one = true; // 한번만 재생

    void Start()
    {
        // 오디오 소스 컴포넌트 가져오기 또는 추가
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어 레이어와 충돌했는지 확인
        if (((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            if (one)
            {
                audioSource.PlayOneShot(collisionSound);
                one = false;
            }
        }
    }
}