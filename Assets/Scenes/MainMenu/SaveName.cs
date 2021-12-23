using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveName : MonoBehaviour
{
    public InputField textBox;
    public string input;

    void Update()
    {
        ReadString(input);
    }

    public void ClickSaveButton()
    {

        PlayerPrefs.SetString("name", textBox.text);
        Debug.Log("Your name is " + PlayerPrefs.GetString("name"));
    }

    public void ReadString(string s)
    {
        input = s;
        Debug.Log("El nombre es" + input);
    }
}