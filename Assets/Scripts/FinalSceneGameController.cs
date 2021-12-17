using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalSceneGameController : MonoBehaviour
{
    int score;
    FinalSceneGameController finalSceneGameController;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        PlayerPrefs.GetFloat("score");
        score = GameState.gameState.score;
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateScore()
    {
        scoreText.text = "Your Score: " + score;
        //finalSceneGameController.ScoreText.text = "Score: " + score;
    }
}
