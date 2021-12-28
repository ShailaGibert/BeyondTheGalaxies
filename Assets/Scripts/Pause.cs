using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject PauseScreen;

    // Update is called once per frame
    void Update()
    {
        if (GameIsPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        
    }

    public void PauseGame()
    {
        GameIsPaused = true;
        PauseScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        GameIsPaused = false;
        PauseScreen.SetActive(false);

    }
}
