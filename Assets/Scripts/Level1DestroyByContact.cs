using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1DestroyByContact : MonoBehaviour
{
    public GameObject enemyExplosion;
    public GameObject playerExplosion;

   void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Boundary")) return;
        Instantiate(enemyExplosion, transform.position, transform.rotation);
        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}

