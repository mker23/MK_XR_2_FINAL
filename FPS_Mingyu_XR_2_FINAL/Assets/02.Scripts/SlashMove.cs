using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashMove : MonoBehaviour
{
    public float speed = 5f; // 이동 속도 설정

    void Start()
    {
        // 초기 회전을 조절하여 X축으로 움직이도록 함
        transform.Rotate(Vector3.up, 90f);
    }

    void Update()
    {
        // X축 방향으로 이동
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}



