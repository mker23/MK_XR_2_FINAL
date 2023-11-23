using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    public Camera playerCamera; // 플레이어의 카메라
    public GameObject gunModel;  // 총 모델

    void Update()
    {
        RotateGunWithCamera();
    }

    void RotateGunWithCamera()
    {
        // 플레이어의 카메라의 회전 값을 가져와서 총 모델을 회전시킴
        Quaternion cameraRotation = playerCamera.transform.rotation;
        transform.rotation = cameraRotation;
    }
}

