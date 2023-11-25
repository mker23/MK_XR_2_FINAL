using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashMakerHealth : MonoBehaviour
{
    public int monsterHealth = 20;  // ������ �ʱ� ü��

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PLAYERBULLET"))
        {
            TakeDamage(10);  // BULLET�� �浹 �� 10��ŭ�� �������� ����
        }
    }

    void TakeDamage(int damage)
    {
        monsterHealth -= damage;  // ��������ŭ ���� ü�� ����

        if (monsterHealth <= 0)
        {
            Die();  // ü���� 0 ���ϸ� ���Ͱ� �״� ó���� ����
        }
    }

    void Die()
    {
        // ���⿡ ���Ͱ� ���� �� ������ ������ �߰�
        Debug.Log("SLASHMAKER ���Ͱ� ���!");
        // ���� ���, ���� ��� �ִϸ��̼� ���, ���� �߰� ���� ó���� �߰��� �� �ֽ��ϴ�.

        // ���� ������Ʈ ����
        Destroy(gameObject);
    }
}

