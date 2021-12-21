using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Level1DestroyByContact : MonoBehaviour
{
    public GameObject enemyExplosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;
    private PlayerController bolt;
    
    

    
    
    
    
    void Start(){

        GameObject gameControllerObject=GameObject.FindWithTag("Level1GameController");
        gameController=gameControllerObject.GetComponent<GameController>();
      

       

    }
    void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Boundary")) return;
        Instantiate(enemyExplosion, transform.position, transform.rotation);
        
        if (other.CompareTag("Player"))
        {   
            gameController.GameOver();
            
            
            
        }  
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
        PlayerPrefs.SetFloat("score1", gameController.GetScore());

        if (gameController.GetScore()==200)
        {
            Time.timeScale = 0.1f;
            gameController.Winner();
        }
        
    
    }
    public void Update()
    {
       

    }
}