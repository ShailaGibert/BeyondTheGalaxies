using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;

    private int score;
    public Text scoreText;

    //public Text restartText;
    private bool restart;
    public GameObject gameOverMenuUI;
    public GameObject gameOverGameObject;
    private bool gameOver;
    public GameObject winnerMenuUI;
    public Text winnerText;
    private bool winner;

   
    void Start()
    {
        score = (int)PlayerPrefs.GetFloat("score2", 0);

        Time.timeScale = 1f;
        UpdateSpawnValues();
        restart = false;
        UpdateScore();
        //restartText.gameObject.SetActive(false);
        gameOver = false;
        gameOverGameObject.SetActive(false);
        winner = false;
        winnerText.gameObject.SetActive(false);
        //score = 0;
        //score = (int)PlayerPrefs.GetFloat("score2", 0);
        //score = GameState.gameState.score;
        
       // UpdateScore();
        SpawnShip();
        
       
    }
   
    void UpdateSpawnValues()
    {
        Vector2 half = Utils.GetDimensionsInWorldUnits() / 2;

        spawnValues = new Vector3(half.x - 1.5f, 0f, half.y + 7f);
        //Debug.Log(half);
    }

    // Update is called once per frame
    void SpawnShip()
    {
        Vector3 spawPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Instantiate(hazard, spawPosition, Quaternion.identity);
    }

    void UpdateScore()
    {   
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int value)
    {   
        score += value;
        UpdateScore();
       
    }
    

    public void GameOver()
    {
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;

        gameOverGameObject.SetActive(true);
        gameOver = true;

        //restartText.gameObject.SetActive(true);
        restart = true;
        Debug.Log("He perdido nivel3: "+score);
        
    }

    public void Winner()
    {
        winnerMenuUI.SetActive(true);
        Time.timeScale = 0f;

        winnerText.gameObject.SetActive(true);
        winner = true;
        
        Debug.Log("He gando nivel3: "+score);

        PlayerPrefs.SetFloat("score3", GetScore());

        //restartText.gameObject.SetActive(true);
        //���?????restart = true;
    }

    public int GetScore()
    {
        return score;
    }

    void Update()
    {
        //score = GetScore();

        if (winner)
        {

            Winner();
            score = (int)PlayerPrefs.GetFloat("score3");
            
        }

        if (gameOver)
        {
            score = (int)PlayerPrefs.GetFloat("score2");
            GameOver();
            

        }


    }
}
