using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthStatusBar : MonoBehaviour
{
    public LuminarisHealth enemyHealth;
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

        float fillValue = (float)enemyHealth.currentHealth / (float)enemyHealth.maxHealth;
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
