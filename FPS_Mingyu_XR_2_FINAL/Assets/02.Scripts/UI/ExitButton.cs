using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    void Start()
    {
        // "EXIT" 버튼에 클릭 이벤트를 추가
        Button exitButton = GetComponent<Button>();
        exitButton.onClick.AddListener(ExitApplication);
    }

    // "EXIT" 버튼을 클릭했을 때 호출되는 함수
    void ExitApplication()
    {
        // 에디터에서 실행 중이면 Application.Quit()은 동작하지 않을 수 있습니다.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
