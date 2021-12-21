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
    public SaludJugador saludJugador;
    
    void Start(){

        GameObject gameControllerObject=GameObject.FindWithTag("Level1GameController");
        gameController=gameControllerObject.GetComponent<GameController>();
    }
    void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Boundary")) return;
        if (enemyExplosion != null)
        {
            Instantiate(enemyExplosion, transform.position, transform.rotation);
        }
        //Instantiate(enemyExplosion, transform.position, transform.rotation);
        
        if (other.CompareTag("Player"))
        {   
            //gameController.GameOver();
            saludJugador = GetComponent<SaludJugador>();
            if (saludJugador != null)
            {
                saludJugador.TakeDamage(10);
                Debug.Log(saludJugador.currentHealth);
                Destroy(gameObject);


            }
            Debug.Log(saludJugador.currentHealth);

            //Si la vida llega a cero
            /*if (saludJugador.currentHealth==0.0)
            {
                
                //Destroy(gameObject); //Se destruye la nave enemiga
                gameController.GameOver();
                //gameController.Winner();
                //Time.timeScale = 0f;

            }*/

        }
             
        gameController.AddScore(scoreValue);
        //Destroy(other.gameObject);
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