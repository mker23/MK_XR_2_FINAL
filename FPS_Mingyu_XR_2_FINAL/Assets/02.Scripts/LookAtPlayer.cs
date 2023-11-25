using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player; // 플레이어 오브젝트에 대한 참조

    void Update()
    {
        // 플레이어가 존재하는지 확인
        if (player != null)
        {
            // 플레이어를 바라보는 방향 벡터 계산
            Vector3 directionToPlayer = player.position - transform.position;

            // y 축 방향의 회전 각도는 고려하지 않음
            directionToPlayer.y = 0;

            // 방향 벡터를 회전 각도로 변환하여 오브젝트를 회전시킴
            float angle = Mathf.Atan2(directionToPlayer.z, directionToPlayer.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
        }
    }
}
