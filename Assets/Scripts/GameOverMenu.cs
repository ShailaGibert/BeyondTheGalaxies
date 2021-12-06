using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    //public static bool gameOver = false;
    public GameObject gameOverMenuUI;

    // Update is called once per frame
    void Update()
    {

    }

    public void TryAgain()
    {
        //Time.timeScale = 1f;
        //SceneManager.LoadScene("Level3");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

}
