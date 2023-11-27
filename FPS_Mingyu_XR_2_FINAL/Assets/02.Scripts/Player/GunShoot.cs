using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public Transform gunTip;  // �ѱ� ��ġ
    public GameObject bulletPrefab;  // �Ѿ� ������
    public float bulletSpeed = 10f;  // �Ѿ� �ӵ�
    public float bulletLifetime = 2f;  // �Ѿ� ����
    public AudioClip gunshotSound;  // �Ѽ���

    private AudioSource audioSource;  // AudioSource ������Ʈ

    void Start()
    {
        // AudioSource ������Ʈ �������� �Ǵ� �߰��ϱ�
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
        // �Ѽ��� ���
        audioSource.PlayOneShot(gunshotSound);

        // �ѱ� ��ġ���� �߻�� �Ѿ� ����
        GameObject bullet = Instantiate(bulletPrefab, gunTip.position, gunTip.rotation);

        // �Ѿ˿� Rigidbody ������Ʈ�� ������ �߰�
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb == null)
        {
            bulletRb = bullet.AddComponent<Rigidbody>();
            bulletRb.useGravity = false; // �߷� ��Ȱ��ȭ
        }

        // �Ѿ˿� Collider ������Ʈ�� ������ �߰�
        Collider bulletCollider = bullet.GetComponent<Collider>();
        if (bulletCollider == null)
        {
            bulletCollider = bullet.AddComponent<BoxCollider>(); // ������ Collider Ÿ���� ����ϼ���.
        }

        // �Ѿ˿� �ӵ��� �����Ͽ� �߻�
        bulletRb.velocity = gunTip.forward * bulletSpeed;

        // ���� �ð� �Ŀ� �Ѿ��� �ı�
        Destroy(bullet, bulletLifetime);
    }
}


