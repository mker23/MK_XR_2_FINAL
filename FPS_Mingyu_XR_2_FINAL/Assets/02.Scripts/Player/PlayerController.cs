using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 3f;
    public float maxVerticalRotation = 80f; // 최대 수직 회전 각도
    public float jumpForce = 10f; // 점프 힘 조절을 위한 변수

    private bool isGrounded;
    private bool isMouseMoving = false; // 마우스 움직임 여부

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

        // 마우스를 움직였을 때만 회전 처리
        if (mouseX != 0 || mouseY != 0)
        {
            isMouseMoving = true;

            // 수평 회전 (좌우 이동)
            transform.Rotate(Vector3.up * mouseX * rotationSpeed);

            // 수직 회전 (상하 이동)
            float verticalRotation = -mouseY * rotationSpeed;
            Camera camera = GetComponentInChildren<Camera>();

            // 현재 수직 회전 각도를 구함
            float currentVerticalRotation = camera.transform.localEulerAngles.x;

            // 새로운 수직 회전 각도를 계산
            float newVerticalRotation = currentVerticalRotation + verticalRotation;


            // 카메라의 수직 회전 적용
            camera.transform.localEulerAngles = new Vector3(newVerticalRotation, 0f, 0f);
        }
        else
        {
            // 마우스를 움직이지 않으면 고정
            isMouseMoving = false;
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    // 플레이어가 땅에 닿았을 때 호출되는 메서드
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GROUND"))
        {
            isGrounded = true;
        }
    }

    // 플레이어가 땅에서 떨어졌을 때 호출되는 메서드
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("GROUND"))
        {
            isGrounded = false;
        }
    }
}
