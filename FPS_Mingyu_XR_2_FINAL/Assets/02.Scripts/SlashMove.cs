using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashMove : MonoBehaviour
{
    public float speed = 5f; // �̵� �ӵ� ����

    void Start()
    {
        // �ʱ� ȸ���� �����Ͽ� X������ �����̵��� ��
        transform.Rotate(Vector3.up, 90f);
    }

    void Update()
    {
        // X�� �������� �̵�
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}



