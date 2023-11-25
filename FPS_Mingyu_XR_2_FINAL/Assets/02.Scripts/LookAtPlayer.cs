using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player; // �÷��̾� ������Ʈ�� ���� ����

    void Update()
    {
        // �÷��̾ �����ϴ��� Ȯ��
        if (player != null)
        {
            // �÷��̾ �ٶ󺸴� ���� ���� ���
            Vector3 directionToPlayer = player.position - transform.position;

            // y �� ������ ȸ�� ������ ������� ����
            directionToPlayer.y = 0;

            // ���� ���͸� ȸ�� ������ ��ȯ�Ͽ� ������Ʈ�� ȸ����Ŵ
            float angle = Mathf.Atan2(directionToPlayer.z, directionToPlayer.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
        }
    }
}
