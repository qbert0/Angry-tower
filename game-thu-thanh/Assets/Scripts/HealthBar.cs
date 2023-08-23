using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient  gradient;
    public Image fill;
    

    public void setMaxHealth(float maxHealth) {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        gameObject.SetActive(slider.value < slider.maxValue);
        fill.color = gradient.Evaluate(1f);
    }

    public void setHealth(float health) {
        slider.value = health;
        gameObject.SetActive(slider.value < slider.maxValue);
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
