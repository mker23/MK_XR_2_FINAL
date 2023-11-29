using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트의 태그가 "PlayerBullet" 또는 "PLAYER"인지 확인
        if (collision.gameObject.CompareTag("PLAYERBULLET") || collision.gameObject.CompareTag("PLAYER"))
        {
            // 총알이나 플레이어와 충돌 시 몬스터 사망 처리
            Die();

            // 충돌한 오브젝트 삭제
            Destroy(collision.gameObject);
        }
    }

    void Die()
    {
        // 몬스터 사망 처리 (예를 들어 폭발 애니메이션 재생, 오브젝트 제거 등)
        Destroy(gameObject);
    }
}

