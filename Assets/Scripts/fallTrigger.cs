using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallTrigger : MonoBehaviour
{
    public LayerMask playerLayer; // 플레이어가 속한 레이어
    public PlaySoundGround playSoundGround; // PlaySoundGround 인스턴스

    private void Start()
    {
        if (playSoundGround == null)
        {
            playSoundGround = FindObjectOfType<PlaySoundGround>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어 레이어와 충돌했는지 확인
        if (((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            // PlaySoundGround 클래스의 fallTrigger 변수를 true로 변경
            playSoundGround.fallTrigger = true;
        }
    }
}