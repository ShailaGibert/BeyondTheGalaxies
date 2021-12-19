using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3DestroyByContact : MonoBehaviour
{
    public GameObject enemyExplosion;
    public GameObject playerExplosion;

    public int scoreValue;
    private Level3GameController level3GameController;
    public LuminarisHealth enemyHealth;


    void Start()
    {
        level3GameController = GameObject.FindWithTag("Level3GameController").GetComponent<Level3GameController>();
        
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
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            level3GameController.GameOver();
        }

        //PRUEBA: Si le alcanza un disparo del jugador
        if(other.CompareTag("Bolt"))
        {
            /*//La vida va bajando
            var healthComponent = GetComponent<LuminarisHealth>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(1);
               
            }
            //Si la vida llega a cero
            if (healthComponent.currentHealth == 0)
            {
                level3GameController.Winner();
                Destroy(gameObject);
            }*/

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

        level3GameController.AddScore(scoreValue);
        Destroy(other.gameObject); //Se destruye el jugador

        //GameState.gameState.score = level3GameController.GetScore();
        //GameState.gameState.SaveData();
        PlayerPrefs.SetFloat("score3", level3GameController.GetScore());
    }
}
