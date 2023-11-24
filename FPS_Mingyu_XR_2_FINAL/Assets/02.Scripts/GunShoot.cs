using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public Transform gunTip;  // 총구 위치
    public GameObject bulletPrefab;  // 총알 프리팹
    public float bulletSpeed = 10f;  // 총알 속도
    public float bulletLifetime = 2f;  // 총알 수명
    public AudioClip gunshotSound;  // 총성음

    private AudioSource audioSource;  // AudioSource 컴포넌트

    void Start()
    {
        // AudioSource 컴포넌트 가져오기 또는 추가하기
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if ((Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0)) && !Input.GetKey(KeyCode.LeftControl))
        {
            Shoot();
        }
    }


    void Shoot()
    {
        // 총성음 재생
        audioSource.PlayOneShot(gunshotSound);

        // 총구 위치에서 발사될 총알 생성
        GameObject bullet = Instantiate(bulletPrefab, gunTip.position, gunTip.rotation);

        // 총알에 Rigidbody 컴포넌트가 없으면 추가
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb == null)
        {
            bulletRb = bullet.AddComponent<Rigidbody>();
            bulletRb.useGravity = false; // 중력 비활성화
        }

        // 총알에 Collider 컴포넌트가 없으면 추가
        Collider bulletCollider = bullet.GetComponent<Collider>();
        if (bulletCollider == null)
        {
            bulletCollider = bullet.AddComponent<BoxCollider>(); // 적절한 Collider 타입을 사용하세요.
        }

        // 총알에 속도를 적용하여 발사
        bulletRb.velocity = gunTip.forward * bulletSpeed;

        // 일정 시간 후에 총알을 파괴
        Destroy(bullet, bulletLifetime);
    }
}


