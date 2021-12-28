using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTextBox : MonoBehaviour
{
    public Text highscoreName1;
    public Text highscoreName2;
    public Text highscoreName3;
    public Text highscoreName4;
    public Text highscoreName5;

    public Text highscore1;
    public Text highscore2;
    public Text highscore3;
    public Text highscore4;
    public Text highscore5;

    // Use this for initialization
    void Start ()
    {
        highscoreName1.text = PlayerPrefs.GetString("highname1");
        highscore1.text = PlayerPrefs.GetInt("highscore1").ToString();

        highscoreName2.text = PlayerPrefs.GetString("highname2");
        highscore2.text = PlayerPrefs.GetInt("highscore2").ToString();

        highscoreName3.text = PlayerPrefs.GetString("highname3");
        highscore3.text = PlayerPrefs.GetInt("highscore3").ToString();

        highscoreName4.text = PlayerPrefs.GetString("highname4");
        highscore4.text = PlayerPrefs.GetInt("highscore4").ToString();

        highscoreName5.text = PlayerPrefs.GetString("highname5");
        highscore5.text = PlayerPrefs.GetInt("highscore5").ToString();

    }

    // Update is called once per frame
    void Update()
    {
        highscoreName1.text = PlayerPrefs.GetString("highname1");
        highscore1.text = PlayerPrefs.GetInt("highscore1").ToString();

        highscoreName2.text = PlayerPrefs.GetString("highname2");
        highscore2.text = PlayerPrefs.GetInt("highscore2").ToString();

        highscoreName3.text = PlayerPrefs.GetString("highname3");
        highscore3.text = PlayerPrefs.GetInt("highscore3").ToString();

        highscoreName4.text = PlayerPrefs.GetString("highname4");
        highscore4.text = PlayerPrefs.GetInt("highscore4").ToString();

        highscoreName5.text = PlayerPrefs.GetString("highname5");
        highscore5.text = PlayerPrefs.GetInt("highscore5").ToString();

    }
}
