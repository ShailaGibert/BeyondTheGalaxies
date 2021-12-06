using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void onMouseDown()
    {
        //Application.LoadLevel("Level3");
        SceneManager.LoadScene("Level3");
    }
}
