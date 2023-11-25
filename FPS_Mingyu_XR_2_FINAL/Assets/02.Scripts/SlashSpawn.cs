using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashSpawn : MonoBehaviour
{
    public GameObject SlashPrefab;
    public Transform player; // 플레이어 오브젝트에 대한 참조
    public float spawnInterval = 2f; // 생성 주기

    void Start()
    {
        // 일정 주기로 오브젝트 생성
        InvokeRepeating("SpawnSlashObject", 0f, spawnInterval);
    }

    void SpawnSlashObject()
    {
        // 현재 스크립트가 부착된 오브젝트의 위치를 얻어옴
        Vector3 spawnPosition = transform.position;

        // 프리팹을 현재 위치에 생성
        GameObject slashObject = Instantiate(SlashPrefab, spawnPosition, Quaternion.identity);

        // 플레이어가 존재하면 플레이어의 방향으로 회전
        if (player != null)
        {
            Vector3 playerDirection = player.forward;
            slashObject.transform.forward = playerDirection;
        }
    }
}
