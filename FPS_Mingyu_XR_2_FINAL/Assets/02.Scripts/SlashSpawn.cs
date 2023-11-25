using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashSpawn : MonoBehaviour
{
    public GameObject SlashPrefab;

    public Vector3 spawnPosition;  // ������ ��ġ
    public float spawnInterval = 2f;  // ���� �ֱ�

    void Start()
    {
        // ���� �ֱ�� ������Ʈ ����
        InvokeRepeating("SpawnSlashObject", 0f, spawnInterval);
    }

    void SpawnSlashObject()
    {
        // �������� Ư�� ��ġ�� ����
        Instantiate(SlashPrefab, spawnPosition, Quaternion.identity);
    }
}