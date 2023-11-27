using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_WallDestroy : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // 충돌한 모든 오브젝트를 파괴
        Destroy(gameObject);
    }
}