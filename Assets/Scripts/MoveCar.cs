using UnityEngine;
using System.Collections;

public class MoveCar : MonoBehaviour
{
    public Transform[] waypoints; // 중간 목표 위치 배열
    public float travelTime = 1.0f; // 각 위치까지 이동하는 시간
    public LayerMask playerLayer; // 플레이어가 속한 레이어
    public GameObject targetObject; // 이동시킬 타겟 물체
    public float launchDistance = 10f; // 플레이어가 날아갈 거리
    public float launchHeight = 40f; // 플레이어가 날아갈 높이

    private int collisionCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            collisionCount++;
            if (collisionCount == 1)
            {
                StartCoroutine(MoveObject(targetObject.transform));
            }
            else
            {
                // 물체의 진행 방향으로 플레이어를 날아가게 하는 코루틴을 시작한다.
                StartCoroutine(MovePlayer(other.transform));
            }
        }
    }

    private IEnumerator MoveObject(Transform objectTransform)
    {
        int currentIndex = 0;

        while (true)
        {
            Vector3 startPosition = objectTransform.position;
            Vector3 endPosition = waypoints[currentIndex].position;
            float elapsedTime = 0;
            Quaternion startRotation = objectTransform.rotation;
            Quaternion endRotation;

            if (currentIndex == 0)
            {
                endRotation = Quaternion.Euler(0, 0, 0); // 첫 번째 위치로 이동 시 회전 초기화
            }
            else
            {
                endRotation = Quaternion.Euler(0, objectTransform.eulerAngles.y + 90, 0); // y축 회전 90도 증가
            }

            float rotationStartTime = travelTime - 0.1f;
            float rotationEndTime = travelTime + 0.1f;

            while (elapsedTime < rotationEndTime)
            {
                if (elapsedTime < travelTime)
                {
                    objectTransform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / travelTime);
                }

                if (elapsedTime > rotationStartTime)
                {
                    float rotationLerpFactor = (elapsedTime - rotationStartTime) / 0.2f;
                    objectTransform.rotation = Quaternion.Lerp(startRotation, endRotation, rotationLerpFactor);
                }

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            objectTransform.position = endPosition;
            objectTransform.rotation = endRotation;

            // 다음 목표 지점으로 이동
            currentIndex = (currentIndex + 1) % waypoints.Length;
        }
    }

    private IEnumerator MovePlayer(Transform playerTransform)
    {
        Vector3 startPosition = playerTransform.position;
        Vector3 launchDirection = targetObject.transform.forward; // 물체의 앞쪽 방향
        Vector3 endPosition = startPosition + launchDirection * launchDistance + Vector3.up * launchHeight;
        float elapsedTime = 0;

        while (elapsedTime < travelTime)
        {
            playerTransform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / travelTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        playerTransform.position = endPosition;
    }
}