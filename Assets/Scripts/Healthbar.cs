using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI amount;

    Quaternion rotation;
    void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        rotation = transform.rotation;
    }
    void LateUpdate()
    {
        transform.rotation = rotation;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        amount.text = $"{slider.value}/{slider.maxValue}";
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        amount.text = $"{slider.value}/{slider.maxValue}";
    }
}
