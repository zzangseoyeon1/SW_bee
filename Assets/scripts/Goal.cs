using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public static bool goal;
    public float jumpForce = 3f; // 점프 힘
    public float stopDelay = 3f; // 점프 후 멈출 때까지의 지연 시간

    // Start is called before the first frame update
    void Start()
    {
        goal = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && !goal) // goal이 false일 때만 실행
        {
            goal = true;
            Debug.Log("Goal reached! Player will turn and jump.");

            // 플레이어가 목표 지점에 닿았을 때 뒤돌고 점프하게 설정
            Transform playerTransform = col.transform;
            Rigidbody playerRigidbody = col.GetComponent<Rigidbody>();
            PlayerController playerController = col.GetComponent<PlayerController>(); // 플레이어 이동 스크립트 예시

            if (playerTransform != null && playerRigidbody != null)
            {
                // 플레이어 뒤돌기
                playerTransform.Rotate(0, 180, 0);

                // 플레이어 점프
                playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                // 플레이어 이동 스크립트 비활성화
                if (playerController != null)
                {
                    playerController.enabled = false;
                }

                // 점프 후 scene 로드
                StartCoroutine(LoadNextScene());
            }
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(stopDelay); // 점프 후 일정 시간 대기

        SceneManager.LoadScene("Scenes/Success");
    }
}