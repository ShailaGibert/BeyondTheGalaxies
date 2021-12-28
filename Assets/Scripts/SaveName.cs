using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SaveName : MonoBehaviour
{
    //TouchScreenKeyboard teclado;
    public InputField textBox;

    //public void OpenKeyboard()
    //{
    //    teclado = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    //}

    // Use this for initialization
    void Start()
    {
        //teclado = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.touchCount > 0 && teclado == null)
        //{
        //    Debug.Log("Input touched!");
        //    Debug.Log(TouchScreenKeyboard.visible);
        //    //TouchScreenKeyboard.hideInput = true;
        //    teclado = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NamePhonePad, false, false, false, true, "");
        //    //teclado = new TouchScreenKeyboard("", TouchScreenKeyboardType.NamePhonePad, false, false, false, true, "", 20);
        //}
        

        //if (TouchScreenKeyboard.visible == false && teclado != null)
        //{
        //    if (teclado.done)
        //    {
        //        PlayerPrefs.SetString("name", textBox.text);
        //        Debug.Log("Your name is " + PlayerPrefs.GetString("name"));
        //        //teclado = null;
        //    }
        //}
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

    public void clickSaveButton()
    {

        PlayerPrefs.SetString("name", textBox.text);
        Debug.Log("Your name is " + PlayerPrefs.GetString("name"));
        SceneManager.LoadScene("Level1");

    }

}