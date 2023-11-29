using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform�� �Ҵ�
    public float moveSpeed = 5f; // ������ �̵� �ӵ�

    void Update()
    {
        if (player != null)
        {
            // �÷��̾� �������� ȸ��
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToPlayer.x, 0f, directionToPlayer.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            // �÷��̾ ���� �̵�
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}

