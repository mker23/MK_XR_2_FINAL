using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    public float crouchHeight = 0.5f; // 웅크렸을 때 플레이어 높이
    public float crouchColliderHeight = 0.5f; // 웅크렸을 때 콜라이더 높이
    public float crouchCameraHeight = 0.5f; // 웅크렸을 때 카메라 높이
    public LayerMask groundLayer; // 땅의 레이어

    private bool isCrouching;

    void Update()
    {
        // Ctrl 키를 눌렀을 때 웅크리기 처리
        if (Input.GetKey(KeyCode.LeftControl) && CanCrouch())
        {
            Crouch();
        }
        else
        {
            StandUp();
        }
    }

    void Crouch()
    {
        if (!isCrouching)
        {
            isCrouching = true;
            transform.localScale = new Vector3(1f, crouchHeight, 1f);
            GetComponent<CapsuleCollider>().height = crouchColliderHeight;

            // 조정된 클리핑 평면
            Camera.main.nearClipPlane = 0.01f;

            Camera.main.transform.localPosition = new Vector3(0f, -crouchCameraHeight, 0f);
        }
    }

    void StandUp()
    {
        if (isCrouching)
        {
            isCrouching = false;
            transform.localScale = new Vector3(1f, 1f, 1f);
            GetComponent<CapsuleCollider>().height = 2f; // 기본 플레이어 높이

            // 기본 클리핑 평면 값
            Camera.main.nearClipPlane = 0.3f;

            Camera.main.transform.localPosition = Vector3.zero; // 기본 카메라 높이
        }
    }

    bool CanCrouch()
    {
        RaycastHit hit;
        float rayDistance = 2f; // 플레이어에서 땅까지의 최대 거리

        // 플레이어 위치에서 아래 방향으로 레이를 쏴서 땅이 있는지 체크
        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayDistance, groundLayer))
        {
            float distanceToGround = hit.distance;

            // 웅크린 상태에서 땅과의 거리가 웅크렸을 때 높이보다 작거나 같으면 웅크릴 수 있음
            return distanceToGround <= crouchHeight;
        }

        // 레이가 아무것도 맞지 않으면 웅크릴 수 있음
        return true;
    }
}




