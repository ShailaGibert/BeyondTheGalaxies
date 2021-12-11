using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3DestroyByContact : MonoBehaviour
{
    public GameObject enemyExplosion;
    public GameObject playerExplosion;

    public int scoreValue;
    private Level3GameController level3GameController;
    

    void Start()
    {
        level3GameController = GameObject.FindWithTag("Level3GameController").GetComponent<Level3GameController>();
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy")) return;

        if (enemyExplosion != null)
        {
            Instantiate(enemyExplosion, transform.position, transform.rotation);
        }

        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            level3GameController.GameOver();
        }

        level3GameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
