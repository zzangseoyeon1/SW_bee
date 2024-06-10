using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyControl : MonoBehaviour {
    Renderer rend;
    Color originalColor;
    Color transparentColor = new Color(1f, 1f, 1f, 0f); // 투명한 색상 정의
    bool isPlayerInside = false;

    void Start() {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color; // 원래의 색상 저장
    }

    void Update() {
        if (isPlayerInside) {
            // 플레이어가 객체 안에 있을 때, 투명한 색상으로 변경
            rend.material.color = transparentColor;
        } else {
            // 플레이어가 객체 밖에 있을 때, 원래 색상으로 변경
            rend.material.color = originalColor;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            isPlayerInside = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            isPlayerInside = false;
        }
    }
}