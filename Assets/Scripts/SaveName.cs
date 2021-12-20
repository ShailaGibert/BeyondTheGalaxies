using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveName : MonoBehaviour
{
    private string input;

    public InputField textBox;

    public void clickSaveButton(string s)
    {
        input = s;
        Debug.Log(s);
        PlayerPrefs.SetString("name", s);
        Debug.Log("Your name is " + PlayerPrefs.GetString("name"));
    }
}
