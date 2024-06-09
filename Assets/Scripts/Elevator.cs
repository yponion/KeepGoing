using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform firstPosition; // 엘리베이터의 초기 위치
    public Transform endPosition; // 엘리베이터의 도착 위치
    public float speed = 2.0f; // 엘리베이터 이동 속도
    public LayerMask playerLayer; // 플레이어가 속한 레이어
    public AudioClip movingSound; // 엘리베이터 이동 소리

    private int playerCount = 0; // 엘리베이터에 있는 플레이어 수
    private AudioSource audioSource; // 오디오 소스
    private bool isMoving = false; // 엘리베이터가 이동 중인지 여부

    private void Start()
    {
        // 오디오 소스 컴포넌트 가져오기 또는 추가
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = movingSound;
        audioSource.loop = true; // 루프 설정
    }

    private void Update()
    {
        if (playerCount > 0)
        {
            // 엘리베이터를 도착지로 이동
            MoveElevator(endPosition.position);
        }
        else
        {
            // 엘리베이터를 출발지로 이동
            MoveElevator(firstPosition.position);
        }
    }

    private void MoveElevator(Vector3 targetPosition)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // 엘리베이터가 이동 중인지 확인
        if (transform.position != targetPosition)
        {
            if (!isMoving)
            {
                isMoving = true;
                audioSource.Play(); // 이동 소리 재생 시작
            }
        }
        else
        {
            if (isMoving)
            {
                isMoving = false;
                audioSource.Stop(); // 이동 소리 정지
            }
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