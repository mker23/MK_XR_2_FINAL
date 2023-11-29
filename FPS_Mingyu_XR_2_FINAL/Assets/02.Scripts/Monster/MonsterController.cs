using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public string playerTag = "PLAYER"; // 플레이어의 태그
    public float moveSpeed = 5f; // 몬스터의 이동 속도
    private Transform player; // 플레이어의 Transform을 할당

    void Update()
    {
        // 플레이어를 태그를 이용하여 찾음
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);

        if (playerObject != null)
        {
            // 플레이어가 있다면 플레이어의 Transform을 할당
            player = playerObject.transform;

            // 플레이어 방향으로 회전
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToPlayer.x, 0f, directionToPlayer.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            // 플레이어를 향해 이동
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            // 플레이어가 없으면 아무 동작도 하지 않습니다.
            // 원하는 동작을 추가하거나 필요에 따라 몬스터를 소멸시킬 수 있습니다.
        }
    }
}
