using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class startmenu : MonoBehaviour
{
    public void OnClickstart(){
        Debug.Log("게임 시작");
        SceneManager.LoadScene("Scenes/game");

    }

    public void OnClickexplain(){
        Debug.Log("게임 설명");
        SceneManager.LoadScene("Scenes/explain");

    }

    public void OnClickend()
    {
        SceneManager.LoadScene("Scenes/end");
    }
}