using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 3f;
    public float maxVerticalRotation = 80f; // �ִ� ���� ȸ�� ����
    public float jumpForce = 10f; // ���� �� ������ ���� ����

    private bool isGrounded;
    private bool isMouseMoving = false; // ���콺 ������ ����

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

        // ���콺�� �������� ���� ȸ�� ó��
        if (mouseX != 0 || mouseY != 0)
        {
            isMouseMoving = true;

            // ���� ȸ�� (�¿� �̵�)
            transform.Rotate(Vector3.up * mouseX * rotationSpeed);

            // ���� ȸ�� (���� �̵�)
            float verticalRotation = -mouseY * rotationSpeed;
            Camera camera = GetComponentInChildren<Camera>();

            // ���� ���� ȸ�� ������ ����
            float currentVerticalRotation = camera.transform.localEulerAngles.x;

            // ���ο� ���� ȸ�� ������ ���
            float newVerticalRotation = currentVerticalRotation + verticalRotation;


            // ī�޶��� ���� ȸ�� ����
            camera.transform.localEulerAngles = new Vector3(newVerticalRotation, 0f, 0f);
        }
        else
        {
            // ���콺�� �������� ������ ����
            isMouseMoving = false;
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    // �÷��̾ ���� ����� �� ȣ��Ǵ� �޼���
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GROUND"))
        {
            isGrounded = true;
        }
    }

    // �÷��̾ ������ �������� �� ȣ��Ǵ� �޼���
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("GROUND"))
        {
            isGrounded = false;
        }
    }
}
