using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    public Camera playerCamera; // �÷��̾��� ī�޶�
    public GameObject gunModel;  // �� ��

    void Update()
    {
        RotateGunWithCamera();
    }

    void RotateGunWithCamera()
    {
        // �÷��̾��� ī�޶��� ȸ�� ���� �����ͼ� �� ���� ȸ����Ŵ
        Quaternion cameraRotation = playerCamera.transform.rotation;
        transform.rotation = cameraRotation;
    }
}

