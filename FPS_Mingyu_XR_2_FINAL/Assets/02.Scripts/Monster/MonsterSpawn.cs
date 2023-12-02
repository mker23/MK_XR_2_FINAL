using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public GameObject monsterPrefab; // ���� �������� ������ ����
    public float spawnInterval = 2f; // ���� ���� ���� (��)

    void Start()
    {
        // Start �Լ����� InvokeRepeating�� ����Ͽ� ���� �������� ���� ���� �Լ��� ȣ���մϴ�.
        InvokeRepeating("SpawnMonster", 0f, spawnInterval);
    }

    void SpawnMonster()
    {
        // �÷��̾ ã���ϴ�. ���⼭�� "Player" �±׸� ���� ������Ʈ�� ã���ϴ�.
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // �÷��̾ ���� �� ���͸� �����մϴ�.
        if (player == null)
        {
            // ���͸� �����ϴ� �ڵ��Դϴ�. ��ġ�� ȸ�� ���� ������ �� �ֽ��ϴ�.
            Instantiate(monsterPrefab, transform.position, Quaternion.identity);
        }
    }
}

