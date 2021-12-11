using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerMenu : MonoBehaviour
{
    //public static bool winner = false;
    public GameObject winnerMenuUI;

    public void NextLevel(string sceneName) //----- pantalla final será Scene o CanvasMenu?????
    {
        //Time.timeScale = 1f;
        //SceneManager.LoadScene("Level3");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(sceneName);
    }

    public void LoadMenu()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
