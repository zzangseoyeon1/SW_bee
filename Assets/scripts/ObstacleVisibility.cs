using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ObstacleControl : MonoBehaviour
{
    private bool isPlayerInside = false;

    // 트리거에 진입할 때 호출됩니다.
    void OnTriggerEnter(Collider other)
    {
        // 충돌한 물체가 "Player" 태그를 가졌는지 확인합니다.
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true; // 플레이어가 트리거 안에 있다고 플래그를 설정합니다.
            Debug.Log(gameObject.name + ": Player entered");
            LoadFailScene();
        }
    }

    // 실패 씬을 로드하는 함수
    private void LoadFailScene()
    {
        try
        {
            SceneManager.LoadScene("Scenes/fail");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to load fail scene: " + e.Message);
        }
    }



    // 트리거를 빠져나갈 때 호출됩니다.
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false; // 플레이어가 트리거 안에 있지 않다고 플래그를 설정합니다.
            DeactivateNearbyObstacles(); // 주변 장애물을 비활성화합니다.
            Debug.Log(gameObject.name + ": Player exited, obstacles deactivated");
        }
    }

    // 트리거 안에 있는 동안 호출됩니다. (매 프레임마다 호출됩니다)
    void Update()
    {
        if (isPlayerInside)
        {
            // 플레이어가 트리거 안에 있으면 장애물을 활성화합니다.
            gameObject.SetActive(true);
            Debug.Log(gameObject.name + ": Player inside, obstacle active");
        }
    }

    // 주변의 장애물을 비활성화하는 함수입니다.
    private void DeactivateNearbyObstacles()
    {
        // 같은 Z 축에 있는 모든 장애물을 비활성화합니다.
        ObstacleControl[] obstacles = FindObjectsOfType<ObstacleControl>();

        foreach (ObstacleControl obstacle in obstacles)
        {
            if (Mathf.Approximately(obstacle.transform.position.z, transform.position.z))
            {
                obstacle.gameObject.SetActive(false);
                Debug.Log(obstacle.gameObject.name + ": Deactivated due to same Z-axis position");
            }
        }
    }
}
