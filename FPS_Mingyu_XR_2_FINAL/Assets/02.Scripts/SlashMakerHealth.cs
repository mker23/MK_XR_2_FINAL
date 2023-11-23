using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashMakerHealth : MonoBehaviour
{
    public int monsterHealth = 20;  // 몬스터의 초기 체력

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PLAYERBULLET")
        {
            TakeDamage(10);  // BULLET과 충돌 시 10만큼의 데미지를 받음
        }
    }

    void TakeDamage(int damage)
    {
        monsterHealth -= damage;  // 데미지만큼 몬스터 체력 감소

        if (monsterHealth <= 0)
        {
            Die();  // 체력이 0 이하면 몬스터가 죽는 처리를 수행
        }
    }

    void Die()
    {
        // 여기에 몬스터가 죽을 때 실행할 내용을 추가
        Debug.Log("SLASHMAKER 몬스터가 죽었습니다!");
        // 예를 들어, 몬스터 사망 애니메이션 재생, 점수 추가 등의 처리를 추가할 수 있습니다.

        // 몬스터 오브젝트 제거
        Destroy(gameObject);
    }
}
