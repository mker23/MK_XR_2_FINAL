using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_WallDestroy : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // �浹�� ��� ������Ʈ�� �ı�
        Destroy(gameObject);
    }
}