using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed = 200f;  // 대쉬 속도 조절

    public float dashDistance = 0.001f;  // 대쉬 거리 조절
    public float maxDashTime = 1.0f;  // 최대 대쉬 시간 조절


    private Rigidbody rb;
    private bool isDashing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 왼쪽 Shift키를 누르면 대쉬 시작
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            isDashing = true;

            // 방향 키 입력을 감지하여 대쉬 방향 결정
            Vector3 dashDirection = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
                dashDirection += transform.forward;
            if (Input.GetKey(KeyCode.A))
                dashDirection -= transform.right;
            if (Input.GetKey(KeyCode.S))
                dashDirection -= transform.forward;
            if (Input.GetKey(KeyCode.D))
                dashDirection += transform.right;

            // 대쉬 방향 벡터를 정규화하여 이동 방향 설정
            dashDirection.Normalize();

            // Rigidbody를 사용하여 대쉬
            rb.velocity = dashDirection * dashSpeed;

            // 대쉬가 일정 시간 동안 지속되도록 설정 
            StartCoroutine(StopDashing(maxDashTime));
        }
    }

    // 대쉬 중지 함수
    IEnumerator StopDashing(float duration)
    {
        yield return new WaitForSeconds(duration);
        isDashing = false;
        rb.velocity = Vector3.zero;  // 대쉬 종료 시 속도를 초기화하여 캐릭터를 정지시킴
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 플레이어가 벽과 충돌했을 때 대쉬 종료
        if (isDashing)
        {
            isDashing = false;
            rb.velocity = Vector3.zero;
        }
    }
}

