using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform firstPositino; // 엘리베이터의 초기 위치
    public Transform endPosition; // 엘리베이터의 도착 위치
    public float speed = 2.0f; // 엘리베이터 이동 속도
    public LayerMask playerLayer; // 플레이어가 속한 레이어

    private int playerCount = 0; // 엘리베이터에 있는 플레이어 수

    private void Update()
    {
        if (playerCount > 0)
        {
            // 엘리베이터를 도착지로 이동
            transform.position = Vector3.MoveTowards(transform.position, endPosition.position, speed * Time.deltaTime);
        }
        else
        {
            // 엘리베이터를 출발지로 이동
            transform.position = Vector3.MoveTowards(transform.position, firstPositino.position, speed * Time.deltaTime);
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
        }
    }
}
