using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuminarisBoltDestroyByContact : MonoBehaviour
{
    private Level3GameController level3GameController;
    public GameObject playerExplosion;
    private SaludJugador saludJugador;

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
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy")) return;

        if (other.CompareTag("Player"))
        {
            //Debug.Log(saludJugador.currentHealth);
            if (saludJugador.currentHealth != 0.0)
            {
                //saludJugador.TakeDamage(10);
                saludJugador.currentHealth -= 10;
                //Debug.Log(saludJugador.currentHealth);
                saludJugador.UpdatePlayerHealth(saludJugador.currentHealth);
                Destroy(gameObject); //Se destruye el disparo enemigo
                //TODO: PLAY A SOUND WHEN THE PLAYER GETS HIT
            }

            //Si la vida llega a cero
            if (saludJugador.currentHealth == 0.0)
            {
                Destroy(gameObject); //Se destruye el disparo enemigo
                Destroy(other.gameObject); //Se destruye la nave del jugador
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                level3GameController.GameOver();
                //gameController.Winner();
                //Time.timeScale = 0f;

            }
        }

        //Si le alcanza un disparo del jugador
        if (other.CompareTag("Bolt"))
        {
            //level3GameController.AddScore(scoreValue);
            Destroy(other.gameObject); //Se destruye el disparo del jugador (Bolt)
            Destroy(gameObject); //Se destruye el disparo enemigo
        }

        //GameState.gameState.score = level3GameController.GetScore();
        //GameState.gameState.SaveData();
        PlayerPrefs.SetFloat("score3", level3GameController.GetScore());
    }
}
