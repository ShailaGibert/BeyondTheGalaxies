using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuminarisController : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public GameObject enemyExplosion;
    public GameObject playerExplosion;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            //Play death animation

            // Show GameOver screen

        }
    }

    /*void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary")) return;

        Instantiate(enemyExplosion, transform.position, transform.rotation);

        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }

        if (other.CompareTag("Bolt"))
        {
            // Prueba para quitar puntos de vida
            var healthComponent = other.GetComponent<LuminarisHealth>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(1);
            }

            // Si la vida llega a cero
            if(healthComponent.currentHealth == 0)
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            }

        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
