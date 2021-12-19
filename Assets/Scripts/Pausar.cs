using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausar : MonoBehaviour
{
   public static bool GameisPaused = false;

    public GameObject pauseMenuUI;
    private GameObject winnerMenuUi; 
    private GameController gameController;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
            if(winnerMenuUi)
            {   
                
                NextLevel();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void LoadMenu()
    {   
        
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
    public void NextLevel(){

        Time.timeScale = 2f;
        SceneManager.LoadScene(2);
    }
    
}
