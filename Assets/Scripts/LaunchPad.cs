using UnityEngine;
using System.Collections; // IEnumerator를 사용하기 위해 추가

public class LaunchPad : MonoBehaviour
{
    public Transform targetPosition; // 플레이어가 날아갈 목표 위치
    public float travelTime = 1.0f; // 플레이어가 목표 위치까지 이동하는 시간
    public LayerMask playerLayer; // 플레이어가 속한 레이어

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어 레이어와 충돌했는지 확인
        if (((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            // 플레이어의 Transform을 가져온다.
            Transform playerTransform = other.transform;
            // 목표 위치로 플레이어를 부드럽게 이동시키는 코루틴을 시작한다.
            StartCoroutine(MovePlayer(playerTransform));
        }
    }

    private IEnumerator MovePlayer(Transform playerTransform)
    {
        Vector3 startPosition = playerTransform.position;
        Vector3 endPosition = targetPosition.position;
        float elapsedTime = 0;

        while (elapsedTime < travelTime)
        {
            playerTransform.position = Vector3.Lerp(startPosition, endPosition, (elapsedTime / travelTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        playerTransform.position = endPosition;
    }
}
