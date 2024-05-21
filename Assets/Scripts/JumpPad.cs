using UnityEngine;
using StarterAssets;  // ThirdPersonController의 네임스페이스 추가

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 10f; // 점프의 힘을 조정할 수 있는 변수
    public LayerMask playerLayer; // 플레이어 레이어를 설정

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어 레이어와 충돌했는지 확인
        if (((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            // 플레이어의 ThirdPersonController 스크립트를 가져옵니다
            ThirdPersonController playerController = other.GetComponent<ThirdPersonController>();

            if (playerController != null)
            {
                // 점프 힘을 적용하는 메서드 호출
                playerController.AddJumpForce(jumpForce);
            }
        }
    }
}
