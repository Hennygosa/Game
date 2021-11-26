using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RadialBar : MonoBehaviour
{
    public Image fill;
    public TextMeshProUGUI amount;
    public float currentValue, maxValue;

    void Start()
    {
        amount.text = $"{maxValue}";
        fill.fillAmount = Normalize();
    }

    public void Modify(float val)
    {
        currentValue = val;

        if (currentValue > maxValue)
            currentValue = maxValue;

        fill.fillAmount = Normalize();
        amount.text = $"{currentValue}";
    }

    private float Normalize()
    {
        return (float)currentValue / maxValue;
    }
}
