using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System;

public class Ranking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        loadXml();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadXml()
    {
        if (File.Exists(Application.dataPath + "/dataxml.text")) 
        {
            //Loading the game
            Save save = new Save();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(Application.dataPath + "/dataxml.text");

            //Get the file date into XmlNodeList
            XmlNodeList nameListXml = xmlDocument.GetElementsByTagName("name");

            XmlNodeList scoreListXml = xmlDocument.GetElementsByTagName("score");

            //Assigning the XmlNodeList values to List
            List<string> nameList = new List<string>();
            List<int> scoreList = new List<int>();
            foreach (System.Xml.XmlNode item in nameListXml)
            {
                nameList.Add(item.InnerText);
            }

            foreach (System.Xml.XmlNode item in scoreListXml)
            {
                scoreList.Add(int.Parse(item.InnerText));
            }

            //Giving it an arbitrary value
            int indexOfScore = 0, maxValue = 0;

            //Looping for each position of the ranking
            for (int i = 0; i < 5; i++)
            {
                //Looping for each element in the list
                foreach (int item in scoreList)
                {
                    if (item > maxValue)
                    {
                        maxValue = item;
                        indexOfScore = scoreList.IndexOf(maxValue);

                        switch (i)
                        {
                            //Switching cases to save in PlayerPrefs
                            case 0:
                                PlayerPrefs.SetInt("highscore1", maxValue);
                                PlayerPrefs.SetString("highname1", nameList[indexOfScore]);
                                Debug.Log(PlayerPrefs.GetInt("highscore1"));
                                Debug.Log(PlayerPrefs.GetString("highname1"));
                                break;
                            case 1:
                                PlayerPrefs.SetInt("highscore2", maxValue);
                                PlayerPrefs.SetString("highname2", nameList[indexOfScore]);
                                Debug.Log(PlayerPrefs.GetInt("highscore2"));
                                Debug.Log("Entra en el case 1");
                                Debug.Log(PlayerPrefs.GetString("highname2"));
                                Debug.Log("Sale del case 1");
                                break;
                            case 2:
                                PlayerPrefs.SetInt("highscore3", maxValue);
                                PlayerPrefs.SetString("highname3", nameList[indexOfScore]);
                                Debug.Log(PlayerPrefs.GetInt("highscore3"));
                                Debug.Log(PlayerPrefs.GetString("highname3"));
                                break;
                            case 3:
                                PlayerPrefs.SetInt("highscore4", maxValue);
                                PlayerPrefs.SetString("highname4", nameList[indexOfScore]);
                                Debug.Log(PlayerPrefs.GetInt("highscore4"));
                                Debug.Log(PlayerPrefs.GetString("highname4"));
                                break;
                            case 4:
                                PlayerPrefs.SetInt("highscore5", maxValue);
                                PlayerPrefs.SetString("highname5", nameList[indexOfScore]);
                                Debug.Log(PlayerPrefs.GetInt("highscore5"));
                                Debug.Log(PlayerPrefs.GetString("highname5"));
                                break;                            
                        }
                        //Debug.Log("Salimos del Switch y del if");
                    }
                }
                //Removing the max values found to iterate again without them
                nameList.RemoveAt(indexOfScore);
                scoreList.Remove(maxValue);
                maxValue = 0;
                //Debug.Log("Estamos en la vuelta del i " + i);
            }
        }
        else
        {
            Debug.Log("File not founded.");
        }
    }
}
