using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour
{
    public float speed = 10.0f; 
    public float speedIncrement = 1.5f;
    public float stopFollowZPosition = 470.0f; // 벌이 이 z 위치에 도달하면 플레이어를 따라가는 것을 멈춤
    public Transform playerTransform; // Player의 Transform 참조
    private Rigidbody rb;              // Rigidbody 참조

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody 컴포넌트 참조

        // PlayerController를 찾아 playerTransform에 할당
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerTransform = playerController.transform;
        }
        else
        {
            Debug.LogError("PlayerController를 찾을 수 없습니다!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 벌의 z 위치를 먼저 체크합니다.
        if (transform.position.z >= stopFollowZPosition)
        {
            // 벌이 지정된 z 위치에 도달하면 이동을 멈춥니다.
            Debug.Log("벌 멈춤");
            return;
        }

        // z 위치 체크 후 이동 동작 수행
        Vector3 forwardMovement = Vector3.forward * speed * Time.deltaTime;
        rb.MovePosition(rb.position + forwardMovement);

        // Player를 따라가는 동작
        if (playerTransform != null)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
        }
        
        // 속도 증가
        speed += speedIncrement * Time.deltaTime;
    }
}
