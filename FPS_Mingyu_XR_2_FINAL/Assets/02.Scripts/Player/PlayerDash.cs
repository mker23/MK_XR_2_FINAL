using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed = 200f;  // �뽬 �ӵ� ����

    public float dashDistance = 0.001f;  // �뽬 �Ÿ� ����
    public float maxDashTime = 1.0f;  // �ִ� �뽬 �ð� ����


    private Rigidbody rb;
    private bool isDashing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ���� ShiftŰ�� ������ �뽬 ����
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            isDashing = true;

            // ���� Ű �Է��� �����Ͽ� �뽬 ���� ����
            Vector3 dashDirection = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
                dashDirection += transform.forward;
            if (Input.GetKey(KeyCode.A))
                dashDirection -= transform.right;
            if (Input.GetKey(KeyCode.S))
                dashDirection -= transform.forward;
            if (Input.GetKey(KeyCode.D))
                dashDirection += transform.right;

            // �뽬 ���� ���͸� ����ȭ�Ͽ� �̵� ���� ����
            dashDirection.Normalize();

            // Rigidbody�� ����Ͽ� �뽬
            rb.velocity = dashDirection * dashSpeed;

            // �뽬�� ���� �ð� ���� ���ӵǵ��� ���� 
            StartCoroutine(StopDashing(maxDashTime));
        }
    }

    // �뽬 ���� �Լ�
    IEnumerator StopDashing(float duration)
    {
        yield return new WaitForSeconds(duration);
        isDashing = false;
        rb.velocity = Vector3.zero;  // �뽬 ���� �� �ӵ��� �ʱ�ȭ�Ͽ� ĳ���͸� ������Ŵ
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �÷��̾ ���� �浹���� �� �뽬 ����
        if (isDashing)
        {
            isDashing = false;
            rb.velocity = Vector3.zero;
        }
    }
}

