using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveDistance = 1.7f;  // 한 번에 이동할 거리
    public float speed = 6.6f;         // 이동 속도
    public float speedIncrement = 1.5f; // 초당 증가할 속도
    private Vector3 targetPosition;    // 목표 위치
    private Rigidbody rb;              // Rigidbody 참조

    // Bee 참조
    public GameObject bee;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        rb = GetComponent<Rigidbody>(); // Rigidbody 컴포넌트 참조
    }

    // Update is called once per frame
    void Update()
    {
        // 전진 이동
        Vector3 forwardMovement = Vector3.forward * speed * Time.deltaTime;
        rb.MovePosition(rb.position + forwardMovement);

        // 좌우 이동 입력 처리
        if (Input.GetKeyDown(KeyCode.A))
        {
            targetPosition = rb.position - new Vector3(moveDistance, 0.0f, 0.0f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            targetPosition = rb.position + new Vector3(moveDistance, 0.0f, 0.0f);
        }

        // 목표 위치로 좌우 이동
        Vector3 newPosition = Vector3.MoveTowards(rb.position, new Vector3(targetPosition.x, rb.position.y, rb.position.z), speed * Time.deltaTime);
        rb.MovePosition(new Vector3(newPosition.x, rb.position.y, rb.position.z));



        speed += speedIncrement * Time.deltaTime;
    }
}
