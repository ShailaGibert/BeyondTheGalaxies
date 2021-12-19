using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2GameController : MonoBehaviour
{
    public GameObject hazard;
    public GameObject enemyShift;
    public Vector3 spawnValues;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int hazardCount;
    public int enemyShiftCount;

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


    void Start()
    {
        Time.timeScale = 1f;
        restart = false;
        //restartText.gameObject.SetActive(false);
        gameOver = false;
        gameOverText.gameObject.SetActive(false);
        winner = false;
        winnerText.gameObject.SetActive(false);
        //score=0;
        score = (int)PlayerPrefs.GetFloat("score1", 0);
        StartCoroutine(SpawnHazard());
        StartCoroutine(SpawnShift());
        UpdateScore();
    }


    void Update() {

        if (winner) {

            Winner();
            score = (int)PlayerPrefs.GetFloat("score2");
            
        }

        if (gameOver) 
        {
            GameOver();

            score = (int)PlayerPrefs.GetFloat("score1");

        }
    
    
    }
    // Update is called once per frame
    IEnumerator SpawnHazard()
    {
        yield return new WaitForSeconds(startWait);

        while (true) { 

            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(hazard, spawPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                GameOver();
                gameOverText.gameObject.SetActive(true);
                restart = true;
               
                break;
            }
            
           
        }
    }
    IEnumerator SpawnShift() {
        
        yield return new WaitForSeconds(startWait);

        while (true)
        {

            for (int i = 0; i < enemyShiftCount; i++)
            {
                Vector3 spawPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(enemyShift, spawPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                GameOver();
                gameOverText.gameObject.SetActive(true);
                restart = true;
                break;
            }
        }
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

        gameOverText.gameObject.SetActive(true);
        gameOver = true;
        
        Debug.Log("He perdido nivel2: "+score);

        //restartText.gameObject.SetActive(true);
        restart = true;
    }

    public void Winner()
    {
        winnerMenuUI.SetActive(true);
        Time.timeScale = 0f;

        winnerText.gameObject.SetActive(true);
        winner = true;
     
        Debug.Log("He ganado nivel2: "+score);

        //PlayerPrefs.SetFloat("score2", GetScore());

        //restartText.gameObject.SetActive(true);
        //���?????restart = true;
    }

    public int GetScore()
    {
        return score;
    }

    public bool GetGameOver()
    {   
        return gameOver;
    }
}
