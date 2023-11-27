using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryButton : MonoBehaviour
{
    void Start()
    {
        // "PLAY" ��ư�� Ŭ�� �̺�Ʈ�� �߰�
        Button playButton = GetComponent<Button>();
        playButton.onClick.AddListener(LoadPlayScene);
    }

    // "PLAY" ��ư�� Ŭ������ �� ȣ��Ǵ� �Լ�
    void LoadPlayScene()
    {
        // Play ������ ��ȯ
        SceneManager.LoadScene("Main");
    }
}
