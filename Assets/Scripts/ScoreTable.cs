using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTable : MonoBehaviour
{
    public GameObject ScoreTableUI;

    public void ShowScoreTable()
    {
        ScoreTableUI.SetActive(true);
        //Time.timeScale = 0f;
    }

    public void GoBack()
    {
        ScoreTableUI.SetActive(false);
        //Time.timeScale = 0f;
    }
}
