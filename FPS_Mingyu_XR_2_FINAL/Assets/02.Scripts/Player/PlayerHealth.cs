using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 100;  // 초기 체력 값

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MONSTER")) // MONSTER 태그와 충돌 시
        {
            TakeDamage(40);  // 충돌 시 40만큼의 데미지를 받음
        }
        else if (collision.gameObject.CompareTag("SLASH")) // SLASH 태그와 충돌 시
        {
            TakeDamage(20);  // SLASH에 맞을 시 20만큼의 데미지를 받음
        }
    }

    void TakeDamage(int damage)
    {
        playerHealth -= damage;  // 데미지만큼 체력 감소

        if (playerHealth <= 0)
        {
            Die();  // 체력이 0 이하면 사망 함수 호출
        }
    }

    void Die()
    {
        // GameOver 씬으로 전환
        SceneManager.LoadScene("GameOver");
    }
}


