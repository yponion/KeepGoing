using UnityEngine;

public class Move : MonoBehaviour
{
    public float X = 0f; // 이동할 x값
    public float Y = 0f; // 이동할 y값
    public float Z = 0f; // 이동할 z값
    public float speed = 1.0f; // 타겟 물체 이동 속도
    public LayerMask playerLayer; // 플레이어가 속한 레이어
    public GameObject targetObject; // 이동시킬 타겟 물체

    private int playerCount = 0; // 물체에 있는 플레이어 수
    private Vector3 targetInitialPosition; // 타겟 물체 초기 위치
    private Vector3 targetEndPosition; // 타겟 물체 도착 위치

    private void Start()
    {
        // 타겟 물체의 초기 및 도착 위치 설정
        if (targetObject != null)
        {
            targetInitialPosition = targetObject.transform.position;
            targetEndPosition = new Vector3(targetInitialPosition.x + X, targetInitialPosition.y + Y, targetInitialPosition.z + Z);
        }
    }

    private void Update()
    {
        if (playerCount > 0)
        {
            // 타겟 물체를 도착지로 이동
            if (targetObject != null)
            {
                targetObject.transform.position = Vector3.MoveTowards(targetObject.transform.position, targetEndPosition, speed * Time.deltaTime);
            }
        }
        else
        {
            // 타겟 물체를 출발지로 이동
            if (targetObject != null)
            {
                targetObject.transform.position = Vector3.MoveTowards(targetObject.transform.position, targetInitialPosition, speed * Time.deltaTime);
            }
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