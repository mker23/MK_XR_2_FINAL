// SlashMove.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashMove : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ�
    public Vector3 moveDirection = Vector3.forward; // �̵� ����
    public float timeToDestroy = 5f; // �ı������� �ð�

    void Start()
    {
        // �������� �̵��ϴ� �ڷ�ƾ�� ����
        StartCoroutine(MoveForward());
    }

    IEnumerator MoveForward()
    {
        while (true)
        {
            // ������Ʈ�� ���� �������� �̵�
            transform.Translate(-moveDirection * moveSpeed * Time.deltaTime);

            yield return null;
        }
    }

   

  


}
