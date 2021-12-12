using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
<<<<<<< HEAD
=======
using TMPro;
>>>>>>> dev

public class Healthbar : MonoBehaviour
{
    public Slider slider;
<<<<<<< HEAD

=======
    public TextMeshProUGUI amount;
>>>>>>> dev

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
<<<<<<< HEAD
=======
        amount.text = $"{slider.value}/{slider.maxValue}";
>>>>>>> dev
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
<<<<<<< HEAD
=======
        amount.text = $"{slider.value}/{slider.maxValue}";
>>>>>>> dev
    }
}
