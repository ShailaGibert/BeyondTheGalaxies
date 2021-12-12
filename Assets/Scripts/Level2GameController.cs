using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2GameController : MonoBehaviour
{
    public GameObject hazard;
    public GameObject enemyShift;
    public Vector3 spawnValues;

    private int score;
    public Text scoreText;

    //public Text restartText;
    private bool restart;
    public GameObject gameOverMenuUI;
    public Text gameOverText;
    private bool gameOver;
    public GameObject winnerMenuUI;
    public Text winnerText;
    private bool winner;

    // Start is called before the first frame update
    void Start()
    {
        restart = false;
        //restartText.gameObject.SetActive(false);
        gameOver = false;
        gameOverText.gameObject.SetActive(false);
        winner = false;
        winnerText.gameObject.SetActive(false);
        score = 0;
        UpdateScore();
        SpawnShip();
    }

    // Update is called once per frame
    void SpawnShip()
    {
        Vector3 spawPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Instantiate(hazard, spawPosition, Quaternion.identity);
        Instantiate(enemyShift, spawPosition, Quaternion.identity);
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
        //Time.timeScale = 0f;

        gameOverText.gameObject.SetActive(true);
        gameOver = true;

        //restartText.gameObject.SetActive(true);
        restart = true;
    }

    public void Winner()
    {
        winnerMenuUI.SetActive(true);
        //Time.timeScale = 0f;

        winnerText.gameObject.SetActive(true);
        winner = true;

        //restartText.gameObject.SetActive(true);
        //���?????restart = true;
    }
}