using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2DestroyByContact : MonoBehaviour
{
    public GameObject enemyExplosion;
    public GameObject playerExplosion;

    public int scoreValue;
    private Level2GameController level2GameController;


    void Start()
    {
        level2GameController = GameObject.FindWithTag("Level2GameController").GetComponent<Level2GameController>();
        
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
            level2GameController.GameOver();
        }

       /* //PRUEBA: Si le alcanza un disparo del jugador
        if(other.CompareTag("Bolt"))
        {
            //La vida va bajando
            var healthComponent = GetComponent<LuminarisHealth>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(1);
               
            }
            //Si la vida llega a cero
            if (healthComponent.currentHealth == 0)
            {
                level2GameController.Winner();
                Destroy(gameObject);
            }
        }*/

        if (other.CompareTag("Player"))
        {
            if (scoreValue <= 50) {

                level2GameController.Winner();
                Destroy(gameObject);

            }

        }

        level2GameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        
    }
}
