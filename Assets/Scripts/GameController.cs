using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float WaveWait;
    private int score;
    public Text scoreText;
    public Text restartText;
    private bool restart;
    public Text gameOverText;
    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {   

        restart=false;
        restartText.gameObject.SetActive(false);
        gameOver=false;
        gameOverText.gameObject.SetActive(false);

        score=0;
        UpdateScore();

        StartCoroutine(SpawnWaves());
    }
    void Update(){
        
        if(restart && Input.GetKeyDown(KeyCode.R)){

            SceneManager.LoadScene(1);
        }
    }

    IEnumerator SpawnWaves()
    {   
        yield return new WaitForSeconds(startWait);
        while(true)
        {
            for(int i=0; i<hazardCount; i++)
            {   
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x,spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(WaveWait);
            if(gameOver){

                restartText.gameObject.SetActive(true);
                restart=true;
                break;

            }
        
        }
            
    }
    public void AddScore(int value){

        score+=value;
        UpdateScore();

    }
    void UpdateScore(){

        scoreText.text="Score: " +score;
    }
    public void GameOver(){

        gameOverText.gameObject.SetActive(true);
        gameOver=true;
    }
}
