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
    public GameObject restartGameObject;
    private bool restart;
    public GameObject gameOverGameObject;
    private bool gameOver;
    public GameObject winnerMenuUI;
    public Text winnerText;
    private bool winner;
   
    // Start is called before the first frame update
    void Start()
    {   

        UpdateSpawnValue();
        restart=false;
        restartGameObject.SetActive(false);
        gameOver=false;
        gameOverGameObject.SetActive(false);
        score=0;
       
        
        UpdateScore();
        StartCoroutine(SpawnWaves());
        
        winner = false;
        //winnerText.gameObject.SetActive(false);
        //esto
        winnerMenuUI.SetActive(false);
        


    }
    void  UpdateSpawnValue(){
        Vector2 half = Utils.GetDimensionsInWorldUnits() /2;
        spawnValues=new Vector3(half.x-0.5f,0f,half.y+14f);
        Debug.Log(half);
    }
    void Update(){
        
        if(restart && Input.GetKeyDown(KeyCode.R)){

            Restart();

        }

        if (winner)
        {

            Winner();
            score = (int)PlayerPrefs.GetFloat("score1");

        }

        if (gameOver)
        {
            score = 0;
            GameOver();


        }
    }
    public void Restart(){

        SceneManager.LoadScene(1);
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

                restartGameObject.SetActive(true);
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

        Time.timeScale = 0f;

        gameOverGameObject.SetActive(true);
        gameOver=true;
    }public int GetScore(){

        return score;
    }

    public void Winner()
    {
        Time.timeScale = 0f;

        winnerMenuUI.SetActive(true);
        //Time.timeScale = 0f;

        winnerText.gameObject.SetActive(true);
        winner = true;

        //restartText.gameObject.SetActive(true);
        //���?????restart = true;
    }
    public void SiguienteNivel(){

        
        SceneManager.LoadScene(2);
    }

   
        //score = GetScore();

        


    
}
    
    

    

