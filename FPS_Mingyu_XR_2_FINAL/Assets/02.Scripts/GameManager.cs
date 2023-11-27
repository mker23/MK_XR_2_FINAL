using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ������Ʈ���� ȣ��Ǵ� �޼���
    void Update()
    {
        // ���� SLASHMAKER �±׸� ���� ������Ʈ�� ���ٸ�
        if (GameObject.FindGameObjectWithTag("SLASHMAKER") == null)
        {
            // 0.6�� �Ŀ� Victory ������ �Ѿ��
            Invoke("LoadVictoryScene", 0.6f);
        }
    }

    // Victory ������ ��ȯ�ϴ� �Լ�
    void LoadVictoryScene()
    {
        SceneManager.LoadScene("Victory");
    }
}


