using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryButton : MonoBehaviour
{
    void Start()
    {
        // "PLAY" 버튼에 클릭 이벤트를 추가
        Button playButton = GetComponent<Button>();
        playButton.onClick.AddListener(LoadPlayScene);
    }

    // "PLAY" 버튼을 클릭했을 때 호출되는 함수
    void LoadPlayScene()
    {
        // Play 씬으로 전환
        SceneManager.LoadScene("Main");
    }
}
