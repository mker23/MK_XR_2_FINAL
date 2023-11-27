// SlashMove.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashMove : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도
    public Vector3 moveDirection = Vector3.forward; // 이동 방향
    public float timeToDestroy = 5f; // 파괴까지의 시간

    void Start()
    {
        // 정면으로 이동하는 코루틴을 실행
        StartCoroutine(MoveForward());
    }

    IEnumerator MoveForward()
    {
        while (true)
        {
            // 오브젝트를 현재 방향으로 이동
            transform.Translate(-moveDirection * moveSpeed * Time.deltaTime);

            yield return null;
        }
    }

   

  


}
