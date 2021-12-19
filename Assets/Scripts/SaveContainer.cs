using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[System.Serializable]
[XmlRoot("SavedPlayers")]
public class SaveContainer
{
    [XmlArray("Saves"), XmlArrayItem("Save")]
    public List<Save> Saves = new List<Save>();

    public void Save(Save save)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(SaveContainer));
        StreamWriter writer = new StreamWriter(Application.dataPath + "/dataxml.xml");
        serializer.Serialize(writer.BaseStream, save);
        writer.Close();
        
    }

    public static SaveContainer Load(Save save)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(SaveContainer));
        StreamWriter writer = new StreamWriter(Application.dataPath + "/dataxml.xml");
        return serializer.Deserialize(writer.BaseStream) as SaveContainer;
    }

    public void add(Save save)
    {
        Saves.Add(save);
    }
}
