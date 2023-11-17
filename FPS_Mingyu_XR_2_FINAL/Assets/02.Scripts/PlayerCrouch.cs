using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    public float crouchHeight = 0.5f; // ��ũ���� �� �÷��̾� ����
    public float crouchColliderHeight = 0.5f; // ��ũ���� �� �ݶ��̴� ����
    public float crouchCameraHeight = 0.5f; // ��ũ���� �� ī�޶� ����
    public LayerMask groundLayer; // ���� ���̾�

    private bool isCrouching;

    void Update()
    {
        // Ctrl Ű�� ������ �� ��ũ���� ó��
        if (Input.GetKey(KeyCode.LeftControl) && CanCrouch())
        {
            Crouch();
        }
        else
        {
            StandUp();
        }
    }

    void Crouch()
    {
        if (!isCrouching)
        {
            isCrouching = true;
            transform.localScale = new Vector3(1f, crouchHeight, 1f);
            GetComponent<CapsuleCollider>().height = crouchColliderHeight;

            // ������ Ŭ���� ���
            Camera.main.nearClipPlane = 0.01f;

            Camera.main.transform.localPosition = new Vector3(0f, -crouchCameraHeight, 0f);
        }
    }

    void StandUp()
    {
        if (isCrouching)
        {
            isCrouching = false;
            transform.localScale = new Vector3(1f, 1f, 1f);
            GetComponent<CapsuleCollider>().height = 2f; // �⺻ �÷��̾� ����

            // �⺻ Ŭ���� ��� ��
            Camera.main.nearClipPlane = 0.3f;

            Camera.main.transform.localPosition = Vector3.zero; // �⺻ ī�޶� ����
        }
    }

    bool CanCrouch()
    {
        RaycastHit hit;
        float rayDistance = 2f; // �÷��̾�� �������� �ִ� �Ÿ�

        // �÷��̾� ��ġ���� �Ʒ� �������� ���̸� ���� ���� �ִ��� üũ
        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayDistance, groundLayer))
        {
            float distanceToGround = hit.distance;

            // ��ũ�� ���¿��� ������ �Ÿ��� ��ũ���� �� ���̺��� �۰ų� ������ ��ũ�� �� ����
            return distanceToGround <= crouchHeight;
        }

        // ���̰� �ƹ��͵� ���� ������ ��ũ�� �� ����
        return true;
    }
}




