using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    void Start()
    {
        // "EXIT" ��ư�� Ŭ�� �̺�Ʈ�� �߰�
        Button exitButton = GetComponent<Button>();
        exitButton.onClick.AddListener(ExitApplication);
    }

    // "EXIT" ��ư�� Ŭ������ �� ȣ��Ǵ� �Լ�
    void ExitApplication()
    {
        // �����Ϳ��� ���� ���̸� Application.Quit()�� �������� ���� �� �ֽ��ϴ�.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
