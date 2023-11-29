using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform을 할당
    public float moveSpeed = 5f; // 몬스터의 이동 속도

    void Update()
    {
        if (player != null)
        {
            // 플레이어 방향으로 회전
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToPlayer.x, 0f, directionToPlayer.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            // 플레이어를 향해 이동
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}

