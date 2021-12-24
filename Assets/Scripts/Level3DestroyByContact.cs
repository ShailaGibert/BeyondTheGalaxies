using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3DestroyByContact : MonoBehaviour
{
    public GameObject enemyExplosion;
    public GameObject playerExplosion;
    private SaludJugador saludJugador;

    public int scoreValue;
    private Level3GameController level3GameController;
    public LuminarisHealth enemyHealth;


    void Start()
    {
        level3GameController = GameObject.FindWithTag("Level3GameController").GetComponent<Level3GameController>();
        GameObject player = GameObject.FindWithTag("Player");
        //Debug.Log(player);
        saludJugador = player.GetComponentInChildren<SaludJugador>();
        //Debug.Log(saludJugador);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") /*|| other.CompareTag("Enemy")*/) return;

        if (enemyExplosion != null)
        {
            Instantiate(enemyExplosion, transform.position, transform.rotation);
        }

        if (other.CompareTag("Player"))
        {
            //Debug.Log(saludJugador.currentHealth);
            //gameController.GameOver();
            if (saludJugador.currentHealth != 0.0)
            {
                //saludJugador.TakeDamage(10);
                saludJugador.currentHealth -= 10;
                //Debug.Log(saludJugador.currentHealth);
                saludJugador.UpdatePlayerHealth(saludJugador.currentHealth);
                //Destroy(gameObject);


            }

            //Si la vida llega a cero
            if (saludJugador.currentHealth == 0.0)
            {

                Destroy(gameObject); //Se destruye el enemigo
                Destroy(other.gameObject); //Se destruye la nave del jugador
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                level3GameController.GameOver();
                //Time.timeScale = 0f;

            }
        }

        //Si le alcanza un disparo del jugador
        if(other.CompareTag("Bolt"))
        {
            level3GameController.AddScore(scoreValue);
            Destroy(other.gameObject); //Se destruye el disparo (Bolt)

            //La vida va bajando
            enemyHealth = GetComponent<LuminarisHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(1);

            }
            //Si la vida llega a cero
            if (enemyHealth.currentHealth == 0.0)
            {
                
                Destroy(gameObject); //Se destruye la nave enemiga
                level3GameController.Winner();
                //Time.timeScale = 0f;

            }

        }

        //GameState.gameState.score = level3GameController.GetScore();
        //GameState.gameState.SaveData();
        PlayerPrefs.SetFloat("score3", level3GameController.GetScore());
    }
}
