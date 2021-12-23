using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveName : MonoBehaviour
{
    TouchScreenKeyboard teclado;
    public Text txt;
    public string Pseudo;
    public InputField textBox;

    public void OpenKeyboard()
    {
        teclado = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TouchScreenKeyboard.visible == false && teclado != null)
        {
            if (teclado.done)
            {
                Pseudo = teclado.text;
                txt.text = Pseudo;
                teclado = null;
            }
        }
        clickSaveButton();
    }


    public void clickSaveButton()
    {
        PlayerPrefs.SetString("name", textBox.text);
        Debug.Log("Your name is " + PlayerPrefs.GetString("name"));
    }

}
