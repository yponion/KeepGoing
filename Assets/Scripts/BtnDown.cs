using UnityEngine;

public class BtnDown : MonoBehaviour
{
    public float moveYPosition = -0.09f; // 이동할 y값
    public float speed = 1.0f; // 물체 이동 속도
    public LayerMask playerLayer; // 플레이어가 속한 레이어

    private int playerCount = 0; // 물체에 있는 플레이어 수
    private Vector3 initialPosition; // 물체 초기 위치
    private Vector3 endPosition; // 물체 도착 위치

    private void Start()
    {
        // 초기 위치 설정
        initialPosition = transform.position;

        // 도착 위치 설정
        endPosition = new Vector3(initialPosition.x, initialPosition.y + moveYPosition, initialPosition.z);
    }

    private void Update()
    {
        if (playerCount > 0)
        {
            // 물체를 도착지로 이동
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
        }
        else
        {
            // 물체를 출발지로 이동
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어 레이어와 충돌했는지 확인
        if (((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            playerCount++; // 플레이어가 물체에 올라탔을 때
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 플레이어 레이어와 충돌했는지 확인
        if (((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            playerCount--; // 플레이어가 물체 내려갔을 때
        }
    }
}