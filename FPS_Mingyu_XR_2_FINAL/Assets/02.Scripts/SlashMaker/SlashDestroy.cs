using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashDestroy : MonoBehaviour
{
    public float destroyTime = 5f; // 사라지기까지의 시간 (예: 5초)

    void Start()
    {
        // 일정 시간 후에 자동으로 오브젝트를 제거
        Destroy(gameObject, destroyTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트가 "PLAYER" 태그를 가지고 있다면
        if (collision.gameObject.CompareTag("PLAYER"))
        {
            // 스스로를 즉시 제거
            Destroy(gameObject);
        }
    }
}



