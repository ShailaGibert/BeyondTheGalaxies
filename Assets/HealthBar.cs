using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    /*public Slider slider;
    public void setMaxhealth(int health){

        slider.maxValue=health;
        slider.value=health;

    }
    
    public void SetHealth(int health){

        slider.value=health;
    }*/
    public SaludJugador playerHealth;
    public Image fillImage;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
        slider.value = 10;
    }

    void Update()
    {
        if(slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        if(slider.value > slider.minValue && !(fillImage.enabled))
        {
            fillImage.enabled = true;
        }

        float fillValue = (float)playerHealth.currentHealth / (float)playerHealth.maxHealth;
        //Debug.Log(fillValue);

        /*
        //Para que la barra cambie de color al llegar a un tercio de la vida
        if(fillValue <= (slider.maxValue / 3))
        {
            fillImage.color = Color.yellow; //Critical condition
        }
        else if(fillValue > (slider.maxValue / 3))
        {
            fillImage.color = Color.red;
        }
        */
        slider.value = fillValue;
        
    }
}
