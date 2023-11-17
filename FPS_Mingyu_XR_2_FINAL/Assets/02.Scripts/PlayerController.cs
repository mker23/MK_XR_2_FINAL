using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 3f;
    public float maxVerticalRotation = 80f; // �ִ� ���� ȸ�� ����
    public float jumpForce = 10f; // ���� �� ������ ���� ����

    private float verticalRotation = 0f;
    private bool isGrounded;

    private void Update()
    {
        // �÷��̾� �̵� ó��
        MovePlayer();

        // ���콺 �̵����� ī�޶� ȸ�� ó��
        RotateCamera();

        // �����̽��ٸ� ������ �� ���� ����
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

        // ���� ȸ�� (�¿� �̵�)
        transform.Rotate(Vector3.up * mouseX * rotationSpeed);

        // ���� ȸ�� (���� �̵�)
        Camera mainCamera = Camera.main;
        verticalRotation -= mouseY * rotationSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -maxVerticalRotation, maxVerticalRotation);

        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    void Jump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    // �÷��̾ ���� ����� �� ȣ��Ǵ� �޼���
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // �÷��̾ ������ �������� �� ȣ��Ǵ� �޼���
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}







