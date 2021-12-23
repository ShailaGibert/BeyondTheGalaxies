using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact2 : MonoBehaviour
{
    public GameObject enemyExplosion;
    public GameObject playerExplosion;
    public GameObject playerSmallExplosion;
    private SaludJugador saludJugador;

    public int scoreValue;

    private Level2GameController level2GameController;
    private GameController level1GameController;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        //Debug.Log(player);
        saludJugador = player.GetComponentInChildren<SaludJugador>();
        //Debug.Log(saludJugador);
        level2GameController = GameObject.FindWithTag("Level2GameController").GetComponent<Level2GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy")) return;

        if(enemyExplosion != null)
        {
            Instantiate(enemyExplosion, transform.position, transform.rotation);
        }
        
        if (other.CompareTag("Player"))
        {
            //Debug.Log(saludJugador.currentHealth);
            //gameController.GameOver();
            //saludJugador = GetComponent<SaludJugador>();
            if (saludJugador.currentHealth != 0.0)
            {
                //saludJugador.TakeDamage(10);
                saludJugador.currentHealth -= 10;
                Instantiate(playerSmallExplosion, other.transform.position, other.transform.rotation);
                //Debug.Log(saludJugador.currentHealth);
                saludJugador.UpdatePlayerHealth(saludJugador.currentHealth);
                Destroy(gameObject);


            }

            //Si la vida llega a cero
            if (saludJugador.currentHealth == 0.0)
            {

                Destroy(gameObject); //Se destruye el asteroide
                Destroy(other.gameObject); //Se destruye la nave del jugador
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                level2GameController.GameOver();
                //gameController.Winner();
                //Time.timeScale = 0f;

            }
            //Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            //level2GameController.GameOver();
        }

        if (other.CompareTag("Bolt"))
        {
            level2GameController.AddScore(scoreValue);
            Destroy(gameObject);
            Destroy(other.gameObject); //Se destruye el disparo (Bolt)
        }

        //level2GameController.AddScore(scoreValue);
        //Destroy(other.gameObject);
        //Destroy(gameObject);

        //GameState.gameState.score = level2GameController.GetScore();
        //GameState.gameState.SaveData();
        
        PlayerPrefs.SetFloat("score2", level2GameController.GetScore());
        
        
        //Debug.Log(level2GameController.GetScore());
        
        if (level2GameController.GetScore() >= 400)
        {
            level2GameController.Winner();
        }

        
    }
}
