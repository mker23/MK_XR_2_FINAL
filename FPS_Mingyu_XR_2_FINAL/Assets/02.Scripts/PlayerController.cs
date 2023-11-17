using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 3f;
    public float maxVerticalRotation = 80f; // 최대 수직 회전 각도
    public float jumpForce = 10f; // 점프 힘 조절을 위한 변수

    private float verticalRotation = 0f;
    private bool isGrounded;

    private void Update()
    {
        // 플레이어 이동 처리
        MovePlayer();

        // 마우스 이동으로 카메라 회전 처리
        RotateCamera();

        // 스페이스바를 눌렀을 때 점프 실행
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // 수평 회전 (좌우 이동)
        transform.Rotate(Vector3.up * mouseX * rotationSpeed);

        // 수직 회전 (상하 이동)
        Camera mainCamera = Camera.main;
        verticalRotation -= mouseY * rotationSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -maxVerticalRotation, maxVerticalRotation);

        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    void Jump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    // 플레이어가 땅에 닿았을 때 호출되는 메서드
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // 플레이어가 땅에서 떨어졌을 때 호출되는 메서드
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}







