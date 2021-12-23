using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveName : MonoBehaviour
{
    public InputField textBox;
    public Text Number0Text; // Mostrar contenido de entrada

    private TouchScreenKeyboard keyboard = null;
    // Use this for initialization
    void Start()
    {
        Btn_NewName();
    }

    // Update is called once per frame
    void Update()
    {
        if (keyboard != null)
        {
            if (keyboard.done)
            {
                Number0Text.text = keyboard.text;
                keyboard = null;
            }
        }
    }

    public void Btn_NewName()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }


    public void clickSaveButton()
    {
        Btn_NewName();
        PlayerPrefs.SetString("name", textBox.text);
        Debug.Log("Your name is " + PlayerPrefs.GetString("name"));
    }

}
