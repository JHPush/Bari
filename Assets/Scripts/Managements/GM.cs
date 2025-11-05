using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : Singleton<GM>
{
    private DateTime _sessionStartTime;
    private DateTime _sessionEndTime;

    void Start()
    {
        // TODO - 세이브 / 로드
        // 세이브 없으면 플레이어 등록 씬으로 리다이렉션
        // 백엔드 호출 후 일일 첼린지, 보상 획득

        _sessionStartTime = DateTime.Now;
        Debug.Log("Game Session Start @: " + DateTime.Now);
    }

    void OnApplicationQuit()
    {
        _sessionEndTime = DateTime.Now;

        TimeSpan timeDifference = _sessionEndTime.Subtract(_sessionStartTime);

        Debug.Log("Game Session Ended @: " + DateTime.Now);
        Debug.Log("Game Session lasted : " + timeDifference);
    }
    void OnGUI()
    {
        if(GUILayout.Button("Next Scene"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}