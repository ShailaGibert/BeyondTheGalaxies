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
        //PlayerPrefs.GetFloat("score");
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

    private void LoadByXML()
    {
        if(File.Exists(Application.dataPath + "/DataXML.text"))
        {
            //Load the Game
            Save save = new Save();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(Application.dataPath + "/DataXML.text");

            //Get the save file data from the file
            XmlNodeList score = xmlDocument.GetElementsByTagName("score");
            int scorePoints = int.Parse(score[0].InnerText);
            save.score = scorePoints;

            //TODO: ADD HERE SAME CODE AS ABOVE FOR PLAYER'S NAME
            /*XmlNodeList score = xmlDocument.GetElementsByTagName("score");
            int scorePoints = int.Parse(score[0].InnerText);
            save.score = scorePoints;*/

            //Assign the saved data to the game real data
            finalSceneGameController.score = save.score;
            //Add here more data as needed
        }
        else
        {
            Debug.Log("File not found!");
        }
    }

    private Save saveScore()
    {

        Save save = new Save();

        save.score = score;

        return save;

    }
}
