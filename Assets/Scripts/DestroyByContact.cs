using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject enemyExplosion;
    public GameObject playerExplosion;

    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<Level3GameController>();
    }

    public int scoreValue;
    private Level3GameController gameController;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary")) return;

        Instantiate(enemyExplosion, transform.position, transform.rotation);
        
        if(other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }

        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
