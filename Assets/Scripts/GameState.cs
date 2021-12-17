using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameState : MonoBehaviour
{
    public int score;
    public static GameState gameState;
    private String rutaArchivo;
    void Awake()
    {
        //Para conocer la ruta donde guardar archivos
        //Debug.Log(Application.persistentDataPath);

        rutaArchivo = Application.persistentDataPath + "/datos.dat";

        if (gameState==null)
        {
            gameState = this;
            DontDestroyOnLoad(gameObject);
        } 
        else if(gameState != this)
        {
            Destroy(gameObject);
        }
        
    }

    void Start()
    {
        LoadData();
    }

    void Update()
    {
        
    }

    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = new FileStream(rutaArchivo, (FileMode)4);

        DataToSave data = new DataToSave();
        data.score = score;

        bf.Serialize(file, data);

        file.Close();

    }

    public void LoadData()
    {
        if(File.Exists(rutaArchivo))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(rutaArchivo, FileMode.Open);

            DataToSave data = (DataToSave)bf.Deserialize(file);

            score = data.score;

            file.Close();
        }
        else
        {
            score = 0;
        }
        
    }
}

[Serializable]
class DataToSave
{
    public int score;

}
