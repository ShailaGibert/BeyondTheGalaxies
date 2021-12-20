using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class XMLManager : MonoBehaviour
{
    public static XMLManager manager;
    void Awake()
    {
        manager = this;
    }

    public ItemDatabase itemDB;

    public void SaveItems()
    {
        //open a new xml file
        XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
        //CAMBIAR FILE MODE POR APPEND !!!!!!!!!
        FileStream stream = new FileStream(Application.dataPath + "/XmlFiles/dataxml.xml", FileMode.Create);
        serializer.Serialize(stream, itemDB);
        stream.Close();
    }

    /*[System.Serializable]
    public class ItemEntry
    {
        public string player;
        public int playerScore;
    }*/

    [System.Serializable]
    public class ItemDatabase
    {
        public List<Save> list = new List<Save>();
    }
}
