using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class FinalSceneGameController : MonoBehaviour
{
    string jugador;
    int score;
    FinalSceneGameController finalSceneGameController;
    public Text scoreText;

    public List<Save> Saves = new List<Save>();


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        score = (int)PlayerPrefs.GetFloat("score3", 0);
        //score = GameState.gameState.score;
        UpdateScore();
    }

    

    void UpdateScore()
    {
        //finalSceneGameController.ScoreText.text = "Score: " + score;
        scoreText.text = "Your Score: " + score;
        SaveByXML2();
        //SaveByXML();
    }


    //NEW TODO ABAJO: GUARDAR PUNTUACIÓN EN ARCHIVO XML

    /*public void SaveByXML() {

        Save save = saveScore();

        XmlDocument xmlDocument = new XmlDocument();

        #region CreateXML elements

        //MODIFICAR PARA QUE EL ROOT SEA UN ARRAY????
        XmlElement root = xmlDocument.CreateElement("Save");
        //root.SetAttribute("FileName", "File_01");     

        XmlElement scoreElement = xmlDocument.CreateElement("score");
        scoreElement.InnerText = save.playerScore.ToString();
        root.AppendChild(scoreElement);

        //AÑADIR LO MISMO PARA EL NOMBRE DEL JUGADOR

        //AÑADIR EL SAVE CREADO AL ARRAY
        #endregion

        xmlDocument.AppendChild(root);

        xmlDocument.Save(Application.dataPath + "/dataxml.text");

            if(File.Exists(Application.dataPath + "/dataxml.text")) {

            Debug.Log("XML FILE SAVED");
        }

    }*/

    public void SaveByXML2()
    {
        Save save = saveScore();
        AddNewPlayerToXml(save);
    }

    public void SaveByXML()
    {
        Save save = saveScore();
        //AÑADIMOS EL SAVE CREADO AL ARRAY
        Saves.Add(save);
        

    XmlDocument xmlDocument = new XmlDocument();

        #region CreateXML elements

        //CREAMOS EL DOCUMENTO CON EL ARRAY COMO ROOT
        XmlElement root = xmlDocument.CreateElement("SavedPlayers");
        //root.SetAttribute("FileName", "File_01");     

        //CREAMOS LOS ELEMENTOS, CADA UNO DE LOS CUALES SERÁ UN PLAYER
        XmlElement playerElement = xmlDocument.CreateElement("player");
        root.AppendChild(playerElement);

        //AÑADIMOS EL NOMBRE DEL JUGADOR Y LA PUNTUACIÓN
        XmlElement playerNameElement = xmlDocument.CreateElement("name");
        //playerNameElement.InnerText = save.player.ToString();
        playerElement.AppendChild(playerNameElement);

        XmlElement scoreElement = xmlDocument.CreateElement("score");
        scoreElement.InnerText = save.playerScore.ToString();
        playerElement.AppendChild(scoreElement);

        #endregion

        xmlDocument.AppendChild(root);

        xmlDocument.Save(Application.dataPath + "/dataxml.text");

        if (File.Exists(Application.dataPath + "/dataxml.text"))
        {

            Debug.Log("XML FILE SAVED");
        }



    }

    public void AddNewPlayerToXml(Save save)
    {
        //CARGAMOS LA LISTA DE PLAYERS DEL DOCUMENTO -- REVISAR !!!!!!
        //Saves = LoadListFromXml();

        //CREAMOS UN NUEVO DOCUMENTO Y CARGAMOS EL EXISTENTE
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(Application.dataPath + "/dataxml.text");

        //CREAMOS EL NUEVO PLAYER Y LO AÑADIMOS A LA LISTA DE PLAYERS CARGADA
        XmlElement playerElement = xmlDocument.CreateElement("player");
        
        XmlElement playerNameElement = xmlDocument.CreateElement("name");
        //playerNameElement.InnerText = save.player.ToString();
        playerElement.AppendChild(playerNameElement);

        XmlElement scoreElement = xmlDocument.CreateElement("score");
        scoreElement.InnerText = save.playerScore.ToString();
        playerElement.AppendChild(scoreElement);

        xmlDocument.DocumentElement.AppendChild(playerElement);

        //VOLVEMOS A GUARDAR EL XML
        xmlDocument.Save(Application.dataPath + "/dataxml.text");

        if (File.Exists(Application.dataPath + "/dataxml.text"))
        {

            Debug.Log("XML FILE SAVED");
        }

    }

    /*public void SaveByXML(int score)
    {
        SaveContainer saves = new SaveContainer();
        Save save = saveScore();
        save.playerScore = score;
        saves.Add(save);
        saves.Save();
    }*/

    private void LoadByXML()
    {
        if(File.Exists(Application.dataPath + "/dataxml.text"))
        {
            //Load the Game
            Save save = new Save();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(Application.dataPath + "/dataxml.text");

            //Get the save file data from the file
            XmlNodeList score = xmlDocument.GetElementsByTagName("score");
            int scorePoints = int.Parse(score[0].InnerText);
            save.playerScore = scorePoints;

            //TODO: ADD HERE SAME CODE AS ABOVE FOR PLAYER'S NAME
            /*XmlNodeList score = xmlDocument.GetElementsByTagName("score");
            int scorePoints = int.Parse(score[0].InnerText);
            save.score = scorePoints;*/

            //Assign the saved data to the game real data
            finalSceneGameController.score = save.playerScore;
            //Add here more data as needed
        }
        else
        {
            Debug.Log("File not found!");
        }
    }

    public static List<Save> LoadListFromXml()
    {
        var serializer = new XmlSerializer(typeof(List<Save>));
        using (var stream = new FileStream(Application.dataPath + "/dataxml.text", FileMode.Open))
        {
            return serializer.Deserialize(stream) as List<Save>;
        }
    }

    private Save saveScore()
    {

        Save save = new Save();

        save.player = jugador;
        save.playerScore = score;

        return save;

    }

}
