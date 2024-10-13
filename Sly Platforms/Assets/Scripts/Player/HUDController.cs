using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Implementation of player's HUD behaviour
/// </summary>
public class HUDController : MonoBehaviour
{
    [SerializeField] private Image hpSprite;
    [SerializeField] private TextMeshProUGUI hpText;

    public void HPChanged(float newValue, float maxValue)
    {
        hpText.text = Convert.ToInt32(newValue).ToString();
        hpSprite.fillAmount = newValue / maxValue;
    }
}
