using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 업데이트마다 호출되는 메서드
    void Update()
    {
        // 만약 SLASHMAKER 태그를 가진 오브젝트가 없다면
        if (GameObject.FindGameObjectWithTag("SLASHMAKER") == null)
        {
            // 0.6초 후에 Victory 씬으로 넘어가기
            Invoke("LoadVictoryScene", 0.6f);
        }
    }

    // Victory 씬으로 전환하는 함수
    void LoadVictoryScene()
    {
        SceneManager.LoadScene("Victory");
    }
}


