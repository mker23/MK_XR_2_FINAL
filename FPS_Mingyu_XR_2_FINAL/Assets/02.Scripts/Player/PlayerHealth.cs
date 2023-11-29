using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 100;  // �ʱ� ü�� ��

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MONSTER")) // MONSTER �±׿� �浹 ��
        {
            TakeDamage(40);  // �浹 �� 40��ŭ�� �������� ����
        }
        else if (collision.gameObject.CompareTag("SLASH")) // SLASH �±׿� �浹 ��
        {
            TakeDamage(20);  // SLASH�� ���� �� 20��ŭ�� �������� ����
        }
    }

    void TakeDamage(int damage)
    {
        playerHealth -= damage;  // ��������ŭ ü�� ����

        if (playerHealth <= 0)
        {
            Die();  // ü���� 0 ���ϸ� ��� �Լ� ȣ��
        }
    }

    void Die()
    {
        // GameOver ������ ��ȯ
        SceneManager.LoadScene("GameOver");
    }
}


