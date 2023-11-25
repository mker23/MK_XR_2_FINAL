using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashSpawn : MonoBehaviour
{
    public GameObject SlashPrefab;
    public Transform player; // �÷��̾� ������Ʈ�� ���� ����
    public float spawnInterval = 2f; // ���� �ֱ�

    void Start()
    {
        // ���� �ֱ�� ������Ʈ ����
        InvokeRepeating("SpawnSlashObject", 0f, spawnInterval);
    }

    void SpawnSlashObject()
    {
        // ���� ��ũ��Ʈ�� ������ ������Ʈ�� ��ġ�� ����
        Vector3 spawnPosition = transform.position;

        // �������� ���� ��ġ�� ����
        GameObject slashObject = Instantiate(SlashPrefab, spawnPosition, Quaternion.identity);

        // �÷��̾ �����ϸ� �÷��̾��� �������� ȸ��
        if (player != null)
        {
            Vector3 playerDirection = player.forward;
            slashObject.transform.forward = playerDirection;
        }
    }
}
