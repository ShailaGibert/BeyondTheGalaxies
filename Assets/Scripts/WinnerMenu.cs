using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerMenu : MonoBehaviour
{
    //public static bool winner = false;
    public GameObject winnerMenuUI;
    public GameObject creditsMenuUI;

    public void NextLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        //Time.timeScale = 1f;
    }

    public void LoadMenu()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowCredits()
    {
        creditsMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GoBack()
    {
        creditsMenuUI.SetActive(false);
        Time.timeScale = 0f;
    }

}
