using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashDestroy : MonoBehaviour
{
    public float destroyTime = 5f; // ������������ �ð� (��: 5��)

    void Start()
    {
        // ���� �ð� �Ŀ� �ڵ����� ������Ʈ�� ����
        Destroy(gameObject, destroyTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� "PLAYER" �±׸� ������ �ִٸ�
        if (collision.gameObject.CompareTag("PLAYER"))
        {
            // �����θ� ��� ����
            Destroy(gameObject);
        }
    }
}



