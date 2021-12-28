using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System;

public class FinalSceneGameController : MonoBehaviour
{
    string jugador;
    int score;
    FinalSceneGameController finalSceneGameController;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        score = (int)PlayerPrefs.GetFloat("score3", 0);

        //getting name from the PlayerPref
        name = PlayerPrefs.GetString("name");

        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Your Score: " + score;
        SaveByXML();
    }

    //GUARDAR PUNTUACI�N EN ARCHIVO XML
    public void SaveByXML()
    {

        Save save = saveScore();
        XmlDocument xmlDocument = new XmlDocument(); //using System.Xml

        #region CreateXml elements

        XmlElement root = xmlDocument.CreateElement("Save"); //MARKER <Save>...elements...</Save>

        XmlElement playerScoreElement = xmlDocument.CreateElement("score"); // <Score>playerScore</Score>
        playerScoreElement.InnerText = save.playerScore.ToString(); //saving the data inside the <Score> braces
        root.AppendChild(playerScoreElement); //append inside the <Save> braces as a child

        XmlElement playerNameElement = xmlDocument.CreateElement("name"); // <Name>playerName</Name>
        playerNameElement.InnerText = save.playerName.ToString(); //saving the data inside the <Name> braces
        root.AppendChild(playerNameElement); //append inside the <Save> braces as a child

        #endregion
        xmlDocument.AppendChild(root); //add the root and its children to the Xml Doc

        xmlDocument.Save(Application.streamingAssetsPath + "/datafile.xml");
        if (File.Exists(Application.streamingAssetsPath + "/datafile.xml"))
        {
            Debug.Log("XML file saved.");
        }
    }

    private Save saveScore()
    {

        Save save = new Save();

        save.player = jugador;
        save.playerScore = score;
        save.playerName = name;
        return save;
    }
}
