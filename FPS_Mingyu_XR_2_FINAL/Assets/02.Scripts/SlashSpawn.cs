using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashSpawn : MonoBehaviour
{
    public GameObject SlashPrefab;

    public Vector3 spawnPosition;  // 생성할 위치
    public float spawnInterval = 2f;  // 생성 주기

    void Start()
    {
        // 일정 주기로 오브젝트 생성
        InvokeRepeating("SpawnSlashObject", 0f, spawnInterval);
    }

    void SpawnSlashObject()
    {
        // 프리팹을 특정 위치에 생성
        Instantiate(SlashPrefab, spawnPosition, Quaternion.identity);
    }
}