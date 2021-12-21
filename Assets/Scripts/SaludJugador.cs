using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludJugador : MonoBehaviour
{
    public int maxHealth = 30;
    public int currentHealth;

    //PROBAR: instanciar las explosiones desde aqu�
    //public GameObject enemyExplosion;
    //public GameObject playerExplosion;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        /*
        if(currentHealth <= 0)
        {
            //Play death animation

            // Show GameOver screen

        }*/
    }
}
