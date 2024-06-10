using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class failmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void OnClickrestart(){
        Debug.Log("재시작");
        SceneManager.LoadScene("Scenes/game");

    }

    public void OnClickend()
    {
        SceneManager.LoadScene("Scenes/end");
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
