using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volumen : MonoBehaviour { 

    public Slider slider;
    public float sliderValue;


    // Start is called before the first frame update
    void Start()
    {
        //We save the settings even if the game is closed
        //First time started, volume is in 0.5 if it hasn't been changed before
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
    }
     
    //ChangeSlider is called every time the user changes the value of slider, 
    //to change the volume setting

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
