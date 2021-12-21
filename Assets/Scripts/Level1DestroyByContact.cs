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
    private SaludJugador saludJugador;
    
    void Start(){
        //saludJugador = GetComponent<SaludJugador>();
        GameObject player = GameObject.FindWithTag("Player");
        Debug.Log(player);
        saludJugador = player.GetComponentInChildren<SaludJugador>();
        Debug.Log(saludJugador);
        GameObject gameControllerObject=GameObject.FindWithTag("Level1GameController");
        gameController=gameControllerObject.GetComponent<GameController>();
    }
    void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy")) return;
        if (enemyExplosion != null)
        {
            Instantiate(enemyExplosion, transform.position, transform.rotation);
        }

        if (other.CompareTag("Bolt"))
        {
            Instantiate(enemyExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

            if (other.CompareTag("Player"))
        {
            Debug.Log(saludJugador.currentHealth);
            //gameController.GameOver();
            //saludJugador = GetComponent<SaludJugador>();
            if (saludJugador.currentHealth != 0.0)
            {
                //saludJugador.TakeDamage(10);
                saludJugador.currentHealth -= 10;
                Debug.Log(saludJugador.currentHealth);
                saludJugador.UpdatePlayerHealth(saludJugador.currentHealth);
                Destroy(gameObject);


            }
            
            //Si la vida llega a cero
            if (saludJugador.currentHealth==0.0)
            {
                
                Destroy(gameObject); //Se destruye el asteroide
                Destroy(other.gameObject); //Se destruye la nave del jugador
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();
                //gameController.Winner();
                //Time.timeScale = 0f;

            }

        }
             
        gameController.AddScore(scoreValue);
        //Destroy(other.gameObject);
        //Destroy(gameObject);
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