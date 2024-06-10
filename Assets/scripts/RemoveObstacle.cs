using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveObstacle : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform
    public float[] obstaclePositions = { -15, 0, 15, 30, 45, 60, 75, 90, 105, 120, 135, 150, 175, 200, 215, 230, 245, 260, 275, 290, 305, 320, 335, 350, 365, 380, 400, 420, 440, 460, 480 };
    private HashSet<float> removedPositions = new HashSet<float>();
    private float removalThreshold = 10.0f; // 허용 오차

    private void Start()
    {
        // 플레이어 오브젝트를 찾아서 할당
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player object not found");
        }
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        List<float> positionsToRemove = new List<float>();
        foreach (float zValue in obstaclePositions)
        {
            if (player.position.z >= zValue && !removedPositions.Contains(zValue))
            {
                positionsToRemove.Add(zValue); // Here, use 'Add' instead of 'add'
                Debug.Log("Player passed obstacle position: " + zValue);
            }
        }

        foreach (float zValue in positionsToRemove)
        {
            RemoveObstacleAtPosition(zValue);
            removedPositions.Add(zValue);
        }
    }

    void RemoveObstacleAtPosition(float zPosition)
    {
        // 특정 Z 위치에 있는 모든 장애물을 찾아서 제거
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obstacle in obstacles)
        {
            float distance = Mathf.Abs(obstacle.transform.position.z - zPosition);
            if (distance < removalThreshold)
            {
                Debug.Log("Removing obstacle at position: " + obstacle.transform.position.z + ", distance: " + distance);
                Destroy(obstacle);
            }
        }
    }
}
