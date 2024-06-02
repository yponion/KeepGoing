using UnityEngine;

public class VisibilityController : MonoBehaviour
{
    public GameObject targetObject; // 보이게 할 물체
    public LayerMask playerLayer; // 플레이어가 속한 레이어

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어 레이어와 충돌했는지 확인
        if (((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            targetObject.SetActive(true); // 플레이어가 트리거에 들어오면 물체를 보이게 함
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 플레이어 레이어와 충돌했는지 확인
        if (((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            targetObject.SetActive(false); // 플레이어가 트리거를 나가면 물체를 보이지 않게 함
        }
    }
}