using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.IO;

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
        SaveByXML();
        //finalSceneGameController.ScoreText.text = "Score: " + score;
    }


    //NEW TODO ABAJO: GUARDAR PUNTUACIÓN EN ARCHIVO XML

    public void SaveByXML() {

        Save save = saveScore();

        XmlDocument xmlDocument = new XmlDocument();

        #region CreateXML elements

        XmlElement root = xmlDocument.CreateElement("Save");
        //root.SetAttribute("FileName", "File_01");     

        XmlElement scoreElement = xmlDocument.CreateElement("score");
        scoreElement.InnerText = save.score.ToString();
        root.AppendChild(scoreElement);

        #endregion

        xmlDocument.AppendChild(root);

        xmlDocument.Save(Application.dataPath + "/DataXML.text");

            if(File.Exists(Application.dataPath + "/DataXML.text")) {

            Debug.Log("XML FILE SAVED");
        }
    
    }

    private Save saveScore()
    {

        Save save = new Save();

        save.score = score;

        return save;

    }
}
