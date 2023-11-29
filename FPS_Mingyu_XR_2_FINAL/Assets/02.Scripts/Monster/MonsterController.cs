using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public string playerTag = "PLAYER"; // �÷��̾��� �±�
    public float moveSpeed = 5f; // ������ �̵� �ӵ�
    private Transform player; // �÷��̾��� Transform�� �Ҵ�

    void Update()
    {
        // �÷��̾ �±׸� �̿��Ͽ� ã��
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);

        if (playerObject != null)
        {
            // �÷��̾ �ִٸ� �÷��̾��� Transform�� �Ҵ�
            player = playerObject.transform;

            // �÷��̾� �������� ȸ��
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToPlayer.x, 0f, directionToPlayer.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            // �÷��̾ ���� �̵�
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            // �÷��̾ ������ �ƹ� ���۵� ���� �ʽ��ϴ�.
            // ���ϴ� ������ �߰��ϰų� �ʿ信 ���� ���͸� �Ҹ��ų �� �ֽ��ϴ�.
        }
    }
}
