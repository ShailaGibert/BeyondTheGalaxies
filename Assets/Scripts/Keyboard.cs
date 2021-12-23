using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour
{
    UnityEngine.TouchScreenKeyboard keyboard;
    public static string keyboardText = "";
    InputField inputField;
    
    private void Start()
    {
        
        //inputField.Select();
        //inputField.ActivateInputField();
    }
    void Update()
    {
        if (Input.touchCount > 0) {
            Debug.Log("Input touched!");
            bool visible = TouchScreenKeyboard.visible;
            Debug.Log(visible);
            //keyboardText = keyboard.text;
            keyboard = TouchScreenKeyboard.Open("text to edit");
            //TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        }
    }

    public void Open(string text, bool autocorrection, bool multiline, bool secure, bool alert, string textPlaceholder, int keyboardType)
    {
        if (keyboard != null)
            return;

        keyboard = UnityEngine.TouchScreenKeyboard.Open(text, (TouchScreenKeyboardType)keyboardType, autocorrection, multiline, secure, alert, textPlaceholder);
    }
}
