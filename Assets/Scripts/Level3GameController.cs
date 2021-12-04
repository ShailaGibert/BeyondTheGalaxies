using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;

    private int score;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
        SpawnShip();
    }

    // Update is called once per frame
    void SpawnShip()
    {
        Vector3 spawPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Instantiate(hazard, spawPosition, Quaternion.identity);
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }

}
