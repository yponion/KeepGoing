using UnityEngine;
using System.Collections; // IEnumerator를 사용하기 위해 추가

public class ToiletDown : MonoBehaviour
{
    public Transform[] waypoints; // 중간 목표 위치 배열
    public float travelTime = 1.0f; // 각 위치까지 이동하는 시간
    public LayerMask playerLayer; // 플레이어가 속한 레이어

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어 레이어와 충돌했는지 확인
        if (((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            // 플레이어의 Transform을 가져온다.
            Transform playerTransform = other.transform;
            // 목표 위치들로 플레이어를 부드럽게 이동시키는 코루틴을 시작한다.
            StartCoroutine(MovePlayer(playerTransform));
        }
    }

    private IEnumerator MovePlayer(Transform playerTransform)
    {
        foreach (Transform targetPosition in waypoints)
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
            // yield return new WaitForSeconds(0.5f); // 각 위치에 도착 후 잠시 대기
        }
    }
}