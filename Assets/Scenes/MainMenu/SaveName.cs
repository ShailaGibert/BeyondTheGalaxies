using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveName : MonoBehaviour
{
    TouchScreenKeyboard teclado;
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
                PlayerPrefs.SetString("name", textBox.text);
                Debug.Log("Your name is " + PlayerPrefs.GetString("name"));
                teclado = null;
            }
        }
    }

    //public void OpenKeyboard2()
    //{
    //    if (TouchScreenKeyboard.visible == false && teclado != null)
    //    {
    //        if (teclado.done)
    //        {
    //            textBox.text = teclado.text;
    //            teclado = null;
    //        }
    //    }
    //}

    //public void clickSaveButton()
    //{

    //    PlayerPrefs.SetString("name", textBox.text);
    //    Debug.Log("Your name is " + PlayerPrefs.GetString("name"));
    //}

}
