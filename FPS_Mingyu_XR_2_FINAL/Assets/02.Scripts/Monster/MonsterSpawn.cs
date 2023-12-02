using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public GameObject monsterPrefab; // 몬스터 프리팹을 연결할 변수
    public float spawnInterval = 2f; // 몬스터 생성 간격 (초)

    void Start()
    {
        // Start 함수에서 InvokeRepeating을 사용하여 일정 간격으로 몬스터 생성 함수를 호출합니다.
        InvokeRepeating("SpawnMonster", 0f, spawnInterval);
    }

    void SpawnMonster()
    {
        // 플레이어를 찾습니다. 여기서는 "Player" 태그를 가진 오브젝트를 찾습니다.
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // 플레이어가 없을 때 몬스터를 생성합니다.
        if (player == null)
        {
            // 몬스터를 생성하는 코드입니다. 위치나 회전 등을 조정할 수 있습니다.
            Instantiate(monsterPrefab, transform.position, Quaternion.identity);
        }
    }
}

