using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 3f;
    public float maxVerticalRotation = 80f; // 최대 수직 회전 각도

    private float verticalRotation = 0f;

    private void Update()
    {
        // 플레이어 이동 처리
        MovePlayer();

        // 마우스 이동으로 카메라 회전 처리
        RotateCamera();
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // 수평 회전 (좌우 이동)
        transform.Rotate(Vector3.up * mouseX * rotationSpeed);

        // 수직 회전 (상하 이동)
        Camera mainCamera = Camera.main;
        verticalRotation -= mouseY * rotationSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -maxVerticalRotation, maxVerticalRotation);

        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}






