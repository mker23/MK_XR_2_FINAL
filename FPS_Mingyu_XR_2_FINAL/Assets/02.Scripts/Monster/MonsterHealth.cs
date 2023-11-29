using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� �±װ� "PlayerBullet" �Ǵ� "PLAYER"���� Ȯ��
        if (collision.gameObject.CompareTag("PLAYERBULLET") || collision.gameObject.CompareTag("PLAYER"))
        {
            // �Ѿ��̳� �÷��̾�� �浹 �� ���� ��� ó��
            Die();

            // �浹�� ������Ʈ ����
            Destroy(collision.gameObject);
        }
    }

    void Die()
    {
        // ���� ��� ó�� (���� ��� ���� �ִϸ��̼� ���, ������Ʈ ���� ��)
        Destroy(gameObject);
    }
}

