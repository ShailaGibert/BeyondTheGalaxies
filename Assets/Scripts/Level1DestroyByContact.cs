using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level1DestroyByContact : MonoBehaviour
{
    public GameObject enemyExplosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;
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
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject); 
        if (gameController.GetScore()==10)
        {

            gameController.Winner();

        }

    }
   
    
        
    

    



}